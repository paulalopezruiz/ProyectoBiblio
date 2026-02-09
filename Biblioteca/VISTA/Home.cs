using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;
using Biblioteca.VISTA;

namespace Biblioteca.VISTA
{
    public partial class Home : Form
    {
        // Evento que notificará al Gestor que queremos cambiar el formulario
        public event Action<Form> CambiarFormulario;

        // Instancia del controlador para pasar a los listados
        private Controlador controlador;

        public Home()
        {
            InitializeComponent();
            controlador = new Controlador();
        }

        private void panelTarjeta_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3; // grosor del borde
            Color colorBorde = Color.Black;

            Control c = (Control)sender;
            using (Pen pen = new Pen(colorBorde, grosor))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void pUser_Click(object sender, EventArgs e)
        {
            // Pasamos el controlador al listado
            CambiarFormulario?.Invoke(new listadoUsuarios(controlador));
        }

        private void pLibros_Click(object sender, EventArgs e)
        {
            // Pasamos el controlador al listado
            CambiarFormulario?.Invoke(new listadoLibros(controlador));
        }

        private void pPrestamos_Click(object sender, EventArgs e)
        {
            // Pasamos el controlador al listado
            CambiarFormulario?.Invoke(new listadoPrestamos(controlador));
        }

        private void tlpHome_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
