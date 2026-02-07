using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class TarjetaLibro : UserControl
    {
        private Panel indicadorDisponibilidad;

        // ✅ Evento público para click en portada
        public event EventHandler PortadaClick;

        public TarjetaLibro()
        {
            InitializeComponent();
            CrearIndicadorDisponibilidad();

            // opcional (mejor UX)
            pictureBoxPortada.Cursor = Cursors.Hand;
        }

        // Propiedad para actualizar el círculo según disponibilidad
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

        // Crear el panel circular
        private void CrearIndicadorDisponibilidad()
        {
            indicadorDisponibilidad = new Panel
            {
                Size = new Size(20, 20),
                BackColor = Color.Gray,
                Location = new Point(5, 5),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Redondear el panel
            indicadorDisponibilidad.Paint += (s, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddEllipse(0, 0, indicadorDisponibilidad.Width - 1, indicadorDisponibilidad.Height - 1);
                indicadorDisponibilidad.Region = new Region(gp);
            };

            this.Controls.Add(indicadorDisponibilidad);
            indicadorDisponibilidad.BringToFront();
        }

        private void ActualizarIndicador()
        {
            indicadorDisponibilidad.BackColor = disponible ? Color.Green : Color.Red;
        }

        // Propiedad para la portada
        public Image Portada
        {
            get => pictureBoxPortada.Image;
            set => pictureBoxPortada.Image = value;
        }

        // Botón borrar público
        public Button BotonBorrar => btnBorrar;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        // ✅ Disparar evento al hacer click
        private void pictureBoxPortada_Click(object sender, EventArgs e)
        {
            PortadaClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
