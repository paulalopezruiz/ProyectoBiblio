using System;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class Home : Form
    {
        public event Action<Form> CambiarFormulario;
        private Controlador controlador;

        private bool mostrado = false;

        private const int BASE_W = 800;
        private const int BASE_H = 450;

        private const float FONT_SIZE = 11.0f;

        private const int PADDING_LR = 10;
        private const int PADDING_TB = 9;

        private const int MARGIN_LR = 30;
        private const int MARGIN_TB = 0;

        private const int ICON_W = 100;
        private const int ICON_H = 64;

        public Home()
        {
            InitializeComponent();
            controlador = new Controlador();
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            Escalar(); 
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            Escalar();
        }

        private void Escalar()
        {
            
            float proporcionAlto = (float)this.Height / BASE_H;
            float proporcionAncho = (float)this.Width / BASE_W;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            // Fuente (altura de letra)
            cambiarFuentes(tlpHome, proporcionAlto);

            // Padding tarjetas
            Padding paddingTarjeta = new Padding(
                (int)(PADDING_LR * proporcionAncho),
                (int)(PADDING_TB * proporcionAlto),
                (int)(PADDING_LR * proporcionAncho),
                (int)(PADDING_TB * proporcionAlto)
            );

            pUser.Padding = paddingTarjeta;
            pLibros.Padding = paddingTarjeta;
            pPrest.Padding = paddingTarjeta;

            // Margen tarjetas
            Padding marginTarjeta = new Padding(
                (int)(MARGIN_LR * proporcionAncho),
                (int)(MARGIN_TB * proporcionAlto),
                (int)(MARGIN_LR * proporcionAncho),
                (int)(MARGIN_TB * proporcionAlto)
            );

            pUser.Margin = marginTarjeta;
            pLibros.Margin = marginTarjeta;
            pPrest.Margin = marginTarjeta;

            // Iconos
            userIcon.Size = new Size((int)(ICON_W * proporcionAncho), (int)(ICON_H * proporcionAlto));
            bookIcon.Size = new Size((int)(ICON_W * proporcionAncho), (int)(ICON_H * proporcionAlto));
            PrestIcon.Size = new Size((int)(ICON_W * proporcionAncho), (int)(ICON_H * proporcionAlto));
        }

        private void cambiarFuentes(Control c, float proporcionAlto)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * proporcionAlto,
                    control.Font.Style
                );

                cambiarFuentes(control, proporcionAlto);
            }
        }

        private void panelTarjeta_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3;
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
            CambiarFormulario?.Invoke(new listadoUsuarios(controlador));
        }

        private void pLibros_Click(object sender, EventArgs e)
        {
            CambiarFormulario?.Invoke(new listadoLibros(controlador));
        }

        private void pPrestamos_Click(object sender, EventArgs e)
        {
            CambiarFormulario?.Invoke(new listadoPrestamos(controlador));
        }

    }
}
