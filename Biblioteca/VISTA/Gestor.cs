using System;
using System.Windows.Forms;
using Biblioteca.VISTA;
using Biblioteca.CONTROLADOR;

namespace Biblioteca
{
    public partial class Gestor : Form
    {
        // Un único controlador para toda la app (se comparte a todas las vistas)
        public Controlador Controlador { get; set; } = new Controlador();

        public Gestor()
        {
            InitializeComponent();

            // Hacemos que Gestor sea un MDI Container
            this.IsMdiContainer = true;

            // Enlazamos clicks del menú
            lUsuario.Click += lUsuario_Click;
            lLibros.Click += lLibros_Click;
            lPrestamos.Click += lPrestamos_Click;
        }

        // Método para insertar un formulario dentro del Gestor
        private void InsertarFormulario(Form formulario)
        {
            // Oculta cualquier formulario MDI activo
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Hide();
            }

            formulario.MdiParent = this;       // hijo MDI
            formulario.Dock = DockStyle.Fill;  // ocupa todo
            formulario.Show();
        }

        // Evento Load del Gestor
        private void Gestor_Load(object sender, EventArgs e)
        {
            // Si tienes Home y quieres que sea la primera pantalla:
            var home = new Home();
            InsertarFormulario(home);
        }

        
        private void lUsuario_Click(object sender, EventArgs e)
        {
           
            var listado = new listadoUsuarios();

            
            listado.Controlador = this.Controlador;

            InsertarFormulario(listado);
        }

        // --------- CLICK LIBROS (por ahora vacío) ---------
        private void lLibros_Click(object sender, EventArgs e)
        {
            // Aquí luego cargarás tu formulario de libros
            // var libros = new listadoLibros();
            // libros.Controlador = this.Controlador;
            // InsertarFormulario(libros);
        }

        // --------- CLICK PRESTAMOS (por ahora vacío) ---------
        private void lPrestamos_Click(object sender, EventArgs e)
        {
            // Aquí luego cargarás tu formulario de préstamos
            // var prestamos = new listadoPrestamos();
            // prestamos.Controlador = this.Controlador;
            // InsertarFormulario(prestamos);
        }

        private void tbMenu_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
