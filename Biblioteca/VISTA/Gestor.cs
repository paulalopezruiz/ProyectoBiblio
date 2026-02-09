using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR; 
using Biblioteca.VISTA;

namespace Biblioteca
{
    public partial class Gestor : Form
    {
        // Propiedad del controlador, inicializada en el constructor
        public Controlador Controlador { get; set; }

        private Label[] menuItems;
        private Form formularioActual; // el formulario actualmente cargado

        public Gestor()
        {
            InitializeComponent();

            this.IsMdiContainer = true;

            // Inicializamos el controlador aquí
            Controlador = new Controlador();

            // Enlazamos clicks del menú
            lUsuario.Click += Menu_Click;
            lLibros.Click += Menu_Click;
            lPrestamos.Click += Menu_Click;

            // Array para manejar estilos de menú
            menuItems = new Label[] { lUsuario, lLibros, lPrestamos };

            // Eventos del logo y cerrar sesión
            logo.Click += Logo_Click;
            bCerrarSesion.Click += BtnCerrarSesion_Click;
        }

        private void Gestor_Load(object sender, EventArgs e)
        {
            // Cargar Home al inicio
            var home = new Home();

            // Suscribirse al evento de cambio de formulario desde Home
            home.CambiarFormulario += (form) => CambiarFormulario(form, DetectarMenuActivo(form));

            CambiarFormulario(home); // carga inicial
        }

        // Método centralizado para cambiar formularios
        private void CambiarFormulario(Form formulario, Label menuActivo = null)
        {
            // Ocultar el formulario anterior
            if (formularioActual != null)
            {
                formularioActual.Hide();
            }

            // Configurar nuevo formulario
            formularioActual = formulario;
            formulario.MdiParent = this;
            formulario.Dock = DockStyle.Fill;
            formulario.Show();

            // Actualizar menú
            ActualizarMenuVisual(menuActivo);
        }

        // Manejador genérico para clicks del menú
        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender is Label clicked)
            {
                Form formulario = null;

                // PASAMOS EL CONTROLADOR a los listados
                if (clicked == lUsuario)
                    formulario = new listadoUsuarios(Controlador);
                else if (clicked == lLibros)
                    formulario = new listadoLibros(Controlador);
                else if (clicked == lPrestamos)
                    formulario = new listadoPrestamos(Controlador);

                if (formulario != null)
                {
                    // Si el formulario tiene algún evento interno que llame al MDI
                    if (formulario is Home homeForm)
                    {
                        homeForm.CambiarFormulario += (f) => CambiarFormulario(f, DetectarMenuActivo(f));
                    }

                    CambiarFormulario(formulario, clicked);
                }
            }
        }

        // Método para actualizar el estilo del menú
        private void ActualizarMenuVisual(Label activo)
        {
            foreach (var item in menuItems)
            {
                if (item == activo)
                {
                    item.ForeColor = Color.Green; // color activo
                    item.Font = new Font(item.Font, FontStyle.Underline);
                }
                else
                {
                    item.ForeColor = Color.Black;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                }
            }
        }

        // Detecta qué label del menú corresponde a un formulario
        private Label DetectarMenuActivo(Form form)
        {
            if (form is listadoUsuarios) return lUsuario;
            else if (form is listadoPrestamos) return lPrestamos;
            else if (form is listadoLibros) return lLibros;

            return null; // ningún menú asociado
        }

        // Click en logo -> volver a Home
        private void Logo_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.CambiarFormulario += (f) => CambiarFormulario(f, DetectarMenuActivo(f));
            CambiarFormulario(home);
        }

        // Click cerrar sesión -> volver a Home
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.CambiarFormulario += (f) => CambiarFormulario(f, DetectarMenuActivo(f));
            CambiarFormulario(home);
        }

        public void NavegarA(Form formulario)
        {
            CambiarFormulario(formulario, DetectarMenuActivo(formulario));
        }

        private void lLibros_Click(object sender, EventArgs e)
        {
            // Mantengo tu código tal cual
        }
    }
}
