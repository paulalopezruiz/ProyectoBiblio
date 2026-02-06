using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            listaLibros = BibliotecaBBDD.GetLibros();

            RellenarComboTitulos();
            RellenarComboAutores();

            ConfigurarFlowPanel();
            CargarTarjetas();
        }

        private void RellenarComboTitulos()
        {
            cbTitulos.Items.Clear();
            cbTitulos.Items.Add("Todos");

            foreach (Libro libro in listaLibros)
            {
                if (!cbTitulos.Items.Contains(libro.Titulo))
                    cbTitulos.Items.Add(libro.Titulo);
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
                    cbAutores.Items.Add(libro.Escritor);
            }

            cbAutores.SelectedIndex = 0;
        }

        private void ConfigurarFlowPanel()
        {
            flpLibros.FlowDirection = FlowDirection.LeftToRight;
            flpLibros.WrapContents = true;
            flpLibros.AutoScroll = true;
            flpLibros.BackColor = Color.White;

            // Centrar tarjetas y definir margen
            flpLibros.Padding = new Padding(20, 20, 20, 20);
            flpLibros.Margin = new Padding(0);
        }

        private void CargarTarjetas()
        {
            flpLibros.Controls.Clear();

            int tarjetasPorFila = 2;
            int margen = 10;

            foreach (Libro libro in listaLibros)
            {
                TarjetaLibro tarjeta = new TarjetaLibro();
                tarjeta.Width = 150;
                tarjeta.Height = 200;
                tarjeta.Margin = new Padding(margen);

                // Reducir el botón de borrar
                tarjeta.BotonBorrar.Width = 80;
                tarjeta.BotonBorrar.Height = 25;
                tarjeta.BotonBorrar.Anchor = AnchorStyles.None;

                // Imagen
                try
                {
                    if (!string.IsNullOrEmpty(libro.Portada))
                    {
                        string rutaImagen = Path.Combine(Application.StartupPath, libro.Portada);
                        if (File.Exists(rutaImagen))
                            tarjeta.Portada = Image.FromFile(rutaImagen);
                        else
                            tarjeta.Portada = null;
                    }
                    else
                    {
                        tarjeta.Portada = null;
                    }
                }
                catch
                {
                    tarjeta.Portada = null;
                }

                // Evento borrar
                tarjeta.BotonBorrar.Click += (s, e) =>
                {
                    MessageBox.Show($"Se borraría el libro: {libro.Titulo}");
                };

                flpLibros.Controls.Add(tarjeta);
            }

            AjustarColumnas(tarjetasPorFila, 150, margen);
        }


        private void AjustarColumnas(int tarjetasPorFila, int anchoTarjeta, int margen)
        {
            int panelWidth = flpLibros.ClientSize.Width;
            int espacioTotal = tarjetasPorFila * (anchoTarjeta + 2 * margen);
            int margenIzq = (panelWidth - espacioTotal) / 2;
            if (margenIzq < 0) margenIzq = 0;

            flpLibros.Padding = new Padding(margenIzq, 20, 20, 20);
        }

        private void flpLibros_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
