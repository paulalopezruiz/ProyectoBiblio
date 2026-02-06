using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class listadoLibros : Form
    {
        private List<Libro> listaLibros;

        public listadoLibros()
        {
            InitializeComponent();
            Load += listadoLibros_Load;
        }

        private void listadoLibros_Load(object sender, EventArgs e)
        {
            // Aquí cargas los libros desde la BD
            // (este método lo tendrás en tu DAO)
            listaLibros = BibliotecaBBDD.GetLibros();

            RellenarComboTitulos();
            RellenarComboAutores();
        }

        private void RellenarComboTitulos()
        {
            cbTitulos.Items.Clear();
            cbTitulos.Items.Add("Todos");

            foreach (Libro libro in listaLibros)
            {
                if (!cbTitulos.Items.Contains(libro.Titulo))
                {
                    cbTitulos.Items.Add(libro.Titulo);
                }
            }

            cbTitulos.SelectedIndex = 0;
        }

        private void RellenarComboAutores()
        {
            cbAutores.Items.Clear();
            cbAutores.Items.Add("Todos");

            foreach (Libro libro in listaLibros)
            {
                if (!cbAutores.Items.Contains(libro.Escritor))
                {
                    cbAutores.Items.Add(libro.Escritor);
                }
            }

            cbAutores.SelectedIndex = 0;
        }

        private void flpLibros_Paint(object sender, PaintEventArgs e)
        {
            // De momento vacío
        }
    }
}
