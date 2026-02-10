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
        private Controlador controlador;

        private bool mostrado = false;

        private const float FONT_SIZE = 9.0f;

        // Márgenes base del diseñador (ajusta si los cambias)
        private const int FILTRO_MARGIN_BASE = 20;
        private const int BTN_MARGIN_LR_BASE = 45;
        private const int BTN_MARGIN_TB_BASE = 47;

        // Altura base de la tarjeta (tu UserControl base)
        private const int TARJETA_H_BASE = 96;

        public listadoUsuarios(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

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
            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;   // 533x288 base
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            cambiarFuentes(tlpPrincipal, proporcionAlto);

            // Márgenes
            tlpFiltro.Margin = new Padding(
                (int)(FILTRO_MARGIN_BASE * proporcionAncho),
                (int)(FILTRO_MARGIN_BASE * proporcionAlto),
                (int)(FILTRO_MARGIN_BASE * proporcionAncho),
                (int)(FILTRO_MARGIN_BASE * proporcionAlto)
            );

            btnNuevo.Margin = new Padding(
                (int)(BTN_MARGIN_LR_BASE * proporcionAncho),
                (int)(BTN_MARGIN_TB_BASE * proporcionAlto),
                (int)(BTN_MARGIN_LR_BASE * proporcionAncho),
                (int)(BTN_MARGIN_TB_BASE * proporcionAlto)
            );

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
            // Ancho (como ya hacías)
            int ancho = flowListado.ClientSize.Width - 20;
            if (ancho < 200) ancho = 200;

            // Escala para altura de tarjeta
            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            if (proporcionAlto > 3f) proporcionAlto = 3f;

            int altoTarjeta = (int)(TARJETA_H_BASE * proporcionAlto);
            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE; // nunca menos que base

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
            if (ancho < 200) ancho = 200;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            if (proporcionAlto > 3f) proporcionAlto = 3f;

            int altoTarjeta = (int)(TARJETA_H_BASE * proporcionAlto);
            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE;

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
