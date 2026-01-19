using System;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoLibro : Form
    {
        public Controlador Controlador { get; set; }

        private static NuevoLibro formulario;

        public static NuevoLibro GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new NuevoLibro();
            return formulario;
        }

        public NuevoLibro()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void CargarDatos()
        {
            tbTitulo.Text = "";
            tbAutor.Text = "";
            tbEditorial.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = tbTitulo.Text.Trim();
            string autor = tbAutor.Text.Trim();
            string editorial = tbEditorial.Text.Trim();

            if (titulo.Length == 0 || autor.Length == 0 || editorial.Length == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            MessageBox.Show("Listo para guardar (aún falta conectar el controlador).");
        }
    }
}
