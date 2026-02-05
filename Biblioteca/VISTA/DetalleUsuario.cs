using System;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class DetalleUsuario : Form
    {
        private readonly Usuario _usuario;
        private bool _prestamosAbiertos = false; // Para controlar que no se vuelva a abrir detalle

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

    Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
    if (gestor == null)
    {
        MessageBox.Show("No se encontró el Gestor para cambiar de pantalla.");
        return;
    }

    // Abrir listado de préstamos filtrado por ID del usuario
    listadoPrestamos prestamos = new listadoPrestamos(_usuario.DNI);
    gestor.NavegarA(prestamos);

    // Cerrar el detalle del usuario inmediatamente
    this.Close();
}

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
