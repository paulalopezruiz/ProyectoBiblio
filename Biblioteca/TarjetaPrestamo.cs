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
        private Prestamo _prestamo;

        private bool mostrado = false;

        // --- BASES DEL DISEÑADOR (IMPORTANTE: no dependemos de MinimumSize) ---
        private const int TARJETA_BASE_W = 654;
        private const int TARJETA_BASE_H = 150;

        private const float FONT_SIZE = 9.0f;

        // Panel del estado (base)
        private const int ESTADO_BASE = 30;

        // suavizado para que no suba “a lo bruto”
        private const float SUAVIZADO = 0.60f;

        // límites para que nunca se haga enorme ni desaparezca
        private const int ESTADO_MIN = 22;
        private const int ESTADO_MAX = 60;

        private const int BORDE = 1;

        public TarjetaPrestamo()
        {
            InitializeComponent();

            // ✅ Forzamos layout correcto aunque el Designer tenga Dock=Fill y Margin grande
            PrepararLayout();

            pEstado.Paint += pEstado_Paint;

            this.Click += Tarjeta_Click;
            foreach (Control c in this.Controls)
                c.Click += Tarjeta_Click;

            this.HandleCreated += (s, e) =>
            {
                mostrado = true;
                AplicarEscalado();
            };

            this.Resize += (s, e) =>
            {
                if (!mostrado) return;
                AplicarEscalado();
            };
        }

        private void PrepararLayout()
        {
            // Panel del círculo: NO Fill, centrado, margen pequeño fijo
            pEstado.Dock = DockStyle.None;
            pEstado.Anchor = AnchorStyles.None;
            pEstado.Margin = new Padding(10);
            pEstado.BackColor = Color.Transparent;

            // arrancamos con un tamaño base
            pEstado.Size = new Size(ESTADO_BASE, ESTADO_BASE);

            // (opcional) que el texto no se pegue
            lPrestamo.AutoSize = true;
            lFecha.AutoSize = true;
        }

        private void AplicarEscalado()
        {
            // ✅ Escalamos contra base del diseñador (NO MinimumSize)
            float proporcionAlto = (float)this.Height / TARJETA_BASE_H;
            float proporcionAncho = (float)this.Width / TARJETA_BASE_W;

            // límites razonables
            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            // Fuente suave
            CambiarFuentes(tlpPrincipal, escalaSuave);

            // Tamaño del panel del círculo
            int lado = (int)(ESTADO_BASE * escalaSuave);
            if (lado < ESTADO_MIN) lado = ESTADO_MIN;
            if (lado > ESTADO_MAX) lado = ESTADO_MAX;

            pEstado.Size = new Size(lado, lado);

            // Redibujo
            pEstado.Invalidate();
            tlpPrincipal.PerformLayout();
        }

        private void CambiarFuentes(Control c, float escala)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * escala,
                    control.Font.Style
                );

                CambiarFuentes(control, escala);
            }
        }

        private void pEstado_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int size = Math.Min(pEstado.Width, pEstado.Height) - (BORDE * 2);
            if (size < 6) size = 6;

            int x = (pEstado.Width - size) / 2;
            int y = (pEstado.Height - size) / 2;

            Rectangle r = new Rectangle(x, y, size, size);

            using (SolidBrush b = new SolidBrush(_colorEstado))
                e.Graphics.FillEllipse(b, r);

            using (Pen pen = new Pen(Color.DimGray, BORDE))
                e.Graphics.DrawEllipse(pen, r);
        }

        public void PonerDatos(Prestamo prestamo)
        {
            _prestamo = prestamo;

            string nombreUsuario = BibliotecaBBDD.GetNombreUsuario(prestamo.ID_Usuario);
            string nombreLibro = BibliotecaBBDD.GetTituloLibro(prestamo.ID_Libro);

            lPrestamo.Text = $"{nombreUsuario} - {nombreLibro}";
            lFecha.Text = prestamo.Fecha_Inicio.ToString("dd/MM/yyyy");

            DateTime hoy = DateTime.Today;

            if (prestamo.Devuelto)
                _colorEstado = Color.Gray;
            else if (prestamo.Fecha_Fin.HasValue && prestamo.Fecha_Fin.Value.Date < hoy)
                _colorEstado = Color.Red;
            else
                _colorEstado = Color.Green;

            pEstado.Invalidate();
        }

        private void Tarjeta_Click(object sender, EventArgs e)
        {
            if (_prestamo == null) return;

            DetallePrestamo detalle = new DetallePrestamo(_prestamo);
            if (detalle.ShowDialog() == DialogResult.OK)
            {
                PonerDatos(_prestamo);
            }
        }
    }
}
