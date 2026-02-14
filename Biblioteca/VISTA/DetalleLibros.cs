using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class DetalleLibros : Form
    {
        private Libro libro;
        private Controlador controlador;

        // Evento para avisar al listado de libros que hubo cambios
        public event EventHandler LibroActualizado;

        public DetalleLibros(Libro l)
        {
            InitializeComponent();
            libro = l ?? throw new ArgumentNullException(nameof(l));

            // Obtener controlador desde MDI o ventana abierta
            Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            controlador = gestor?.Controlador;

            lTitulo.Text = libro.Titulo;
            lAutor.Text = libro.Escritor;
            lEjemplares.Text = libro.NEjemplares.ToString();

            tbEditTitulo.Visible = false;
            tbEditAutor.Visible = false;
            nudEditEjemplares.Visible = false;

            lTitulo.Click += (s, e) => ActivarEdicion(tbEditTitulo, lTitulo.Text);
            lAutor.Click += (s, e) => ActivarEdicion(tbEditAutor, lAutor.Text);
            lEjemplares.Click += (s, e) => ActivarEdicionNumeric(nudEditEjemplares, libro.NEjemplares);

            tbEditTitulo.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Titulo);
            tbEditAutor.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Autor);
            nudEditEjemplares.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.NEjemplares);

            CargarPortada();
            pictureBoxPortada.Cursor = Cursors.Hand;
            pictureBoxPortada.Click += PictureBoxPortada_Click;

            btnVerPrestamos.Click += btnVerPrestamos_Click;
        }

        private enum Campo { Titulo, Autor, NEjemplares }

        private void ActivarEdicion(TextBox tb, string valor)
        {
            tb.Text = valor;
            tb.Visible = true;
            tb.BringToFront();
            tb.Focus();
            tb.SelectAll();
        }

        private void ActivarEdicionNumeric(NumericUpDown nud, int valor)
        {
            nud.Value = valor;
            nud.Visible = true;
            nud.BringToFront();
            nud.Focus();
        }

        private void GuardarConEnter(KeyEventArgs ke, Campo campo)
        {
            if (ke.KeyCode != Keys.Enter) return;

            switch (campo)
            {
                case Campo.Titulo:
                    controlador.ActualizarTituloLibro(libro.IdLibro, tbEditTitulo.Text);
                    libro.Titulo = tbEditTitulo.Text;
                    lTitulo.Text = tbEditTitulo.Text;
                    tbEditTitulo.Visible = false;
                    break;

                case Campo.Autor:
                    controlador.ActualizarAutorLibro(libro.IdLibro, tbEditAutor.Text);
                    libro.Escritor = tbEditAutor.Text;
                    lAutor.Text = tbEditAutor.Text;
                    tbEditAutor.Visible = false;
                    break;

                case Campo.NEjemplares:
                    controlador.ActualizarNEjemplares(libro.IdLibro, (int)nudEditEjemplares.Value);
                    libro.NEjemplares = (int)nudEditEjemplares.Value;
                    lEjemplares.Text = nudEditEjemplares.Value.ToString();
                    nudEditEjemplares.Visible = false;
                    break;
            }

            LibroActualizado?.Invoke(this, EventArgs.Empty);
            ke.SuppressKeyPress = true;
        }

        private void PictureBoxPortada_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog { Filter = "Imágenes|*.jpg;*.png;*.bmp" })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                string carpeta = Path.Combine(Application.StartupPath, "imagenes");
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);

               
                string nombreArchivo = Path.GetFileName(dlg.FileName);

                string destino = Path.Combine(carpeta, nombreArchivo);

                try
                {
                    File.Copy(dlg.FileName, destino, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo copiar la imagen: " + ex.Message);
                    return;
                }

                string rutaRelativa = Path.Combine("imagenes", nombreArchivo)
                                        .Replace("\\", "/");

                controlador.ActualizarPortadaLibro(libro.IdLibro, rutaRelativa);

                libro.Portada = rutaRelativa;

                CargarPortada();
            }
        }

        private void CargarPortada()
        {
            pictureBoxPortada.Image = null;
            if (string.IsNullOrEmpty(libro?.Portada)) return;

            string ruta = Path.Combine(Application.StartupPath, libro.Portada);
            if (!File.Exists(ruta)) return;

            try
            {
                using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    pictureBoxPortada.Image = new Bitmap(fs);
                }
            }
            catch
            {
                pictureBoxPortada.Image = null;
            }
        }

        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            listadoPrestamos listado = new listadoPrestamos(controlador, libro.IdLibro);

            Gestor gestor = this.MdiParent as Gestor
                             ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            if (gestor != null)
            {
                gestor.NavegarA(listado);
            }
        }

        private void tlpPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
