using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        // Evento que notifica al formulario padre que el usuario fue borrado
        public event EventHandler<Usuario> UsuarioBorrado;

        public TarjetaUsuario()
        {
            InitializeComponent();

            // Click en nombre o foto abre detalle
            lName.Click += lName_Click;
            userPhoto.Click += userPhoto_Click;

            // Cursor de mano opcional
            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;

            // NOTA: No suscribimos el evento de borrar aquí, lo harás desde el formulario padre
            btnBorrar.Click += btnBorrar_Click;
        }

        public Usuario Usuario
        {
            get { return _usuario; }
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
            if (_usuario == null)
            {
                MessageBox.Show("No hay usuario en esta tarjeta.");
                return;
            }

            using (DetalleUsuario frm = new DetalleUsuario(_usuario))
            {
                frm.ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (_usuario == null) return;

            // Dispara el evento, la lógica de borrar se hará en el formulario padre
            UsuarioBorrado?.Invoke(this, _usuario);
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
