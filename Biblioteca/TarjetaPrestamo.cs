using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca
{
    public partial class TarjetaPrestamo : UserControl
    {
        private Color _colorEstado = Color.Gray;

        public TarjetaPrestamo()
        {
            InitializeComponent();
            pEstado.Paint += pEstado_Paint;
        }

        private void pEstado_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            int size = Math.Min(pEstado.Width, pEstado.Height) - 1;
            int x = (pEstado.Width - size) / 2;
            int y = (pEstado.Height - size) / 2;
            Rectangle r = new Rectangle(x, y, size, size);

            using (SolidBrush b = new SolidBrush(_colorEstado))
                e.Graphics.FillEllipse(b, r);
            using (Pen pen = new Pen(Color.DimGray, 1))
                e.Graphics.DrawEllipse(pen, r);
        }

        public void PonerDatos(Prestamo prestamo)
        {
            lPrestamo.Text = prestamo.ID_Usuario;
            lFecha.Text = prestamo.Fecha_Inicio.ToString("dd/MM/yyyy");

            DateTime hoy = DateTime.Today;

            if (prestamo.Devuelto)
            {
                _colorEstado = Color.Gray; // Devuelto
            }
            else if (prestamo.Fecha_Fin.HasValue && prestamo.Fecha_Fin.Value.Date < hoy)
            {
                _colorEstado = Color.Red;  // No devuelto y vencido
            }
            else
            {
                _colorEstado = Color.Green; // No devuelto y aún vigente
            }

            pEstado.Invalidate();
        }

    }
}
