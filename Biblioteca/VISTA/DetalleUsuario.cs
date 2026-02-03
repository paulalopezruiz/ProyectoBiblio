using System;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class DetalleUsuario : Form
    {
        private readonly Usuario _usuario;

        // Constructor que recibe el usuario seleccionado
        public DetalleUsuario(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void DetalleUsuario_Load(object sender, EventArgs e)
        {
            if (_usuario == null) return;

            
            lNombre.Text = _usuario.Nombre;
            lTlf.Text = _usuario.Telefono;
            lDni.Text = _usuario.DNI;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            this.Close();

            
        }
    }
}
