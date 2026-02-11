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

            // ✅ NO reconfiguramos columnas ni tamaños: dejamos el Designer tal cual (tus medidas base)
            // tlpPrincipal: 436x96
            // userPhoto: 84x44, margin 27,26,27,26
            // btnBorrar: 98x32, margin 20,32,20,32
            // lName: 134x96

            // UX
            lName.Click += lName_Click;
            userPhoto.Click += userPhoto_Click;

            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;

            btnBorrar.Click += btnBorrar_Click;

            // ✅ IMPORTANTE: no hacemos escalado interno en Resize
            // El tamaño lo controla listadoUsuarios (Width/Height de la tarjeta)
            // Dentro, Dock/Anchor ya centran todo.
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
