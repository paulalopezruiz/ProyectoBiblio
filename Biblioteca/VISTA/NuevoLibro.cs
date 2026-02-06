using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoLibro : Form
    {
        public Controlador Controlador { get; set; }

        private static NuevoLibro formulario;

        // Variable para almacenar la ruta relativa de la imagen para la BD
        private string rutaImagenBD = "";

        public static NuevoLibro GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new NuevoLibro();
            return formulario;
        }

        public NuevoLibro()
        {
            InitializeComponent();

            // Configurar PictureBox al inicio
            pictureBoxImagen.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxImagen.BackColor = Color.White;
            pictureBoxImagen.SizeMode = PictureBoxSizeMode.Zoom;

            // Eventos
            btnGuardar.Click += btnGuardar_Click;
            btnSubirImagen.Click += btnSubirImagen_Click;
        }

        public void CargarDatos()
        {
            tbTitulo.Text = "";
            tbAutor.Text = "";
            numericEjemplares.Value = 1; // Valor por defecto
            pictureBoxImagen.Image = null;
            rutaImagenBD = "";
        }

        // =============================
        // SUBIR IMAGEN
        // =============================
        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            ofd.Title = "Selecciona una imagen para la portada";

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
                    // Leer la imagen y crear copia en memoria
                    using (var tempImg = Image.FromFile(rutaOrigen))
                    {
                        Bitmap copia = new Bitmap(tempImg); // copia en memoria
                        pictureBoxImagen.Image?.Dispose();  // liberar imagen previa si existía
                        pictureBoxImagen.Image = copia;     // asignar al pictureBox
                    }

                    // Copiar el archivo al proyecto
                    File.Copy(rutaOrigen, rutaDestino, true); // sobrescribe si ya existía

                    // Guardamos la ruta relativa que irá en la BD
                    rutaImagenBD = "imagenes/" + nombreArchivo;
                    MessageBox.Show("Imagen subida correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al subir la imagen: " + ex.Message);
                }
            }
        }


        // =============================
        // GUARDAR LIBRO
        // =============================
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
                MessageBox.Show("Debe subir una imagen de portada.");
                return;
            }

            try
            {
                // Insertar en la BD
                SQLiteCommand cmd = new SQLiteCommand(
                    "INSERT INTO Libros (Titulo, Escritor, Portada, NEjemplares) " +
                    "VALUES (@titulo, @autor, @portada, @nEjemplares);"
                );
                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@autor", autor);
                cmd.Parameters.AddWithValue("@portada", rutaImagenBD);
                cmd.Parameters.AddWithValue("@nEjemplares", numEjemplares);

                BibliotecaBBDD.Ejecuta(cmd);

                MessageBox.Show("Libro guardado correctamente.");

                this.Close(); // Cierra el formulario después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el libro: " + ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
