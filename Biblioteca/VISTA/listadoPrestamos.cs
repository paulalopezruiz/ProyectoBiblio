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
        private string _dniUsuario;

        public listadoPrestamos()
        {
            InitializeComponent();
            _dniUsuario = null;

            btnNuevo.Click += btnNuevoPrestamo_Click;

            // Eventos para filtrar automáticamente por combos
            cbUsuario.SelectedIndexChanged += FiltroCambiado;
            cbLibro.SelectedIndexChanged += FiltroCambiado;

            // Cargar combos al iniciar
            CargarUsuariosCombo();
            CargarLibrosCombo();
        }

        // Constructor que recibe el DNI del usuario (desde detalle)
        public listadoPrestamos(string dniUsuario) : this()
        {
            _dniUsuario = dniUsuario;

            if (!string.IsNullOrWhiteSpace(_dniUsuario))
            {
                // Obtenemos el nombre del usuario desde la BD
                SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT Nombre FROM Usuarios WHERE DNI = @dni;"
                );
                cmd.Parameters.AddWithValue("@dni", _dniUsuario);

                DataTable dt = BibliotecaBBDD.GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    string nombreUsuario = dt.Rows[0]["Nombre"].ToString();

                    // Recorremos los items del combo y seleccionamos el que coincide
                    for (int i = 0; i < cbUsuario.Items.Count; i++)
                    {
                        if (cbUsuario.Items[i].ToString() == nombreUsuario)
                        {
                            cbUsuario.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
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
            string usuario = cbUsuario.SelectedItem?.ToString() ?? "";
            if (usuario == "--Todos--") usuario = "";

            string titulo = cbLibro.SelectedItem?.ToString() ?? "";
            if (titulo == "--Todos--") titulo = "";

            var filtrados = ObtenerPrestamos(usuario, titulo);
            CargarTarjetas(filtrados);
        }

        // =========================
        // OBTENER PRÉSTAMOS DESDE LA BD
        // =========================
        private List<Prestamo> ObtenerPrestamos(string usuario = "", string titulo = "")
        {
            var prestamos = new List<Prestamo>();
            List<string> condiciones = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand();

            string sql = @"
                SELECT 
                    l.Titulo AS LibroTitulo,
                    u.Nombre AS UsuarioNombre,
                    p.Fecha_Inicio AS FechaInicio,
                    p.Fecha_Fin AS FechaFin,
                    p.Devuelto AS Devuelto
                FROM Prestamos p
                JOIN Libros l ON l.ID = p.ID_Libro
                JOIN Usuarios u ON u.ID = p.ID_Usuario
            ";

            if (!string.IsNullOrWhiteSpace(_dniUsuario))
            {
                condiciones.Add("u.DNI = @dniUsuario");
                cmd.Parameters.AddWithValue("@dniUsuario", _dniUsuario);
            }

            if (!string.IsNullOrWhiteSpace(usuario))
            {
                condiciones.Add("u.Nombre = @usuario");
                cmd.Parameters.AddWithValue("@usuario", usuario);
            }

            if (!string.IsNullOrWhiteSpace(titulo))
            {
                condiciones.Add("l.Titulo = @titulo");
                cmd.Parameters.AddWithValue("@titulo", titulo);
            }

            if (condiciones.Count > 0)
                sql += " WHERE " + string.Join(" AND ", condiciones);

            sql += " ORDER BY p.Fecha_Inicio;";
            cmd.CommandText = sql;

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                string texto = row["LibroTitulo"] + " - " + row["UsuarioNombre"];
                DateTime fechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                DateTime? fechaFin = null;
                if (row["FechaFin"] != DBNull.Value)
                    fechaFin = DateTime.Parse(row["FechaFin"].ToString());

                int devueltoBD = 0;
                if (row.Table.Columns.Contains("Devuelto") && row["Devuelto"] != DBNull.Value)
                    devueltoBD = int.Parse(row["Devuelto"].ToString());

                Prestamo prestamo = new Prestamo(0, texto, fechaInicio, devueltoBD)
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

            DataTable dt = BibliotecaBBDD.GetDataTable(new SQLiteCommand("SELECT Nombre FROM Usuarios ORDER BY Nombre;"));
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
    }
}
