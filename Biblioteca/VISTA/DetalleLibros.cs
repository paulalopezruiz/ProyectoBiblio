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

        public DetalleLibros()
        {
            InitializeComponent();
        }

        // Constructor con libro
        public DetalleLibros(Libro l) : this()
        {
            libro = l ?? throw new ArgumentNullException(nameof(l));

            label1.Text = libro.Titulo;
            label2.Text = libro.Escritor;
            label3.Text = libro.NEjemplares.ToString();

            CargarPortada();

            btnGuardar.Click += BtnGuardar_Click;
        }

        // =========================
        // BOTÓN VER PRÉSTAMOS
        // =========================
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (libro == null) return;

            // Obtener referencia al Gestor (MDI principal)
            Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            if (gestor == null)
            {
                MessageBox.Show("No se encontró el Gestor para mostrar los préstamos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear listado de préstamos filtrado por el libro, usando el controlador
            listadoPrestamos prestamos = new listadoPrestamos(gestor.Controlador, libro.IdLibro);

            // Abrir dentro del MDI principal
            gestor.NavegarA(prestamos);

            // Cerrar detalle del libro
            this.Close();
        }

        // =========================
        // CARGAR PORTADA
        // =========================
        private void CargarPortada()
        {
            pictureBoxPortada.Image = null;

            if (string.IsNullOrEmpty(libro?.Portada))
                return;

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

        // =========================
        // EVENTOS VACÍOS (generados por el diseñador)
        // =========================
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
