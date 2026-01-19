using System;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoUsuario : Form
    {
        public Controlador Controlador { get; set; }

        private static NuevoUsuario formulario;

        public static NuevoUsuario GetInstance()
        {
            if (formulario == null || formulario.IsDisposed)
                formulario = new NuevoUsuario();
            return formulario;
        }

        public NuevoUsuario()
        {
            InitializeComponent();
            btnGuardar.Click += btnGuardar_Click;
        }

        public void CargarDatos()
        {
    
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbDNI.Text = "";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Hay q conectarlo al controlador
            string nombre = tbNombre.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string dni = tbDNI.Text.Trim();

            if (nombre.Length == 0 || telefono.Length == 0 || dni.Length == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            MessageBox.Show("Listo para guardar (aún falta conectar el controlador).");
        }
    }
}
