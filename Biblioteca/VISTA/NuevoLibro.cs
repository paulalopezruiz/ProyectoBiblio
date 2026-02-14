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

        private bool mostrado = false;
        private const float FONT_SIZE = 8.0f;

        public NuevoLibro(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;

            btnGuardar.Click += btnGuardar_Click;
            btnSubirImagen.Click += btnSubirImagen_Click;

            this.Shown += NuevoLibro_Shown;
            this.Resize += NuevoLibro_Resize;

            CargarDatos();
        }

        private void NuevoLibro_Shown(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
            PonerPortadaPorDefecto();
        }

        private void NuevoLibro_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;

            AplicarEscalado();

            if (string.IsNullOrEmpty(rutaImagenBD))
                PonerPortadaPorDefecto();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            if (proporcionAlto > 3f) proporcionAlto = 3f;

            CambiarFuentes(tlpPrincipal, proporcionAlto);
        }

        private void CambiarFuentes(Control c, float proporcionAlto)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(control.Font.FontFamily, FONT_SIZE * proporcionAlto, control.Font.Style);
                CambiarFuentes(control, proporcionAlto);
            }
        }

        public void CargarDatos()
        {
            tbTitulo.Text = "";
            tbAutor.Text = "";
            numericEjemplares.Value = 1;

            rutaImagenBD = "";
            PonerPortadaPorDefecto();
        }

        private void PonerPortadaPorDefecto()
        {
            if (!string.IsNullOrEmpty(rutaImagenBD)) return;

            pictureBoxImagen.Image = null;
            pictureBoxImagen.BackColor = Color.LightGray;
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Title = "Selecciona una imagen para la portada"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            string rutaOrigen = ofd.FileName;
            string nombreArchivo = Path.GetFileName(rutaOrigen);

            string carpetaDestino = Path.Combine(Application.StartupPath, "imagenes");
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

            try
            {
                File.Copy(rutaOrigen, rutaDestino, true);

                pictureBoxImagen.BackColor = Color.White;
                pictureBoxImagen.Image = Image.FromFile(rutaDestino);

                rutaImagenBD = "imagenes/" + nombreArchivo;

                MessageBox.Show("Imagen subida correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al subir la imagen: " + ex.Message);
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

            if (string.IsNullOrEmpty(rutaImagenBD))
            {
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
