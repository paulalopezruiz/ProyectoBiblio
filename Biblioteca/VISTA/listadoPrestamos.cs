using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class listadoPrestamos : Form
    {
        private string _usuarioID;
        private bool _inicializando;
        private Controlador controlador;

        
        private bool mostrado = false;
        private const float FONT_SIZE = 9.0f;

        
        private const int HEADER_BASE_HEIGHT = 110;
        private const int HEADER_MIN = 95;
        private const int HEADER_MAX = 240;

        
        private const int BTN_W_BASE = 127;
        private const int BTN_H_BASE = 29;

        
        private const int TARJETA_H_BASE = 110;
        private const float SUAVIZADO_TARJETA = 0.60f;

        
        private const int GAP_FILTROS_BASE = 18;      
        private const int RIGHT_PAD_BASE = 18;        
        private const int LEFT_PAD_BTN_BASE = 16;     

        public listadoPrestamos(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            this.ControlBox = true;

            _usuarioID = null;
            _inicializando = true;

            
            tlpPrincipal.AutoSize = false;
            tlpPrincipal.AutoSizeMode = AutoSizeMode.GrowOnly;

            
            btnNuevo.AutoSize = false;
            btnNuevo.Dock = DockStyle.None;

            
            btnNuevo.Anchor = AnchorStyles.Right;

            
            btnNuevo.Margin = new Padding(LEFT_PAD_BTN_BASE, 10, RIGHT_PAD_BASE, 10);

            cbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLibro.DropDownStyle = ComboBoxStyle.DropDownList;

            btnNuevo.Click += btnNuevoPrestamo_Click;
            cbUsuario.SelectedIndexChanged += FiltroCambiado;
            cbLibro.SelectedIndexChanged += FiltroCambiado;

            CargarUsuariosCombo();
            CargarLibrosCombo();

            _inicializando = false;

            this.Activated += listadoPrestamos_Activated;
            this.Resize += listadoPrestamos_Resize;
        }

        private void listadoPrestamos_Activated(object sender, EventArgs e)
        {
            mostrado = true;
            AplicarEscalado();
            AjustarTarjetas();
        }

        private void listadoPrestamos_Resize(object sender, EventArgs e)
        {
            if (!mostrado) return;
            AplicarEscalado();
            AjustarTarjetas();
        }

        private void AplicarEscalado()
        {
            if (this.MinimumSize.Width <= 0 || this.MinimumSize.Height <= 0) return;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            if (proporcionAlto > 3f) proporcionAlto = 3f;
            if (proporcionAncho > 3f) proporcionAncho = 3f;

            cambiarFuentes(tlpPrincipal, proporcionAlto);

            int separacionFiltros = (int)(GAP_FILTROS_BASE * proporcionAncho);
            if (separacionFiltros < GAP_FILTROS_BASE) separacionFiltros = GAP_FILTROS_BASE;
            if (separacionFiltros > 60) separacionFiltros = 60;

            tlpLibro.Margin = new Padding(separacionFiltros, tlpLibro.Margin.Top, tlpLibro.Margin.Right, tlpLibro.Margin.Bottom);

            int altoBoton = (int)(BTN_H_BASE * proporcionAlto);
            if (altoBoton < BTN_H_BASE) altoBoton = BTN_H_BASE;
            if (altoBoton > 70) altoBoton = 70;

            int anchoTexto = TextRenderer.MeasureText(btnNuevo.Text, btnNuevo.Font).Width;

            int paddingHorizontal = (int)(28 * proporcionAncho);
            if (paddingHorizontal < 28) paddingHorizontal = 28;
            if (paddingHorizontal > 60) paddingHorizontal = 60;

            int anchoBoton = anchoTexto + paddingHorizontal;

            if (anchoBoton < BTN_W_BASE) anchoBoton = BTN_W_BASE;
            if (anchoBoton > 170) anchoBoton = 170;

            btnNuevo.Size = new Size(anchoBoton, altoBoton);

            int margenDerecho = (int)(RIGHT_PAD_BASE * proporcionAncho);
            if (margenDerecho < RIGHT_PAD_BASE) margenDerecho = RIGHT_PAD_BASE;
            if (margenDerecho > 60) margenDerecho = 60;

            int margenIzquierdo = (int)(LEFT_PAD_BTN_BASE * proporcionAncho);
            if (margenIzquierdo < LEFT_PAD_BTN_BASE) margenIzquierdo = LEFT_PAD_BTN_BASE;
            if (margenIzquierdo > 20) margenIzquierdo = 20;

            btnNuevo.Margin = new Padding(margenIzquierdo, 10, margenDerecho, 10);

            btnNuevo.Visible = true;
            btnNuevo.BringToFront();

            int alturaCabecera = (int)(HEADER_BASE_HEIGHT * proporcionAlto);
            if (alturaCabecera < HEADER_MIN) alturaCabecera = HEADER_MIN;
            if (alturaCabecera > HEADER_MAX) alturaCabecera = HEADER_MAX;

            if (tlpPrincipal.RowStyles.Count > 0)
            {
                tlpPrincipal.RowStyles[0].SizeType = SizeType.Absolute;
                tlpPrincipal.RowStyles[0].Height = alturaCabecera;
            }

            
            tlpPrincipal.PerformLayout();

            int alturaNecesaria = 0;
            foreach (Control c in tlpPrincipal.Controls)
            {
                if (tlpPrincipal.GetRow(c) != 0) continue;

                int abajo = c.Bottom + c.Margin.Bottom;
                if (abajo > alturaNecesaria) alturaNecesaria = abajo;
            }

            alturaNecesaria += 6;

            if (alturaNecesaria > alturaCabecera) alturaCabecera = alturaNecesaria;
            if (alturaCabecera > HEADER_MAX) alturaCabecera = HEADER_MAX;

            if (tlpPrincipal.RowStyles.Count > 0)
            {
                tlpPrincipal.RowStyles[0].SizeType = SizeType.Absolute;
                tlpPrincipal.RowStyles[0].Height = alturaCabecera;
            }

            tlpPrincipal.PerformLayout();
        }

        private void cambiarFuentes(Control c, float proporcionAlto)
        {
            foreach (Control control in c.Controls)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    FONT_SIZE * proporcionAlto,
                    control.Font.Style
                );

                cambiarFuentes(control, proporcionAlto);
            }
        }

        private void AjustarTarjetas()
        {
            int ancho = flowListado.ClientSize.Width - 20;
            if (ancho < 220) ancho = 220;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO_TARJETA;

            int altoTarjeta = (int)(TARJETA_H_BASE * escalaSuave);
            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE;
            if (altoTarjeta > TARJETA_H_BASE * 2) altoTarjeta = TARJETA_H_BASE * 2;

            foreach (Control c in flowListado.Controls)
            {
                if (c is TarjetaPrestamo tp)
                {
                    tp.Width = ancho;
                    tp.Height = altoTarjeta;
                }
            }
        }

        

        public listadoPrestamos(Controlador controlador, string dniUsuario) : this(controlador)
        {
            if (string.IsNullOrWhiteSpace(dniUsuario)) return;

            _usuarioID = controlador.ObtenerIDUsuario(dniUsuario);
            if (!string.IsNullOrWhiteSpace(_usuarioID))
            {
                _inicializando = true;
                for (int i = 0; i < cbUsuario.Items.Count; i++)
                {
                    if (cbUsuario.Items[i] is ComboBoxItem item && item.Value == _usuarioID)
                    {
                        cbUsuario.SelectedIndex = i;
                        break;
                    }
                }
                _inicializando = false;

                var prestamosFiltrados = ObtenerPrestamos(_usuarioID);
                CargarTarjetas(prestamosFiltrados);
                AjustarTarjetas();
            }
        }

        public listadoPrestamos(Controlador controlador, int idLibro) : this(controlador)
        {
            if (idLibro <= 0) return;

            string titulo = controlador.ObtenerTituloLibro(idLibro);
            _inicializando = true;
            for (int i = 0; i < cbLibro.Items.Count; i++)
            {
                if (cbLibro.Items[i]?.ToString() == titulo)
                {
                    cbLibro.SelectedIndex = i;
                    break;
                }
            }
            _inicializando = false;

            var prestamosFiltrados = ObtenerPrestamos("", idLibro);
            CargarTarjetas(prestamosFiltrados);
            AjustarTarjetas();
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
            if (flowListado.Controls.Count > 0) return;
            if (!string.IsNullOrWhiteSpace(_usuarioID)) return;

            CargarTarjetas(ObtenerPrestamos());
            AjustarTarjetas();
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            NuevoPrestamo frm = new NuevoPrestamo(controlador);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CargarTarjetas(ObtenerPrestamos());
                AjustarTarjetas();
            }
        }

        private void FiltroCambiado(object sender, EventArgs e)
        {
            if (_inicializando) return;

            string usuarioID = "";
            if (cbUsuario.SelectedItem is ComboBoxItem itemUsuario && itemUsuario.Value != "--Todos--")
                usuarioID = itemUsuario.Value;

            int idLibro = 0;
            if (cbLibro.SelectedItem != null && cbLibro.SelectedItem.ToString() != "--Todos--")
                idLibro = controlador.ObtenerIDLibro(cbLibro.SelectedItem.ToString());

            var filtrados = ObtenerPrestamos(usuarioID, idLibro);
            CargarTarjetas(filtrados);
            AjustarTarjetas();
        }

        private List<Prestamo> ObtenerPrestamos(string usuarioID = "", int idLibro = 0)
        {
            var prestamos = new List<Prestamo>();
            var condiciones = new List<string>();
            var cmd = new System.Data.SQLite.SQLiteCommand();
            string sql = "SELECT ID, ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin, Devuelto FROM Prestamos";

            if (!string.IsNullOrWhiteSpace(usuarioID))
            {
                condiciones.Add("ID_Usuario = @idUsuario");
                cmd.Parameters.AddWithValue("@idUsuario", usuarioID);
            }

            if (idLibro > 0)
            {
                condiciones.Add("ID_Libro = @idLibro");
                cmd.Parameters.AddWithValue("@idLibro", idLibro);
            }

            if (condiciones.Count > 0)
                sql += " WHERE " + string.Join(" AND ", condiciones);

            sql += " ORDER BY Fecha_Inicio;";
            cmd.CommandText = sql;

            var dt = controlador.GetDataTable(cmd);

            foreach (System.Data.DataRow row in dt.Rows)
            {
                int idPrestamo = int.Parse(row["ID"].ToString());
                int idLibroPrestamo = int.Parse(row["ID_Libro"].ToString());
                string idUsuarioFila = row["ID_Usuario"].ToString();
                DateTime fechaInicio = DateTime.Parse(row["Fecha_Inicio"].ToString());
                DateTime? fechaFin = null;
                if (row["Fecha_Fin"] != DBNull.Value)
                    fechaFin = DateTime.Parse(row["Fecha_Fin"].ToString());

                int devueltoBD = 0;
                if (row.Table.Columns.Contains("Devuelto") && row["Devuelto"] != DBNull.Value)
                    devueltoBD = int.Parse(row["Devuelto"].ToString());

                Prestamo prestamo = new Prestamo(idPrestamo, idLibroPrestamo, idUsuarioFila, fechaInicio, devueltoBD)
                {
                    Fecha_Fin = fechaFin
                };

                prestamos.Add(prestamo);
            }

            return prestamos;
        }

        private void CargarTarjetas(List<Prestamo> prestamos)
        {
            flowListado.Controls.Clear();

            int ancho = flowListado.ClientSize.Width - 20;
            if (ancho < 220) ancho = 220;

            float proporcionAlto = (float)this.Height / this.MinimumSize.Height;
            float proporcionAncho = (float)this.Width / this.MinimumSize.Width;

            float escala = Math.Min(proporcionAlto, proporcionAncho);
            float escalaSuave = 1f + (escala - 1f) * SUAVIZADO_TARJETA;

            int altoTarjeta = (int)(TARJETA_H_BASE * escalaSuave);
            if (altoTarjeta < TARJETA_H_BASE) altoTarjeta = TARJETA_H_BASE;
            if (altoTarjeta > TARJETA_H_BASE * 2) altoTarjeta = TARJETA_H_BASE * 2;

            foreach (var p in prestamos)
            {
                var tarjeta = new TarjetaPrestamo
                {
                    Width = ancho,
                    Height = altoTarjeta
                };

                tarjeta.PonerDatos(p);
                flowListado.Controls.Add(tarjeta);
            }
        }

        private void CargarUsuariosCombo()
        {
            cbUsuario.Items.Clear();
            cbUsuario.Items.Add(new ComboBoxItem("--Todos--", "--Todos--"));

            var usuarios = controlador.ObtenerUsuarios();
            foreach (var u in usuarios)
                cbUsuario.Items.Add(new ComboBoxItem(u.Nombre, u.ID));

            cbUsuario.SelectedIndex = 0;
        }

        private void CargarLibrosCombo()
        {
            cbLibro.Items.Clear();
            cbLibro.Items.Add("--Todos--");

            var libros = controlador.ObtenerTitulosLibros();
            foreach (var l in libros)
                cbLibro.Items.Add(l);

            cbLibro.SelectedIndex = 0;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, EventArgs e) { }

        private class ComboBoxItem
        {
            public string Text { get; }
            public string Value { get; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString() => Text;
        }
    }
}
