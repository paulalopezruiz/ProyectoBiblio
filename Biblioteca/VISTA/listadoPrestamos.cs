using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class listadoPrestamos : Form
    {
        private string _usuarioID;
        private bool _inicializando;
        private Controlador controlador;

        // Constructor principal
        public listadoPrestamos(Controlador controlador)
        {
            InitializeComponent();
            this.controlador = controlador;

            this.ControlBox = true;

            _usuarioID = null;
            _inicializando = true;

            btnNuevo.Click += btnNuevoPrestamo_Click;
            cbUsuario.SelectedIndexChanged += FiltroCambiado;
            cbLibro.SelectedIndexChanged += FiltroCambiado;

            CargarUsuariosCombo();
            CargarLibrosCombo();

            Load += listadoPrestamos_Load;
            _inicializando = false;
        }

        // Constructor desde DetalleUsuario
        public listadoPrestamos(Controlador controlador, string dniUsuario) : this(controlador)
        {
            if (string.IsNullOrWhiteSpace(dniUsuario)) return;

            _usuarioID = controlador.ObtenerIDUsuario(dniUsuario);
            if (!string.IsNullOrWhiteSpace(_usuarioID))
            {
                // Seleccionar usuario correcto en ComboBox
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
            }
        }

        // Constructor desde DetalleLibros
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
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0) return;
            if (!string.IsNullOrWhiteSpace(_usuarioID)) return;
            CargarTarjetas(ObtenerPrestamos());
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            NuevoPrestamo frm = new NuevoPrestamo(controlador);
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTarjetas(ObtenerPrestamos());
        }

        private void FiltroCambiado(object sender, EventArgs e)
        {
            if (_inicializando) return;

            string usuarioID = "";
            if (cbUsuario.SelectedItem != null && cbUsuario.SelectedItem is ComboBoxItem itemUsuario && itemUsuario.Value != "--Todos--")
            {
                usuarioID = itemUsuario.Value; // Ya tenemos el ID
            }

            int idLibro = 0;
            if (cbLibro.SelectedItem != null && cbLibro.SelectedItem.ToString() != "--Todos--")
                idLibro = controlador.ObtenerIDLibro(cbLibro.SelectedItem.ToString());

            var filtrados = ObtenerPrestamos(usuarioID, idLibro);
            CargarTarjetas(filtrados);
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
            flowLayoutPanel1.Controls.Clear();
            foreach (var p in prestamos)
            {
                var tarjeta = new TarjetaPrestamo
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 20
                };
                tarjeta.PonerDatos(p);
                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }

        private void CargarUsuariosCombo()
        {
            cbUsuario.Items.Clear();
            cbUsuario.Items.Add(new ComboBoxItem("--Todos--", "--Todos--"));

            var usuarios = controlador.ObtenerUsuarios();
            foreach (var u in usuarios)
            {
                cbUsuario.Items.Add(new ComboBoxItem(u.Nombre, u.ID));
            }

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

        // Clase auxiliar para almacenar texto y valor en ComboBox
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
