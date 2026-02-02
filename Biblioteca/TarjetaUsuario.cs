using System;
using System.Windows.Forms;
using Biblioteca.MODELO;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        // Evento para avisar al formulario
        public event EventHandler<Usuario> UsuarioBorrado;

        public TarjetaUsuario()
        {
            InitializeComponent();
        }

        public Usuario Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                lName.Text = value.Nombre;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
                $"¿Seguro que quieres borrar a {_usuario.Nombre}?",
                "Confirmar borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmar == DialogResult.Yes)
            {
                UsuarioBorrado?.Invoke(this, _usuario);
            }
        }

        private void lName_Click(object sender, EventArgs e) { }
    }
}
