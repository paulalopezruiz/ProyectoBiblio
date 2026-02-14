using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;
using Biblioteca.VISTA;

namespace Biblioteca
{
    public partial class Gestor : Form
    {
        public Controlador Controlador { get; set; }

        private Label[] menuItems;
        private Form formularioActual;

        private bool mostrado = false;

        private const int NAVBAR_H_BASE = 64;

        private const int BTN_W_BASE = 125;
        private const int BTN_H_BASE = 38;
        private const int BTN_MARGIN_BASE = 13;

        private const int LOGO_W_BASE = 173;
        private const int LOGO_H_BASE = 60;

        private const float MENU_FACTOR = 0.88f; 
        private const float BTN_FACTOR = 0.88f;

        
        private float baseFontMenu;
        private float baseFontBtn;

        public Gestor()
        {
            InitializeComponent();

            this.IsMdiContainer = true;

            Controlador = new Controlador();

            lUsuario.Click += Menu_Click;
            lLibros.Click += Menu_Click;
            lPrestamos.Click += Menu_Click;

            menuItems = new Label[] { lUsuario, lLibros, lPrestamos };

            logo.Click += Logo_Click;
            bCerrarSesion.Click += BtnCerrarSesion_Click;

            this.Resize += Gestor_Resize;
        }

        private void Gestor_Load(object sender, EventArgs e)
        {
            baseFontMenu = lUsuario.Font.Size;
            baseFontBtn = bCerrarSesion.Font.Size;

            var home = new Home();
            home.CambiarFormulario += (form) => CambiarFormulario(form, DetectarMenuActivo(form));
            CambiarFormulario(home);

            mostrado = true;
            EscalarGestor(); 
        }

        private void Gestor_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            EscalarGestor();
        }

        private void EscalarGestor()
        {
            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            float escala = Math.Min(proporcionAlto, proporcionAncho);

            NavBar.Height = (int)(NAVBAR_H_BASE * proporcionAlto);

            logo.Size = new Size(
                (int)(LOGO_W_BASE * proporcionAncho),
                (int)(LOGO_H_BASE * proporcionAlto)
            );

            bCerrarSesion.Size = new Size(
                (int)(BTN_W_BASE * proporcionAncho),
                (int)(BTN_H_BASE * proporcionAlto)
            );

            bCerrarSesion.Margin = new Padding(
                (int)(BTN_MARGIN_BASE * proporcionAncho),
                (int)(BTN_MARGIN_BASE * proporcionAlto),
                (int)(BTN_MARGIN_BASE * proporcionAncho),
                (int)(BTN_MARGIN_BASE * proporcionAlto)
            );

            float newMenuSize = baseFontMenu * escala * MENU_FACTOR;
            float newBtnSize = baseFontBtn * escala * BTN_FACTOR;

            lUsuario.Font = new Font(lUsuario.Font.FontFamily, newMenuSize, lUsuario.Font.Style);
            lLibros.Font = new Font(lLibros.Font.FontFamily, newMenuSize, lLibros.Font.Style);
            lPrestamos.Font = new Font(lPrestamos.Font.FontFamily, newMenuSize, lPrestamos.Font.Style);

            bCerrarSesion.Font = new Font(bCerrarSesion.Font.FontFamily, newBtnSize, bCerrarSesion.Font.Style);

            NavBar.PerformLayout();
            tbMenu.PerformLayout();
        }

        private void CambiarFormulario(Form formulario, Label menuActivo = null)
        {
            if (formularioActual != null)
                formularioActual.Hide();

            formularioActual = formulario;
            formulario.MdiParent = this;
            formulario.Dock = DockStyle.Fill;
            formulario.Show();

            ActualizarMenuVisual(menuActivo);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (sender is Label clicked)
            {
                Form formulario = null;

                if (clicked == lUsuario)
                    formulario = new listadoUsuarios(Controlador);
                else if (clicked == lLibros)
                    formulario = new listadoLibros(Controlador);
                else if (clicked == lPrestamos)
                    formulario = new listadoPrestamos(Controlador);

                if (formulario != null)
                    CambiarFormulario(formulario, clicked);
            }
        }

        private void ActualizarMenuVisual(Label activo)
        {
            foreach (var item in menuItems)
            {
                if (item == activo)
                {
                    item.ForeColor = Color.Green;
                    item.Font = new Font(item.Font, FontStyle.Underline);
                }
                else
                {
                    item.ForeColor = Color.Black;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                }
            }
        }

        private Label DetectarMenuActivo(Form form)
        {
            if (form is listadoUsuarios) return lUsuario;
            else if (form is listadoPrestamos) return lPrestamos;
            else if (form is listadoLibros) return lLibros;
            return null;
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            var home = new Home();
            home.CambiarFormulario += (f) => CambiarFormulario(f, DetectarMenuActivo(f));
            CambiarFormulario(home);
        }

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
    }
}
