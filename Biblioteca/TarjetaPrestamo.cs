using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaPrestamo : UserControl
    {
        private Color _colorEstado = Color.Gray;

        public TarjetaPrestamo()
        {
            InitializeComponent();

            // Esto ayuda a que se vea más fino
            pEstado.Paint += pEstado_Paint;
        }

        private void pEstado_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tamaño del círculo = el menor entre ancho y alto
            int size = Math.Min(pEstado.Width, pEstado.Height) - 1;

            // Centrar el círculo dentro del panel
            int x = (pEstado.Width - size) / 2;
            int y = (pEstado.Height - size) / 2;

            Rectangle r = new Rectangle(x, y, size, size);

            using (SolidBrush b = new SolidBrush(_colorEstado))
            {
                e.Graphics.FillEllipse(b, r);
            }

            // Borde opcional
            using (Pen pen = new Pen(Color.DimGray, 1))
            {
                e.Graphics.DrawEllipse(pen, r);
            }
        }

        public void PonerDatos(string textoPrestamo, DateTime fechaFin)
        {
            lPrestamo.Text = textoPrestamo;
            lFecha.Text = fechaFin.ToString("dd/MM/yyyy");

            if (fechaFin.Date < DateTime.Today)
                _colorEstado = Color.Gray;
            else
                _colorEstado = Color.Green;

            pEstado.Invalidate(); // repinta
        }
    }
}
