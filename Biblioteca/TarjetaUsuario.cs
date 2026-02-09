using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using Biblioteca.VISTA;
using System;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        // Evento que notifica al formulario padre que el usuario fue borrado
        public event EventHandler<Usuario> UsuarioBorrado;

        // Instancia del detalle abierto
        private DetalleUsuario detalleAbierto = null;

        public TarjetaUsuario()
        {
            InitializeComponent();

            // Click en nombre o foto abre detalle
            lName.Click += lName_Click;
            userPhoto.Click += userPhoto_Click;

            // Cursor de mano opcional
            lName.Cursor = Cursors.Hand;
            userPhoto.Cursor = Cursors.Hand;

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
            if (_usuario == null) return;

            // Si ya hay un detalle abierto, lo traemos al frente
            if (detalleAbierto != null && !detalleAbierto.IsDisposed)
            {
                detalleAbierto.BringToFront();
                return;
            }

            detalleAbierto = new DetalleUsuario(_usuario);
            detalleAbierto.FormClosed += (s, e) => detalleAbierto = null; // Limpiamos la referencia al cerrar
            detalleAbierto.Show(); // Abrimos no modal
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (_usuario == null) return;
            UsuarioBorrado?.Invoke(this, _usuario);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}
