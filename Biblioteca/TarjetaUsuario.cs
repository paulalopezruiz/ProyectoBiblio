using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        public event EventHandler<Usuario> UsuarioBorrado;
        public event EventHandler UsuarioActualizado;

        private DetalleUsuario detalleAbierto = null;

        public TarjetaUsuario()
        {
            InitializeComponent();

            lName.Click += lName_Click;
            userPhoto.Click += userPhoto_Click;

            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;

            btnBorrar.Click += btnBorrar_Click;
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

        private void lName_Click(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        private void userPhoto_Click(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

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
