using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        public event EventHandler<Usuario> UsuarioBorrado;
        public event EventHandler UsuarioActualizado;

        private DetalleUsuario detalleAbierto = null;

        private bool mostrado = false;

        // Fuente base (un pelín más grande)
        private const float FONT_SIZE = 9.5f;

        // Tamaños base
        private const int ICON_W_BASE = 91;
        private const int ICON_H_BASE = 44;

        private const int BTN_W_BASE = 106;
        private const int BTN_H_BASE = 32;

        // ✅ Suavizado y factores (subidos un poco)
        private const float SUAVIZADO = 0.70f;
        private const float ICON_FACTOR = 0.78f;
        private const float BTN_FACTOR = 0.78f;

        // Márgenes base (pequeños)
        private const int ICON_MARGIN_LR_BASE = 8;
        private const int ICON_MARGIN_TB_BASE = 6;

        private const int BTN_MARGIN_LR_BASE = 8;
        private const int BTN_MARGIN_TB_BASE = 6;

        // Separación horizontal
        private const int GAP_BASE = 100;

        public TarjetaUsuario()
        {
            InitializeComponent();

            tlpPrincipal.SuspendLayout();

            tlpPrincipal.ColumnStyles.Clear();
            tlpPrincipal.ColumnCount = 4;

            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // icono
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // nombre
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // botón
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F)); // relleno

            tlpPrincipal.Controls.Remove(userPhoto);
            tlpPrincipal.Controls.Remove(lName);
            tlpPrincipal.Controls.Remove(btnBorrar);

            tlpPrincipal.Controls.Add(userPhoto, 0, 0);
            tlpPrincipal.Controls.Add(lName, 1, 0);
            tlpPrincipal.Controls.Add(btnBorrar, 2, 0);

            lName.AutoSize = true;
            lName.Dock = DockStyle.None;
            lName.Anchor = AnchorStyles.Left;
            lName.TextAlign = ContentAlignment.MiddleLeft;

            userPhoto.Dock = DockStyle.None;
            btnBorrar.Dock = DockStyle.None;

            userPhoto.Anchor = AnchorStyles.None;
            btnBorrar.Anchor = AnchorStyles.None;

            userPhoto.SizeMode = PictureBoxSizeMode.Zoom;

            tlpPrincipal.ResumeLayout(true);

            lName.Click += lName_Click;
            userPhoto.Click += userPhoto_Click;

            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;

            btnBorrar.Click += btnBorrar_Click;

            this.HandleCreated += (s, e) =>
            {
                mostrado = true;

                if (this.MinimumSize.Width == 0 || this.MinimumSize.Height == 0)
                    this.MinimumSize = this.Size;

                AplicarEscalado();
            };

            this.Resize += (s, e) =>
            {
                if (!mostrado) return;
                AplicarEscalado();
            };
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            cambiarFuentes(tlpPrincipal, escalaSuave);

            int iconW = (int)(ICON_W_BASE * escalaSuave * ICON_FACTOR);
            int iconH = (int)(ICON_H_BASE * escalaSuave * ICON_FACTOR);

            int btnW = (int)(BTN_W_BASE * escalaSuave * BTN_FACTOR);
            int btnH = (int)(BTN_H_BASE * escalaSuave * BTN_FACTOR);

            // límites (un poco más altos también, por si te quedaba corto)
            if (iconW > 140) iconW = 140;
            if (iconH > 85) iconH = 85;

            if (btnW > 160) btnW = 160;
            if (btnH > 65) btnH = 65;

            userPhoto.Size = new Size(iconW, iconH);
            btnBorrar.Size = new Size(btnW, btnH);

            int maxTb = Math.Max(2, this.Height / 6);

            int iconTb = Math.Min((int)(ICON_MARGIN_TB_BASE * escalaSuave), maxTb);
            int iconLr = (int)(ICON_MARGIN_LR_BASE * escalaSuave);

            int btnTb = Math.Min((int)(BTN_MARGIN_TB_BASE * escalaSuave), maxTb);
            int btnLr = (int)(BTN_MARGIN_LR_BASE * escalaSuave);

            int gap = (int)(GAP_BASE * escalaSuave);

            userPhoto.Margin = new Padding(iconLr, iconTb, iconLr + gap, iconTb);
            lName.Margin = new Padding(0, 0, gap, 0);
            btnBorrar.Margin = new Padding(btnLr, btnTb, btnLr, btnTb);

            tlpPrincipal.PerformLayout();
        }

        private void cambiarFuentes(Control c, float escala)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * escala,
                    control.Font.Style
                );

                cambiarFuentes(control, escala);
            }
        }

        public Usuario Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                if (value != null)
                    lName.Text = value.Nombre;
            }
        }

        private void lName_Click(object sender, EventArgs e) => AbrirDetalle();
        private void userPhoto_Click(object sender, EventArgs e) => AbrirDetalle();

        private void AbrirDetalle()
        {
            if (_usuario == null) return;

            if (detalleAbierto != null && !detalleAbierto.IsDisposed)
            {
                detalleAbierto.BringToFront();
                return;
            }

            detalleAbierto = new DetalleUsuario(_usuario);

            detalleAbierto.FormClosed += (s, args) =>
            {
                detalleAbierto = null;
                UsuarioActualizado?.Invoke(this, EventArgs.Empty);
            };

            detalleAbierto.Show();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (_usuario == null) return;
            UsuarioBorrado?.Invoke(this, _usuario);
        }
    }
}
