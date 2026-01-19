using System;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoUsuarios : Form
    {
        public Controlador Controlador { get; set; }   

        public listadoUsuarios()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario nuevo = NuevoUsuario.GetInstance();
            nuevo.Controlador = this.Controlador;

           
            nuevo.MdiParent = this.MdiParent;
            nuevo.Dock = DockStyle.Fill;

            
            this.Hide();

            nuevo.CargarDatos();
            nuevo.Show();
        }
    }
}
