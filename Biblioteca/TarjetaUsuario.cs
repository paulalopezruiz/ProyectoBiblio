using System;
using System.Windows.Forms;
using Biblioteca.MODELO;
using Biblioteca.VISTA;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        public event EventHandler<Usuario> UsuarioBorrado;


        public TarjetaUsuario()
        {
            InitializeComponent();

            // Hacemos clicable el icono (PictureBox)
            userPhoto.Click += userPhoto_Click;

            // (Opcional) cursor de mano
            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                lName.Text = value.Nombre;
            }
        }

        // Click en el NOMBRE (asegúrate que está conectado en el diseñador)
        private void lName_Click(object sender, EventArgs e)
        {
            AbrirDetalle();
        }

        // Click en el ICONO
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

            DetalleUsuario frm = new DetalleUsuario(_usuario);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
