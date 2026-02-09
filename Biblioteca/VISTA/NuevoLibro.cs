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

            // Inicializar datos
            CargarDatos();
        }

        public void CargarDatos()
        {
            tbTitulo.Text = "";
            tbAutor.Text = "";
            numericEjemplares.Value = 1;

            // Imagen gris por defecto
            Bitmap gris = new Bitmap(pictureBoxImagen.Width, pictureBoxImagen.Height);
            using (Graphics g = Graphics.FromImage(gris))
            {
                g.Clear(Color.LightGray);
            }
            pictureBoxImagen.Image?.Dispose();
            pictureBoxImagen.Image = gris;

            rutaImagenBD = ""; // indica que no hay imagen subida
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
                    Bitmap gris = new Bitmap(pictureBoxImagen.Width, pictureBoxImagen.Height);
                    using (Graphics g = Graphics.FromImage(gris))
                        g.Clear(Color.LightGray);
                    gris.Save(rutaDefecto);
                    gris.Dispose();
                }

                rutaImagenBD = "imagenes/default.png"; // ruta que se guarda en BBDD
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
