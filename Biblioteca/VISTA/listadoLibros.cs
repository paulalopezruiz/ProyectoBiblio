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

        // --- ESCALADO ---
        private bool mostrado = false;

        // Base del diseñador (tu MinimumSize)
        private const int BASE_W = 570;
        private const int BASE_H = 276;

        // Tarjetas base (las tuyas)
        private const int TARJETA_W_BASE = 150;
        private const int TARJETA_H_BASE = 200;
        private const int TARJETA_MARGIN_BASE = 10;

        // Limites para que no se desmadre
        private const int TARJETA_W_MAX = 260;
        private const int TARJETA_H_MAX = 320;
        private const int TARJETA_MARGIN_MAX = 25;

        // Suavizado (como usas en otros)
        private const float SUAVIZADO = 0.60f;

        public listadoLibros(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            Load += listadoLibros_Load;
            cbTitulos.SelectedIndexChanged += FiltrarLibros;
            cbAutores.SelectedIndexChanged += FiltrarLibros;
            cbDisponible.CheckedChanged += FiltrarLibros;

            // Escalado
            this.Activated += listadoLibros_Activated;
            this.Resize += listadoLibros_Resize;
        }

        private void listadoLibros_Load(object sender, EventArgs e)
        {
            listaLibros = controlador.ObtenerLibros();

            RellenarComboTitulos();
            RellenarComboAutores();
            ConfigurarFlowPanel();
            CargarTarjetas(listaLibros);

            mostrado = true;
            Escalar();
            AjustarTarjetas();
        }

        private void listadoLibros_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            Escalar();
            AjustarTarjetas();
        }

        private void listadoLibros_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            Escalar();
            AjustarTarjetas();
        }

        // ✅ NO acumulativo (guarda base en Tag) y ✅ NO entra en TarjetaLibro
        private void CambiarFuentesNoAcumulativo(Control root, float escala)
        {
            foreach (Control c in root.Controls)
            {
                // NO escalar dentro de las tarjetas para que portada/boton "Borrar" arranquen como ahora
                if (c is TarjetaLibro) continue;

                if (c.Tag == null)
                    c.Tag = c.Font.Size;

                float baseSize = (float)c.Tag;
                c.Font = new Font(c.Font.FontFamily, baseSize * escala, c.Font.Style);

                CambiarFuentesNoAcumulativo(c, escala);
            }
        }

        private void Escalar()
        {
            float proporcionAlto = (float)this.Height / BASE_H;
            float proporcionAncho = (float)this.Width / BASE_W;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            float escala = Math.Min(proporcionAlto, proporcionAncho);

            // ✅ En tamaño base: NO cambia nada
            if (escala < 1f) escala = 1f;

            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            // Solo crece lo de arriba (no las tarjetas por dentro)
            CambiarFuentesNoAcumulativo(tlpPrincipal, escalaSuave);

            tlpPrincipal.PerformLayout();
        }

        // ✅ Portadas: carga segura (evita que desaparezcan)
        private Image CargarImagenSeguro(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta) || !File.Exists(ruta))
                return null;

            try
            {
                byte[] bytes = File.ReadAllBytes(ruta);
                using (var ms = new MemoryStream(bytes))
                using (var img = Image.FromStream(ms))
                {
                    return new Bitmap(img); // clon en memoria
                }
            }
            catch
            {
                return null;
            }
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

        // ✅ Solo cambia el tamaño EXTERNO de la tarjeta (por fuera)
        private void AjustarTarjetas()
        {
            float proporcionAlto = (float)this.Height / BASE_H;
            float proporcionAncho = (float)this.Width / BASE_W;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            if (escala < 1f) escala = 1f;

            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO;

            int w = (int)(TARJETA_W_BASE * proporcionAncho);
            int h = (int)(TARJETA_H_BASE * escalaSuave);
            int m = (int)(TARJETA_MARGIN_BASE * escalaSuave);

            if (w < TARJETA_W_BASE) w = TARJETA_W_BASE;
            if (h < TARJETA_H_BASE) h = TARJETA_H_BASE;
            if (m < TARJETA_MARGIN_BASE) m = TARJETA_MARGIN_BASE;

            if (w > TARJETA_W_MAX) w = TARJETA_W_MAX;
            if (h > TARJETA_H_MAX) h = TARJETA_H_MAX;
            if (m > TARJETA_MARGIN_MAX) m = TARJETA_MARGIN_MAX;

            foreach (Control c in flpLibros.Controls)
            {
                if (c is TarjetaLibro tl)
                {
                    tl.Width = w;
                    tl.Height = h;
                    tl.Margin = new Padding(m);
                }
            }
        }

        private void CargarTarjetas(List<Libro> librosFiltrados)
        {
            flpLibros.Controls.Clear();
            int margen = TARJETA_MARGIN_BASE;

            foreach (Libro libro in librosFiltrados)
            {
                TarjetaLibro tarjeta = new TarjetaLibro
                {
                    Width = TARJETA_W_BASE,
                    Height = TARJETA_H_BASE,
                    Margin = new Padding(margen),
                    Disponible = libro.Disponible
                };

                tarjeta.BotonBorrar.Click += (s, e) => BorrarLibro(libro);

                // ✅ Portada segura + compatible con rutas absolutas
                string rutaImagen = null;
                if (!string.IsNullOrEmpty(libro.Portada))
                {
                    rutaImagen = Path.IsPathRooted(libro.Portada)
                        ? libro.Portada
                        : Path.Combine(Application.StartupPath, libro.Portada);
                }

                tarjeta.Portada = CargarImagenSeguro(rutaImagen);

                tarjeta.PortadaClick += (s, e) =>
                {
                    AbrirDetalleLibro(libro, tarjeta);
                };

                flpLibros.Controls.Add(tarjeta);
            }

            AjustarTarjetas();
        }

        private void AbrirDetalleLibro(Libro libro, TarjetaLibro tarjeta)
        {
            if (libro == null) return;

            DetalleLibros detalle = new DetalleLibros(libro);

            detalle.LibroActualizado += (s, ev) =>
            {
                tarjeta.Disponible = libro.Disponible;

                string rutaImagen = null;
                if (!string.IsNullOrEmpty(libro.Portada))
                {
                    rutaImagen = Path.IsPathRooted(libro.Portada)
                        ? libro.Portada
                        : Path.Combine(Application.StartupPath, libro.Portada);
                }

                tarjeta.Portada = CargarImagenSeguro(rutaImagen);
            };

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

            nuevoLibro.FormClosed += (s, ev) =>
            {
                listaLibros = controlador.ObtenerLibros();
                FiltrarLibros(null, null);
            };

            nuevoLibro.Show();
        }
    }
}
