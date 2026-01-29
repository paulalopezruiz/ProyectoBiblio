using System;
using System.Windows.Forms;
using Biblioteca.MODELO;  

namespace Biblioteca
{
    public partial class TarjetaUsuario : UserControl
    {
        private Usuario _usuario;

        public TarjetaUsuario()
        {
            InitializeComponent();
        }

        // Propiedad que guarda el usuario completo
        public Usuario Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                lName.Text = value.Nombre;   // Solo mostramos el nombre
            }
        }

        private void lName_Click(object sender, EventArgs e)
        {

        }
    }
}
