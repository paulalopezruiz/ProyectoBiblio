using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class DetalleLibros : Form
    {
        private Libro libro;

        public DetalleLibros()
        {
            InitializeComponent();
        }

        public DetalleLibros(Libro l) : this()
        {
            libro = l;

            label1.Text = libro.Titulo;
            label2.Text = libro.Escritor;
            label3.Text = libro.NEjemplares.ToString();

            CargarPortada();

            btnGuardar.Click += BtnGuardar_Click;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int id = libro.IdLibro;

            if (id <= 0)
                id = BibliotecaBBDD.GetIDLibro(libro.Titulo);

            listadoPrestamos frm = new listadoPrestamos(id);
            frm.ShowDialog();
        }

        

        private void CargarPortada()
        {
            if (libro.Portada == null || libro.Portada == "")
            {
                pictureBoxPortada.Image = null;
                return;
            }

            string ruta = Path.Combine(Application.StartupPath, libro.Portada);

            if (!File.Exists(ruta))
            {
                pictureBoxPortada.Image = null;
                return;
            }

            try
            {
                FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                pictureBoxPortada.Image = new Bitmap(fs);
                fs.Close();
            }
            catch
            {
                pictureBoxPortada.Image = null;
            }
        }
    }
}
