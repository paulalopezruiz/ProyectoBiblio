using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoLibro : Form
    {
        private readonly Controlador controlador;
        private string rutaImagenBD = "";

        // --- ESCALADO ---
        private bool mostrado = false;

        private const float FONT_SIZE = 8.0f;

        // Márgenes base del diseñador
        private const int BTN_GUARDAR_MARGIN_LR = 150;
        private const int BTN_GUARDAR_MARGIN_TB = 5;

        private const int BTN_SUBIR_MARGIN_LR = 100;
        private const int BTN_SUBIR_MARGIN_TB = 25;

        // (Opcional) padding base si quieres añadir luego
        // private const int PRINCIPAL_PADDING = 0;

        public NuevoLibro(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            // Configuración inicial del PictureBox
            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.BackColor = Color.White;
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;

            // Eventos
            btnGuardar.Click += btnGuardar_Click;
            btnSubirImagen.Click += btnSubirImagen_Click;

            this.Activated += NuevoLibro_Activated;
            this.Resize += NuevoLibro_Resize;

            // Inicializar datos
            CargarDatos();
        }

        private void NuevoLibro_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
            CrearImagenGrisSiToca();
        }

        private void NuevoLibro_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;

            AplicarEscalado();

            // Si aún no hay imagen subida (ruta vacía), regeneramos la gris con el nuevo tamaño
            if (string.IsNullOrEmpty(rutaImagenBD))
                CrearImagenGrisSiToca();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            // Fuentes (uso alto como en tus ejemplos)
            cambiarFuentes(tlpPrincipal, proporcionAlto);

            // Márgenes de botones (para que “respiren” con el tamaño)
            btnGuardar.Margin = new Padding(
                (int)(BTN_GUARDAR_MARGIN_LR * proporcionAncho),
                (int)(BTN_GUARDAR_MARGIN_TB * proporcionAlto),
                (int)(BTN_GUARDAR_MARGIN_LR * proporcionAncho),
                (int)(BTN_GUARDAR_MARGIN_TB * proporcionAlto)
            );

            btnSubirImagen.Margin = new Padding(
                (int)(BTN_SUBIR_MARGIN_LR * proporcionAncho),
                (int)(BTN_SUBIR_MARGIN_TB * proporcionAlto),
                (int)(BTN_SUBIR_MARGIN_LR * proporcionAncho),
                (int)(BTN_SUBIR_MARGIN_TB * proporcionAlto)
            );

            tlpPrincipal.PerformLayout();
        }

        private void cambiarFuentes(Control c, float proporcionAlto)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * proporcionAlto,
                    control.Font.Style
                );

                cambiarFuentes(control, proporcionAlto);
            }
        }

        public void CargarDatos()
        {
            tbTitulo.Text = "";
            tbAutor.Text = "";
            numericEjemplares.Value = 1;

            rutaImagenBD = ""; // indica que no hay imagen subida

            CrearImagenGrisSiToca();
        }

        private void CrearImagenGrisSiToca()
        {
            // Si el picturebox aún no tiene tamaño válido, no hacemos nada
            int w = Math.Max(1, pictureBoxImagen.ClientSize.Width);
            int h = Math.Max(1, pictureBoxImagen.ClientSize.Height);

            // Si ya hay imagen y NO es la gris (usuario subió una), no la tocamos
            // Aquí usamos rutaImagenBD como señal: si está vacía, es “gris”
            if (!string.IsNullOrEmpty(rutaImagenBD)) return;

            // Reemplazar imagen por una gris adaptada al tamaño actual
            Bitmap gris = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(gris))
            {
                g.Clear(Color.LightGray);
            }

            pictureBoxImagen.Image?.Dispose();
            pictureBoxImagen.Image = gris;
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Selecciona una imagen para la portada"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string rutaOrigen = ofd.FileName;
                string nombreArchivo = Path.GetFileName(rutaOrigen);
                string carpetaDestino = Path.Combine(Application.StartupPath, "imagenes");

                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

                try
                {
                    using (var tempImg = Image.FromFile(rutaOrigen))
                    {
                        Bitmap copia = new Bitmap(tempImg);
                        pictureBoxImagen.Image?.Dispose();
                        pictureBoxImagen.Image = copia;
                    }

                    File.Copy(rutaOrigen, rutaDestino, true);
                    rutaImagenBD = "imagenes/" + nombreArchivo;

                    MessageBox.Show("Imagen subida correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al subir la imagen: " + ex.Message);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = tbTitulo.Text.Trim();
            string autor = tbAutor.Text.Trim();
            int numEjemplares = (int)numericEjemplares.Value;

            if (titulo.Length == 0 || autor.Length == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }
            if (numEjemplares <= 0)
            {
                MessageBox.Show("El número de ejemplares debe ser mayor que cero.");
                return;
            }

            // Si no suben imagen, usamos la portada gris por defecto
            if (string.IsNullOrEmpty(rutaImagenBD))
            {
                string carpetaDestino = Path.Combine(Application.StartupPath, "imagenes");
                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string rutaDefecto = Path.Combine(carpetaDestino, "default.png");

                if (!File.Exists(rutaDefecto))
                {
                    // generamos un png gris (tamaño actual del picturebox)
                    int w = Math.Max(1, pictureBoxImagen.ClientSize.Width);
                    int h = Math.Max(1, pictureBoxImagen.ClientSize.Height);

                    Bitmap gris = new Bitmap(w, h);
                    using (Graphics g = Graphics.FromImage(gris))
                        g.Clear(Color.LightGray);

                    gris.Save(rutaDefecto);
                    gris.Dispose();
                }

                rutaImagenBD = "imagenes/default.png";
            }

            try
            {
                controlador.InsertarLibro(titulo, autor, rutaImagenBD, numEjemplares);
                MessageBox.Show("Libro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el libro: " + ex.Message);
            }
        }
    }
}
