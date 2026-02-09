using System;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class DetalleUsuario : Form
    {
        private readonly Usuario _usuario;

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

            // Obtenemos el Gestor que tiene la instancia del Controlador
            Gestor gestor = this.MdiParent as Gestor ?? Application.OpenForms.OfType<Gestor>().FirstOrDefault();
            if (gestor == null)
            {
                MessageBox.Show("No se encontró el Gestor para cambiar de pantalla.");
                return;
            }

            // Evitar abrir doble listado de préstamos: buscamos por tipo de formulario y usuario
            var yaAbierto = Application.OpenForms
                                .OfType<Form>()
                                .FirstOrDefault(f => f is listadoPrestamos lp &&
                                                     lp.Text.Contains(_usuario.Nombre)); // se puede filtrar por título

            if (yaAbierto != null)
            {
                yaAbierto.BringToFront();
                return;
            }

            // Abrir listado de préstamos filtrado por ID del usuario
            listadoPrestamos prestamos = new listadoPrestamos(gestor.Controlador, _usuario.DNI);
            prestamos.Text = $"Préstamos de {_usuario.Nombre}"; // para identificar el formulario
            gestor.NavegarA(prestamos);

            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
