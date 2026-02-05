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
        }

        public listadoPrestamos(string dniUsuario)
        {
            InitializeComponent();
            _dniUsuario = dniUsuario;
            btnNuevo.Click += btnNuevoPrestamo_Click;
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
        // OBTENER PRÉSTAMOS DESDE LA BD
        // =========================
        private List<Prestamo> ObtenerPrestamos()
        {
            var prestamos = new List<Prestamo>();
            SQLiteCommand cmd;

            if (string.IsNullOrWhiteSpace(_dniUsuario))
            {
                cmd = new SQLiteCommand(@"
                    SELECT 
                        l.Titulo AS LibroTitulo,
                        u.Nombre AS UsuarioNombre,
                        p.Fecha_Inicio AS FechaInicio,
                        p.Fecha_Fin AS FechaFin,
                        p.Devuelto AS Devuelto
                    FROM Prestamos p
                    JOIN Libros l ON l.ID = p.ID_Libro
                    JOIN Usuarios u ON u.ID = p.ID_Usuario
                    ORDER BY p.Fecha_Inicio;
                ");
            }
            else
            {
                cmd = new SQLiteCommand(@"
                    SELECT 
                        l.Titulo AS LibroTitulo,
                        u.Nombre AS UsuarioNombre,
                        p.Fecha_Inicio AS FechaInicio,
                        p.Fecha_Fin AS FechaFin,
                        p.Devuelto AS Devuelto
                    FROM Prestamos p
                    JOIN Libros l ON l.ID = p.ID_Libro
                    JOIN Usuarios u ON u.ID = p.ID_Usuario
                    WHERE u.DNI = @dni
                    ORDER BY p.Fecha_Inicio;
                ");
                cmd.Parameters.AddWithValue("@dni", _dniUsuario);
            }

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                string texto = row["LibroTitulo"] + " - " + row["UsuarioNombre"];
                DateTime fechaInicio = DateTime.Parse(row["FechaInicio"].ToString());
                DateTime? fechaFin = null;

                if (row["FechaFin"] != DBNull.Value)
                    fechaFin = DateTime.Parse(row["FechaFin"].ToString());

                // Controlamos si Devuelto es null
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

                tarjeta.PonerDatos(p); // Pasamos el objeto Prestamo completo
                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}


