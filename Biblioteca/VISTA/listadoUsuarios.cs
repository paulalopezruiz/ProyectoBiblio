using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        private readonly Controlador controlador;

        private bool mostrado = false;

        private const float FONT_SIZE = 9.0f;

        // Tarjetas
        private const int TARJETA_H_BASE = 96;
        private const float SUAVIZADO = 0.60f;

        // Cabecera (fila 0)
        private const int HEADER_BASE_HEIGHT = 90;  // base en tu MinimumSize
        private const int HEADER_MIN = 80;
        private const int HEADER_MAX = 160;

        // Botón Nuevo (tamaño base del diseñador: 127x29)
        private const int BTN_W_BASE = 127;
        private const int BTN_H_BASE = 29;

        public listadoUsuarios(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            // ✅ CLAVE 1: el AutoSize del tlpPrincipal es lo que rompe el layout
            tlpPrincipal.AutoSize = false;
            tlpPrincipal.AutoSizeMode = AutoSizeMode.GrowOnly;

            // ✅ CLAVE 2: el botón no debe AutoSize si quieres controlarlo
            btnNuevo.AutoSize = false;

            // ✅ Mejor comportamiento visual
            btnNuevo.Anchor = AnchorStyles.None;     // centrado en su celda
            btnNuevo.Dock = DockStyle.None;

            // ✅ margen base normal (el margen "bonito" lo ajustamos en Escalado)
            btnNuevo.Margin = new Padding(10);

            this.Activated += listadoUsuarios_Activated;
            this.Resize += listadoUsuarios_Resize;
        }

        private void listadoUsuarios_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
            AjustarTamanoTarjetas();
        }

        private void listadoUsuarios_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;

            AplicarEscalado();
            AjustarTamanoTarjetas();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            // 1) Fuentes (por alto)
            cambiarFuentes(tlpPrincipal, proporcionAlto);

            // 2) Fijar fila 0 (cabecera) a ABSOLUTE escalable => evita que se corte/desaparezca
            int headerH = (int)(HEADER_BASE_HEIGHT * proporcionAlto);
            if (headerH < HEADER_MIN) headerH = HEADER_MIN;
            if (headerH > HEADER_MAX) headerH = HEADER_MAX;

            if (tlpPrincipal.RowStyles.Count > 0)
            {
                tlpPrincipal.RowStyles[0].SizeType = SizeType.Absolute;
                tlpPrincipal.RowStyles[0].Height = headerH;
            }

            // 3) Tamaño del botón
            int btnW = (int)(BTN_W_BASE * proporcionAncho);
            int btnH = (int)(BTN_H_BASE * proporcionAlto);

            if (btnW < BTN_W_BASE) btnW = BTN_W_BASE;
            if (btnH < BTN_H_BASE) btnH = BTN_H_BASE;

            // límites para que no quede ridículo
            if (btnW > 260) btnW = 260;
            if (btnH > 70) btnH = 70;

            btnNuevo.Size = new Size(btnW, btnH);

            // margen derecho extra para que no se pegue al borde al crecer
            int padDerecha = (int)(30 * proporcionAncho);  // ajusta 30 si quieres más/menos aire
            if (padDerecha < 30) padDerecha = 30;
            if (padDerecha > 120) padDerecha = 120;

            btnNuevo.Margin = new Padding(10, 10, padDerecha, 10);

            btnNuevo.Visible = true;
            btnNuevo.BringToFront();

            tlpPrincipal.PerformLayout();
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

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            CargarTarjetas(controlador.ObtenerUsuarios());
            AjustarTamanoTarjetas();
        }

        private void AjustarTamanoTarjetas()
        {
            int ancho = flowListado.ClientSize.Width - 20;
            if (ancho < 220) ancho = 220;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            int altoTarjeta = (int)(TARJETA_H_BASE * escalaSuave);

            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE;
            if (altoTarjeta > TARJETA_H_BASE * 2) altoTarjeta = TARJETA_H_BASE * 2;

            foreach (Control c in flowListado.Controls)
            {
                if (c is TarjetaUsuario tu)
                {
                    tu.Width = ancho;
                    tu.Height = altoTarjeta;
                }
            }
        }

        private void CargarTarjetas(List<Usuario> usuarios)
        {
            foreach (Control c in flowListado.Controls)
            {
                if (c is TarjetaUsuario tu)
                {
                    tu.UsuarioBorrado -= Tarjeta_UsuarioBorrado;
                    tu.UsuarioActualizado -= Tarjeta_UsuarioActualizado;
                    tu.Dispose();
                }
            }
            flowListado.Controls.Clear();

            int ancho = flowListado.ClientSize.Width - 20;
            if (ancho < 220) ancho = 220;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            int altoTarjeta = (int)(TARJETA_H_BASE * escalaSuave);
            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE;
            if (altoTarjeta > TARJETA_H_BASE * 2) altoTarjeta = TARJETA_H_BASE * 2;

            foreach (var u in usuarios)
            {
                TarjetaUsuario tarjeta = new TarjetaUsuario
                {
                    Usuario = u,
                    Width = ancho,
                    Height = altoTarjeta
                };

                tarjeta.UsuarioBorrado += Tarjeta_UsuarioBorrado;
                tarjeta.UsuarioActualizado += Tarjeta_UsuarioActualizado;

                flowListado.Controls.Add(tarjeta);
            }
        }

        private void Tarjeta_UsuarioActualizado(object sender, EventArgs e)
        {
            CargarTarjetas(controlador.ObtenerUsuarios());
            AjustarTamanoTarjetas();
        }

        private void Tarjeta_UsuarioBorrado(object sender, Usuario usuario)
        {
            if (usuario == null) return;

            var resp = MessageBox.Show(
                $"¿Estás seguro de que quieres borrar a {usuario.Nombre} permanentemente?",
                "Confirmar borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resp != DialogResult.Yes) return;

            try
            {
                controlador.BorrarUsuario(usuario.DNI);
                CargarTarjetas(controlador.ObtenerUsuarios());
                AjustarTamanoTarjetas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error borrando usuario",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario frm = new NuevoUsuario(controlador);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarTarjetas(controlador.ObtenerUsuarios());
                AjustarTamanoTarjetas();
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            string texto = tbNombre.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                CargarTarjetas(controlador.ObtenerUsuarios());
                AjustarTamanoTarjetas();
                return;
            }

            try
            {
                CargarTarjetas(controlador.BuscarUsuariosPorNombre(texto));
                AjustarTamanoTarjetas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error buscando",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
