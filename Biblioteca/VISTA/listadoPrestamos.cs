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
        // Guardaremos aquí el ID del usuario (NO el DNI) cuando venga desde DetalleUsuario
        private string _usuarioID;
        private bool _inicializando;

        public listadoPrestamos()
        {
            InitializeComponent();

            _usuarioID = null;
            _inicializando = true; // bloquea eventos mientras cargamos combos

            btnNuevo.Click += btnNuevoPrestamo_Click;

            // Eventos para filtrar automáticamente por combos
            cbUsuario.SelectedIndexChanged += FiltroCambiado;
            cbLibro.SelectedIndexChanged += FiltroCambiado;

            // Cargar combos al iniciar
            CargarUsuariosCombo();
            CargarLibrosCombo();

            _inicializando = false; // ya pueden dispararse eventos
        }

        // Constructor que recibe el DNI del usuario (desde DetalleUsuario)
        public listadoPrestamos(string dniUsuario) : this()
        {
            if (string.IsNullOrWhiteSpace(dniUsuario))
                return;

            // 1) Convertimos DNI -> ID (porque la tabla Prestamos filtra por ID_Usuario)
            _usuarioID = BibliotecaBBDD.GetIDUsuario(dniUsuario);

            if (!string.IsNullOrWhiteSpace(_usuarioID))
            {
                // 2) Obtenemos el nombre mediante el ID (tu helper existente)
                string nombreUsuario = BibliotecaBBDD.GetNombreUsuario(_usuarioID);

                // 3) Seleccionamos ese nombre en el combo
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

                // 4) Cargamos SOLO sus préstamos
                var prestamosFiltrados = ObtenerPrestamos(_usuarioID);
                CargarTarjetas(prestamosFiltrados);
            }
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
            // Si venimos desde DetalleUsuario ya hemos cargado filtrado arriba.
            if (!string.IsNullOrWhiteSpace(_usuarioID))
                return;

            // Carga normal (sin filtro)
            CargarTarjetas(ObtenerPrestamos());
        }

        // =========================
        // BOTÓN NUEVO PRÉSTAMO
        // =========================
        private void btnNuevoPrestamo_Click(object sender, EventArgs e)
        {
            NuevoPrestamo frm = new NuevoPrestamo();
            if (frm.ShowDialog() == DialogResult.OK)
                CargarTarjetas(ObtenerPrestamos());
        }

        // =========================
        // EVENTO CUANDO CAMBIA ALGÚN COMBO
        // =========================
        private void FiltroCambiado(object sender, EventArgs e)
        {
            if (_inicializando) return;

            string usuarioID = "";

            // Si han elegido un usuario concreto en el combo (por nombre)
            if (cbUsuario.SelectedItem != null && cbUsuario.SelectedItem.ToString() != "--Todos--")
            {
                // Convertimos Nombre -> DNI -> ID (usando tus helpers)
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

        // =========================
        // OBTENER PRÉSTAMOS DESDE LA BD
        //   usuarioID = ID del usuario (NO DNI)
        // =========================
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

        // =========================
        // PINTAR TARJETAS
        // =========================
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

        // =========================
        // CARGAR USUARIOS Y LIBROS EN COMBOS
        // =========================
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // opcional
        }
    }
}