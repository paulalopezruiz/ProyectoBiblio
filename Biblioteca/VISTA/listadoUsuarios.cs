using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        private Controlador controlador;

        public listadoUsuarios(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;
            this.AutoScroll = true;
            Load += listadoUsuarios_Load;
        }

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            CargarTarjetas(controlador.ObtenerUsuarios());
        }

        private void CargarTarjetas(List<Usuario> usuarios)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is TarjetaUsuario tu)
                {
                    tu.UsuarioBorrado -= Tarjeta_UsuarioBorrado;
                    tu.Dispose();
                }
            }
            flowLayoutPanel1.Controls.Clear();

            foreach (var u in usuarios)
            {
                TarjetaUsuario tarjeta = new TarjetaUsuario
                {
                    Usuario = u,
                    Width = flowLayoutPanel1.ClientSize.Width - 20
                };

                tarjeta.UsuarioBorrado += Tarjeta_UsuarioBorrado;
                flowLayoutPanel1.Controls.Add(tarjeta);
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error borrando usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario frm = new NuevoUsuario(controlador);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarTarjetas(controlador.ObtenerUsuarios());
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            string texto = tbNombre.Text.Trim();
            if (string.IsNullOrEmpty(texto))
            {
                CargarTarjetas(controlador.ObtenerUsuarios());
                return;
            }

            try
            {
                CargarTarjetas(controlador.BuscarUsuariosPorNombre(texto));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error buscando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
