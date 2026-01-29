using System;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class NuevoUsuario : Form
    {
        public Usuario UsuarioCreado { get; private set; }

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
            string nombre = tbNombre.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string dni = tbDNI.Text.Trim();

            if (nombre.Length == 0 || telefono.Length == 0 || dni.Length == 0)
            {
                MessageBox.Show("Faltan datos.");
                return;
            }

            UsuarioCreado = new Usuario(nombre, telefono, dni);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
