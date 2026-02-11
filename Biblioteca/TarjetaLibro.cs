using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class TarjetaLibro : UserControl
    {
        private Panel indicadorDisponibilidad;

        public event EventHandler PortadaClick;

        public TarjetaLibro()
        {
            InitializeComponent();
            CrearIndicadorDisponibilidad();

            pictureBoxPortada.Cursor = Cursors.Hand;
            this.Layout += (s, e) => indicadorDisponibilidad?.BringToFront();
        }

        private bool disponible;
        public bool Disponible
        {
            get => disponible;
            set
            {
                disponible = value;
                ActualizarIndicador();
            }
        }

        private void CrearIndicadorDisponibilidad()
        {
            indicadorDisponibilidad = new Panel
            {
                Size = new Size(20, 20),  
                BackColor = Color.Gray,
                Location = new Point(5, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            indicadorDisponibilidad.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddEllipse(0, 0, indicadorDisponibilidad.Width - 1, indicadorDisponibilidad.Height - 1);
                    indicadorDisponibilidad.Region = new Region(gp);
                }
            };

            this.Controls.Add(indicadorDisponibilidad);
            indicadorDisponibilidad.BringToFront();
        }

        private void ActualizarIndicador()
        {
            indicadorDisponibilidad.BackColor = disponible ? Color.Green : Color.Red;
            indicadorDisponibilidad.Invalidate();
        }

        public Image Portada
        {
            get => pictureBoxPortada.Image;
            set => pictureBoxPortada.Image = value;
        }

        public Button BotonBorrar => btnBorrar;

        private void pictureBoxPortada_Click(object sender, EventArgs e)
        {
            PortadaClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
