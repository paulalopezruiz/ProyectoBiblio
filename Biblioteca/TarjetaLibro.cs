using System;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca
{
    public partial class TarjetaLibro : UserControl
    {
        public TarjetaLibro()
        {
            InitializeComponent();
            this.BackColor = Color.White; // fondo blanco de la tarjeta
        }

        // Propiedad pública para asignar la portada
        public Image Portada
        {
            get { return pictureBoxPortada.Image; }
            set
            {
                pictureBoxPortada.Image = value;
                if (value == null)
                    pictureBoxPortada.BackColor = Color.LightGray; // gris si no hay imagen
                else
                    pictureBoxPortada.BackColor = Color.White;
            }
        }

        // Propiedad pública para acceder al botón borrar
        public Button BotonBorrar
        {
            get { return btnBorrar; }
        }
    }
}
