using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SQLite;
using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;

namespace Biblioteca.VISTA
{
    public partial class listadoLibros : Form
    {
        private List<Libro> listaLibros;
        private Controlador controlador;

        // Constructor adaptado a MVC
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
            listaLibros = controlador.ObtenerLibros(); // USAMOS CONTROLADOR

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

            int tarjetasPorFila = 2;
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

                tarjeta.BotonBorrar.Width = 80;
                tarjeta.BotonBorrar.Height = 25;
                tarjeta.BotonBorrar.Anchor = AnchorStyles.None;

                // Imagen: cargar en memoria para evitar bloqueo del archivo
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
                catch
                {
                    tarjeta.Portada = null;
                }

                // ✅ Click en portada -> detalle
                tarjeta.PortadaClick += (s, e) => AbrirDetalleLibro(libro);

                // Borrar
                tarjeta.BotonBorrar.Click += (s, e) => BorrarLibro(libro);

                flpLibros.Controls.Add(tarjeta);
            }

            AjustarColumnas(tarjetasPorFila, 150, margen);
        }

        private void AbrirDetalleLibro(Libro libro)
        {
            if (libro == null) return;

            using (var detalle = new DetalleLibros(libro))
                detalle.ShowDialog(this);
        }

        private void AjustarColumnas(int tarjetasPorFila, int anchoTarjeta, int margen)
        {
            int panelWidth = flpLibros.ClientSize.Width;
            int espacioTotal = tarjetasPorFila * (anchoTarjeta + 2 * margen);
            int margenIzq = (panelWidth - espacioTotal) / 2;
            if (margenIzq < 0) margenIzq = 0;

            flpLibros.Padding = new Padding(margenIzq, 20, 20, 20);
        }

        // =========================
        // FILTRAR LIBROS (método necesario)
        // =========================
        private void FiltrarLibros(object sender, EventArgs e)
        {
            var filtrados = listaLibros.AsEnumerable();

            if (cbTitulos.SelectedIndex > 0)
            {
                string titulo = cbTitulos.SelectedItem.ToString();
                filtrados = filtrados.Where(l => l.Titulo == titulo);
            }

            if (cbAutores.SelectedIndex > 0)
            {
                string autor = cbAutores.SelectedItem.ToString();
                filtrados = filtrados.Where(l => l.Escritor == autor);
            }

            if (cbDisponible.Checked)
                filtrados = filtrados.Where(l => l.Disponible);

            CargarTarjetas(filtrados.ToList());
        }

        private void AbrirNuevoLibro(object sender, EventArgs e)
        {
            NuevoLibro frm = new NuevoLibro(controlador);
            frm.CargarDatos();
            frm.ShowDialog();

            listaLibros = controlador.ObtenerLibros(); // USAMOS CONTROLADOR
            FiltrarLibros(null, null);
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
                SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Libros WHERE ID = @id;");
                cmd.Parameters.AddWithValue("@id", libro.IdLibro);

                controlador.EjecutarComando(cmd); // USAMOS CONTROLADOR

                if (!string.IsNullOrEmpty(libro.Portada))
                {
                    string rutaImagen = Path.Combine(Application.StartupPath, libro.Portada);
                    if (File.Exists(rutaImagen))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            try { File.Delete(rutaImagen); break; }
                            catch { System.Threading.Thread.Sleep(50); }
                        }
                    }
                }

                listaLibros = controlador.ObtenerLibros(); // USAMOS CONTROLADOR
                FiltrarLibros(null, null);

                MessageBox.Show("Libro borrado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar el libro: " + ex.Message);
            }
        }

        private void flpLibros_Paint(object sender, PaintEventArgs e) { }
        private void cbDisponible_CheckedChanged(object sender, EventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
