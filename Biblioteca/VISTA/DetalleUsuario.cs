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

        private void btnVerPrestamos_Click(object sender, EventArgs e)
        {
            if (_usuario == null)
            {
                MessageBox.Show("Usuario no válido.");
                return;
            }

            // Buscar el MDI padre (Gestor)
            Gestor gestor = this.MdiParent as Gestor;

            // Si DetalleUsuario se abre como dialog (ShowDialog), MdiParent será null,
            // así que buscamos el Gestor entre los formularios abiertos:
            if (gestor == null)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is Gestor)
                    {
                        gestor = (Gestor)f;
                        break;
                    }
                }
            }

            if (gestor == null)
            {
                MessageBox.Show("No se encontró el Gestor para cambiar de pantalla.");
                return;
            }

            // Navegar al listado de préstamos filtrado por DNI
            gestor.NavegarA(new listadoPrestamos(_usuario.DNI));

            // Cerrar el detalle (opcional)
            this.Close();
        }

    }
}
