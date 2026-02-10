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
        private Controlador controlador;

        public listadoLibros(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            Load += listadoLibros_Load;
            cbTitulos.SelectedIndexChanged += FiltrarLibros;
            cbAutores.SelectedIndexChanged += FiltrarLibros;
            cbDisponible.CheckedChanged += FiltrarLibros;
        }

        private void listadoLibros_Load(object sender, EventArgs e)
        {
            listaLibros = controlador.ObtenerLibros();

            RellenarComboTitulos();
            RellenarComboAutores();
            ConfigurarFlowPanel();
            CargarTarjetas(listaLibros);
        }

        private void RellenarComboTitulos()
        {
            cbTitulos.Items.Clear();
            cbTitulos.Items.Add("Todos");
            foreach (Libro libro in listaLibros)
                if (!cbTitulos.Items.Contains(libro.Titulo))
                    cbTitulos.Items.Add(libro.Titulo);
            cbTitulos.SelectedIndex = 0;
        }

        private void RellenarComboAutores()
        {
            cbAutores.Items.Clear();
            cbAutores.Items.Add("Todos");
            foreach (Libro libro in listaLibros)
                if (!cbAutores.Items.Contains(libro.Escritor))
                    cbAutores.Items.Add(libro.Escritor);
            cbAutores.SelectedIndex = 0;
        }

        private void ConfigurarFlowPanel()
        {
            flpLibros.FlowDirection = FlowDirection.LeftToRight;
            flpLibros.WrapContents = true;
            flpLibros.AutoScroll = true;
            flpLibros.BackColor = Color.White;
            flpLibros.Padding = new Padding(20, 20, 20, 20);
            flpLibros.Margin = new Padding(0);
        }

        private void CargarTarjetas(List<Libro> librosFiltrados)
        {
            flpLibros.Controls.Clear();
            int margen = 10;

            foreach (Libro libro in librosFiltrados)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Width = 150,
                    Height = 200,
                    Margin = new Padding(margen),
                    Disponible = libro.Disponible
                };

                // Borrar
                tarjeta.BotonBorrar.Click += (s, e) => BorrarLibro(libro);

                // Imagen: cargar en memoria
                try
                {
                    if (!string.IsNullOrEmpty(libro.Portada))
                    {
                        string rutaImagen = Path.Combine(Application.StartupPath, libro.Portada);
                        if (File.Exists(rutaImagen))
                        {
                            using (var fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                                tarjeta.Portada = new Bitmap(fs);
                        }
                        else tarjeta.Portada = null;
                    }
                    else tarjeta.Portada = null;
                }
                catch { tarjeta.Portada = null; }

                // Click en portada -> detalle
                tarjeta.PortadaClick += (s, e) =>
                {
                    AbrirDetalleLibro(libro, tarjeta);
                };

                flpLibros.Controls.Add(tarjeta);
            }
        }

        private void AbrirDetalleLibro(Libro libro, TarjetaLibro tarjeta)
        {
            if (libro == null) return;

            DetalleLibros detalle = new DetalleLibros(libro);

            // Suscribir evento de actualización
            detalle.LibroActualizado += (s, ev) =>
            {
                tarjeta.Disponible = libro.Disponible;

                // Actualizar portada
                try
                {
                    if (!string.IsNullOrEmpty(libro.Portada))
                    {
                        string rutaImagen = Path.Combine(Application.StartupPath, libro.Portada);
                        if (File.Exists(rutaImagen))
                        {
                            using (var fs = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read))
                                tarjeta.Portada = new Bitmap(fs);
                        }
                    }
                }
                catch { tarjeta.Portada = null; }
            };

            // Al cerrar, recargar toda la lista
            detalle.FormClosed += (s, ev) =>
            {
                listaLibros = controlador.ObtenerLibros();
                FiltrarLibros(null, null);
            };

            detalle.Show();
        }

        private void FiltrarLibros(object sender, EventArgs e)
        {
            var filtrados = listaLibros.AsEnumerable();

            if (cbTitulos.SelectedIndex > 0)
                filtrados = filtrados.Where(l => l.Titulo == cbTitulos.SelectedItem.ToString());

            if (cbAutores.SelectedIndex > 0)
                filtrados = filtrados.Where(l => l.Escritor == cbAutores.SelectedItem.ToString());

            if (cbDisponible.Checked)
                filtrados = filtrados.Where(l => l.Disponible);

            CargarTarjetas(filtrados.ToList());
        }

        private void BorrarLibro(Libro libro)
        {
            if (libro == null) return;

            var resp = MessageBox.Show(
                $"¿Estás seguro de que quieres borrar el libro \"{libro.Titulo}\"?",
                "Confirmar borrado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resp != DialogResult.Yes) return;

            try
            {
                controlador.BorrarLibro(libro.IdLibro);

                listaLibros = controlador.ObtenerLibros();
                FiltrarLibros(null, null);

                MessageBox.Show("Libro borrado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el libro: " + ex.Message);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            NuevoLibro nuevoLibro = new NuevoLibro(controlador);

            // Cuando se cierre, recargamos la lista y los filtros
            nuevoLibro.FormClosed += (s, ev) =>
            {
                listaLibros = controlador.ObtenerLibros();
                FiltrarLibros(null, null);
            };

            nuevoLibro.Show(); // <-- se abre como ventana independiente
        }


        private void flpLibros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
