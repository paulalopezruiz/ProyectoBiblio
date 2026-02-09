using Biblioteca.CONTROLADOR;
using Biblioteca.MODELO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Biblioteca.VISTA
{
    public partial class listadoPrestamos : Form
    {
        private string _usuarioID;
        private bool _inicializando;

        public listadoPrestamos()
        {
            InitializeComponent();

            // ✅ ARREGLO: para que aparezca la X aunque en Designer esté en None
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            this.ControlBox = true;

            _usuarioID = null;
            _inicializando = true;

            btnNuevo.Click += btnNuevoPrestamo_Click;

            cbUsuario.SelectedIndexChanged += FiltroCambiado;
            cbLibro.SelectedIndexChanged += FiltroCambiado;

            CargarUsuariosCombo();
            CargarLibrosCombo();

            // ✅ asegurar load
            Load += listadoPrestamos_Load;

            _inicializando = false;
        }

        // Constructor desde DetalleUsuario (DNI)
        public listadoPrestamos(string dniUsuario) : this()
        {
            if (string.IsNullOrWhiteSpace(dniUsuario))
                return;

            _usuarioID = BibliotecaBBDD.GetIDUsuario(dniUsuario);

            if (!string.IsNullOrWhiteSpace(_usuarioID))
            {
                string nombreUsuario = BibliotecaBBDD.GetNombreUsuario(_usuarioID);

                _inicializando = true;
                for (int i = 0; i < cbUsuario.Items.Count; i++)
                {
                    if (cbUsuario.Items[i]?.ToString() == nombreUsuario)
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

        // ✅ NUEVO: Constructor desde DetalleLibros (ID del libro)
        public listadoPrestamos(int idLibro) : this()
        {
            if (idLibro <= 0)
                return;

            // seleccionar libro en combo (por título)
            string titulo = BibliotecaBBDD.GetTituloLibro(idLibro);

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

            // cargar filtrado por libro
            var prestamosFiltrados = ObtenerPrestamos("", idLibro);
            CargarTarjetas(prestamosFiltrados);
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
            // ✅ si ya hay tarjetas cargadas por un constructor filtrado, no recargar
            if (flowLayoutPanel1.Controls.Count > 0)
                return;

            // si venimos por usuario ya se cargó antes
            if (!string.IsNullOrWhiteSpace(_usuarioID))
                return;

            CargarTarjetas(ObtenerPrestamos());
        }

        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            NuevoPrestamo frm = new NuevoPrestamo();
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTarjetas(ObtenerPrestamos());
        }

        private void FiltroCambiado(object sender, EventArgs e)
        {
            if (_inicializando) return;

            string usuarioID = "";

            if (cbUsuario.SelectedItem != null && cbUsuario.SelectedItem.ToString() != "--Todos--")
            {
                string nombreUsuario = cbUsuario.SelectedItem.ToString();
                string dni = BibliotecaBBDD.GetDNIUsuario(nombreUsuario);
                if (!string.IsNullOrWhiteSpace(dni))
                    usuarioID = BibliotecaBBDD.GetIDUsuario(dni);
            }

            int idLibro = 0;
            if (cbLibro.SelectedItem != null && cbLibro.SelectedItem.ToString() != "--Todos--")
                idLibro = BibliotecaBBDD.GetIDLibro(cbLibro.SelectedItem.ToString());

            var filtrados = ObtenerPrestamos(usuarioID, idLibro);
            CargarTarjetas(filtrados);
        }

        private List<Prestamo> ObtenerPrestamos(string usuarioID = "", int idLibro = 0)
        {
            var prestamos = new List<Prestamo>();
            List<string> condiciones = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand();

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

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
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
                TarjetaPrestamo tarjeta = new TarjetaPrestamo
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
            cbUsuario.Items.Add("--Todos--");

            SQLiteCommand cmd = new SQLiteCommand("SELECT Nombre FROM Usuarios ORDER BY Nombre;");
            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
                cbUsuario.Items.Add(row["Nombre"].ToString());

            cbUsuario.SelectedIndex = 0;
        }

        private void CargarLibrosCombo()
        {
            cbLibro.Items.Clear();
            cbLibro.Items.Add("--Todos--");

            DataTable dt = BibliotecaBBDD.GetDataTable(new SQLiteCommand("SELECT Titulo FROM Libros ORDER BY Titulo;"));
            foreach (DataRow row in dt.Rows)
                cbLibro.Items.Add(row["Titulo"].ToString());

            cbLibro.SelectedIndex = 0;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}
