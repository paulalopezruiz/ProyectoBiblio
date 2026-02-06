using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

            // Suscribir eventos de filtrado
            cbTitulos.SelectedIndexChanged += FiltrarLibros;
            cbAutores.SelectedIndexChanged += FiltrarLibros;
            cbDisponible.CheckedChanged += FiltrarLibros;
        }

        private void listadoLibros_Load(object sender, EventArgs e)
        {
            listaLibros = BibliotecaBBDD.GetLibros();

            RellenarComboTitulos();
            RellenarComboAutores();

            ConfigurarFlowPanel();
            CargarTarjetas(listaLibros); // carga inicial con todos los libros
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

        private void CargarTarjetas(List<Libro> librosFiltrados)
        {
            flpLibros.Controls.Clear();

            int tarjetasPorFila = 2;
            int margen = 10;

            foreach (Libro libro in librosFiltrados)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(margen),
                    Disponible = libro.Disponible // actualizamos círculo
                };

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

                // Evento borrar (temporal)
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

        // =========================================
        // Filtrado por ComboBox y CheckBox
        // =========================================
        private void FiltrarLibros(object sender, EventArgs e)
        {
            var filtrados = listaLibros.AsEnumerable();

            // Filtrar por título
            if (cbTitulos.SelectedIndex > 0)
            {
                string titulo = cbTitulos.SelectedItem.ToString();
                filtrados = filtrados.Where(l => l.Titulo == titulo);
            }

            // Filtrar por autor
            if (cbAutores.SelectedIndex > 0)
            {
                string autor = cbAutores.SelectedItem.ToString();
                filtrados = filtrados.Where(l => l.Escritor == autor);
            }

            // Filtrar por disponibilidad
            if (cbDisponible.Checked)
            {
                filtrados = filtrados.Where(l => l.Disponible);
            }

            CargarTarjetas(filtrados.ToList());
        }

        private void flpLibros_Paint(object sender, PaintEventArgs e) { }
    }
}
