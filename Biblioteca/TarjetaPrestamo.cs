using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaPrestamo : UserControl
    {
        private Color _colorEstado = Color.Gray;
        private Prestamo _prestamo; // Guardamos el préstamo actual

        public TarjetaPrestamo()
        {
            InitializeComponent();

            // Pintado del círculo de estado
            pEstado.Paint += pEstado_Paint;

            // Evento click para abrir detalle
            this.Click += Tarjeta_Click;
            foreach (Control c in this.Controls)
                c.Click += Tarjeta_Click; // Para que cualquier parte de la tarjeta responda
        }

        // PINTAR ESTADO
     
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

     
        // PONER DATOS
  
        public void PonerDatos(Prestamo prestamo)
        {
            _prestamo = prestamo;

            string nombreUsuario = BibliotecaBBDD.GetNombreUsuario(prestamo.ID_Usuario); 
            string nombreLibro = BibliotecaBBDD.GetTituloLibro(prestamo.ID_Libro);      

            lPrestamo.Text = $"{nombreUsuario} - {nombreLibro}";
            lFecha.Text = prestamo.Fecha_Inicio.ToString("dd/MM/yyyy");

            DateTime hoy = DateTime.Today;

            if (prestamo.Devuelto)
                _colorEstado = Color.Gray; // Devuelto
            else if (prestamo.Fecha_Fin.HasValue && prestamo.Fecha_Fin.Value.Date < hoy)
                _colorEstado = Color.Red;  // No devuelto y vencido
            else
                _colorEstado = Color.Green; // No devuelto y vigente

            pEstado.Invalidate();
        }

   
        // CLICK EN LA TARJETA
     
        private void Tarjeta_Click(object sender, EventArgs e)
        {
            if (_prestamo == null) return;

            // Abrir formulario de detalle
            DetallePrestamo detalle = new DetallePrestamo(_prestamo);
            if (detalle.ShowDialog() == DialogResult.OK)
            {
                // Actualizar estado después de devolución
                PonerDatos(_prestamo);
            }
        }

    }
}
