using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Collections.Generic;
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

        // Panel del estado
        private const int ESTADO_BASE = 30;
        private const int ESTADO_MIN = 22;
        private const int ESTADO_MAX = 60;
        private const int BORDE = 1;

        // suavizado
        private const float SUAVIZADO = 0.60f;

        // Guardamos tamaños base reales de cada control
        private readonly Dictionary<Control, float> _fontBase = new Dictionary<Control, float>();

        public TarjetaPrestamo()
        {
            InitializeComponent();

            PrepararLayout();

            GuardarFuentesBase(this);

            pEstado.Paint += pEstado_Paint;

            this.Click += Tarjeta_Click;
            foreach (Control c in this.Controls)
                c.Click += Tarjeta_Click;

            this.HandleCreated += (s, e) =>
            {
                mostrado = true;
                HookResizeDelFormPadre();
                AplicarEscalado();
            };

            this.ParentChanged += (s, e) =>
            {
                if (!mostrado) return;
                HookResizeDelFormPadre();
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
            pEstado.Dock = DockStyle.None;
            pEstado.Anchor = AnchorStyles.None;
            pEstado.Margin = new Padding(10);
            pEstado.BackColor = Color.Transparent;
            pEstado.Size = new Size(ESTADO_BASE, ESTADO_BASE);

            lPrestamo.AutoSize = true;
            lFecha.AutoSize = true;
        }

        private void GuardarFuentesBase(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (!_fontBase.ContainsKey(c))
                    _fontBase[c] = c.Font.Size;

                GuardarFuentesBase(c);
            }
        }

        private void HookResizeDelFormPadre()
        {
            Form f = this.FindForm();
            if (f == null) return;

            f.Resize -= FormPadre_Resize;
            f.Resize += FormPadre_Resize;
        }

        private void FormPadre_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            AplicarEscalado();
        }

        private void AplicarEscalado()
        {
            Form f = this.FindForm();
            if (f == null) return;

            // ✅ Proporción respecto al tamaño mínimo del form (como tu listadoPrestamos)
            float baseW = f.MinimumSize.Width;
            float baseH = f.MinimumSize.Height;

            if (baseW <= 0 || baseH <= 0) return;

            float proporcionAncho = (float)f.ClientSize.Width / baseW;
            float proporcionAlto = (float)f.ClientSize.Height / baseH;

            // límites razonables
            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            if (proporcionAlto < 0.6f) proporcionAlto = 0.6f;
            if (proporcionAncho < 0.6f) proporcionAncho = 0.6f;

            // ✅ Escala proporcional al alto/ancho (promedio, no min)
            float escala = (proporcionAlto + proporcionAncho) / 2f;

            // suavizado (para que suba suave)
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            CambiarFuentesDesdeBase(this, escalaSuave);

            int lado = (int)(ESTADO_BASE * escalaSuave);
            if (lado < ESTADO_MIN) lado = ESTADO_MIN;
            if (lado > ESTADO_MAX) lado = ESTADO_MAX;

            pEstado.Size = new Size(lado, lado);

            pEstado.Invalidate();
            tlpPrincipal.PerformLayout();
        }

        private void CambiarFuentesDesdeBase(Control parent, float escala)
        {
            foreach (Control c in parent.Controls)
            {
                if (_fontBase.ContainsKey(c))
                {
                    float baseSize = _fontBase[c];
                    c.Font = new Font(c.Font.FontFamily, baseSize * escala, c.Font.Style);
                }

                CambiarFuentesDesdeBase(c, escala);
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
