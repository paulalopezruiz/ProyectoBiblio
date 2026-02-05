using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class Home : Form
    {
        // Evento que notificará al Gestor que queremos cambiar el formulario
        public event Action<Form> CambiarFormulario;

        public Home()
        {
            InitializeComponent();
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
            // En vez de abrir directamente el formulario, lanzamos un evento
            CambiarFormulario?.Invoke(new listadoUsuarios());
        }

        private void pLibros_Click(object sender, EventArgs e)
        {
            // Aquí puedes hacer lo mismo para libros si quieres
            // CambiarFormulario?.Invoke(new listadoLibros());
        }

        // -------------------------
        // Click en PRÉSTAMOS
        // -------------------------
        private void pPrestamos_Click(object sender, EventArgs e)
        {
            CambiarFormulario?.Invoke(new listadoPrestamos());

        }
        private void tlpHome_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
