using System;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class NuevoUsuario : Form
    {
        private readonly Controlador controlador;

        public Usuario UsuarioCreado { get; private set; }

        public NuevoUsuario(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador ?? throw new ArgumentNullException(nameof(controlador));

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

            try
            {
                // Llamamos al controlador, que hace la validación
                controlador.InsertarUsuario(nombre, telefono, dni);

                UsuarioCreado = new Usuario(nombre, telefono, dni);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error guardando usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
