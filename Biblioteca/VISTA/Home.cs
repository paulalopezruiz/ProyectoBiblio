using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        private void panelTarjeta_Paint(object sender, PaintEventArgs e)
        {
            int grosor = 3; // grosor del borde
            Color colorBorde = Color.Black;

            Control c = (Control)sender;
            using (Pen pen = new Pen(colorBorde, grosor))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
            }
        }

        private void pUser_Click(object sender, EventArgs e)
        {
            new listadoUsuarios().Show();


        }

        private void pLibros_Click(object sender, EventArgs e)
        {

        }
    }
}
