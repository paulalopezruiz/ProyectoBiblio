using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        public List<Usuario> listaUsuarios = new List<Usuario>
        {
            new Usuario("Juan Pérez", "123456789", "11111111A"),
            new Usuario("María García", "987654321", "22222222B"),
            new Usuario("Carlos López", "654987321", "33333333C"),
            new Usuario("Ana Martínez", "789456123", "44444444D"),
            new Usuario("Lucía Sánchez", "321654987", "55555555E"),
            new Usuario("Pedro Fernández", "147258369", "66666666F"),
            new Usuario("Laura Gómez", "963852741", "77777777G"),
            new Usuario("Diego Ruiz", "852741963", "88888888H"),
            new Usuario("Sara Torres", "741963852", "99999999J"),
            new Usuario("Javier Navarro", "159357258", "00000000K")
        };

        public listadoUsuarios()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void listadoUsuarios_Load(object sender, EventArgs e)
        {
            CargarTarjetas(listaUsuarios);
        }

        private void CargarTarjetas(List<Usuario> usuarios)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var u in usuarios)
            {
                TarjetaUsuario tarjeta = new TarjetaUsuario();

                tarjeta.Usuario = u;
                tarjeta.Width = flowLayoutPanel1.ClientSize.Width - 20;

                //ESCUCHAMOS EL EVENTO DE BORRAR
                tarjeta.UsuarioBorrado += Tarjeta_UsuarioBorrado;

                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }
        private void Tarjeta_UsuarioBorrado(object sender, Usuario usuario)
        {
            listaUsuarios.Remove(usuario);
            CargarTarjetas(listaUsuarios);
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario frm = new NuevoUsuario();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Añadir el usuario creado
                listaUsuarios.Add(frm.UsuarioCreado);

                // Recargar tarjetas
                CargarTarjetas(listaUsuarios);
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            string texto = tbNombre.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(texto))
            {
                CargarTarjetas(listaUsuarios);
                return;
            }

            var filtrados = listaUsuarios
                .Where(u => u.Nombre.ToLower().StartsWith(texto))
                .ToList();

            CargarTarjetas(filtrados);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
