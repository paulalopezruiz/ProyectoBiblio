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

            // Labels iniciales
            label1.Text = libro.Titulo;
            label2.Text = libro.Escritor;
            label3.Text = libro.NEjemplares.ToString();

            // TextBox/NumericUpDown ocultos al inicio
            textBox1.Visible = false;
            textBox2.Visible = false;
            numericUpDown1.Visible = false;

            // Click en labels -> activar edición
            label1.Click += (s, e) => ActivarEdicion(textBox1, label1.Text);
            label2.Click += (s, e) => ActivarEdicion(textBox2, label2.Text);
            label3.Click += (s, e) => ActivarEdicionNumeric(numericUpDown1, libro.NEjemplares);

            // ENTER para guardar cambios
            textBox1.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Titulo);
            textBox2.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.Autor);
            numericUpDown1.KeyDown += (s, ke) => GuardarConEnter(ke, Campo.NEjemplares);

            // Portada
            CargarPortada();
            pictureBoxPortada.Cursor = Cursors.Hand;
            pictureBoxPortada.Click += PictureBoxPortada_Click;

            // Botón Ver Prestamos
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
                    controlador.ActualizarTituloLibro(libro.IdLibro, textBox1.Text);
                    libro.Titulo = textBox1.Text;
                    label1.Text = textBox1.Text;
                    textBox1.Visible = false;
                    break;

                case Campo.Autor:
                    controlador.ActualizarAutorLibro(libro.IdLibro, textBox2.Text);
                    libro.Escritor = textBox2.Text;
                    label2.Text = textBox2.Text;
                    textBox2.Visible = false;
                    break;

                case Campo.NEjemplares:
                    controlador.ActualizarNEjemplares(libro.IdLibro, (int)numericUpDown1.Value);
                    libro.NEjemplares = (int)numericUpDown1.Value;
                    label3.Text = numericUpDown1.Value.ToString();
                    numericUpDown1.Visible = false;
                    break;
            }

            // Avisar al listado de libros que hubo cambios
            LibroActualizado?.Invoke(this, EventArgs.Empty);

            ke.SuppressKeyPress = true;
        }

        private void PictureBoxPortada_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog { Filter = "Imágenes|*.jpg;*.png;*.bmp" })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                string carpeta = Path.Combine(Application.StartupPath, "imagenes");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string nombreArchivo = $"{libro.IdLibro}{Path.GetExtension(dlg.FileName)}";
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

                string rutaRelativa = Path.Combine("imagenes", nombreArchivo);
                controlador.ActualizarPortadaLibro(libro.IdLibro, rutaRelativa);

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

        // =============================
        // VER PRÉSTAMOS DEL LIBRO
        // =============================
        // Dentro de DetalleLibros
        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            // Crear listadoPrestamos filtrado por este libro
            listadoPrestamos listado = new listadoPrestamos(controlador, libro.IdLibro);

            // Pedir al Gestor que navegue a este formulario
            Gestor gestor = this.MdiParent as Gestor
                             ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            if (gestor != null)
            {
                gestor.NavegarA(listado);
            }
        }





        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void DetalleLibros_Load(object sender, EventArgs e)
        {

        }
    }
}
