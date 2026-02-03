using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using Biblioteca.CONTROLADOR;

namespace Biblioteca.VISTA
{
    public partial class listadoPrestamos : Form
    {
        private const string BBDD = "BibliotecaBD";

        private string _dniUsuario;

        public listadoPrestamos()
        {
            InitializeComponent();
            _dniUsuario = null; 
        }

        
        public listadoPrestamos(string dniUsuario)
        {
            InitializeComponent();
            _dniUsuario = dniUsuario;
        }

        private void listadoPrestamos_Load(object sender, EventArgs e)
        {
            CargarTarjetas(ObtenerPrestamos());
        }

        private List<(string texto, DateTime fechaFin)> ObtenerPrestamos()
        {
            List<(string texto, DateTime fechaFin)> prestamos = new List<(string, DateTime)>();

            SQLiteCommand cmd;

            if (string.IsNullOrWhiteSpace(_dniUsuario))
            {
                cmd = new SQLiteCommand(@"
                    SELECT 
                        l.Titulo AS LibroTitulo,
                        u.Nombre AS UsuarioNombre,
                        p.Fecha_Fin AS FechaFin
                    FROM prestamos p
                    JOIN libros l ON l.ID = p.ID_Libro
                    JOIN usuarios u ON u.ID = p.ID_Usuario
                    ORDER BY p.Fecha_Fin;
                ");
            }
            else
            {
                cmd = new SQLiteCommand(@"
                    SELECT 
                        l.Titulo AS LibroTitulo,
                        u.Nombre AS UsuarioNombre,
                        p.Fecha_Fin AS FechaFin
                    FROM prestamos p
                    JOIN libros l ON l.ID = p.ID_Libro
                    JOIN usuarios u ON u.ID = p.ID_Usuario
                    WHERE u.DNI = @dni
                    ORDER BY p.Fecha_Fin;
                ");
                cmd.Parameters.AddWithValue("@dni", _dniUsuario);
            }

            DataTable dt = BibliotecaBBDD.GetDataTable(BBDD, cmd);

            foreach (DataRow row in dt.Rows)
            {
                string libro = row["LibroTitulo"].ToString();
                string usuario = row["UsuarioNombre"].ToString();
                string fechaFinTexto = row["FechaFin"].ToString();

                DateTime fechaFin;

                if (string.IsNullOrWhiteSpace(fechaFinTexto))
                    fechaFin = DateTime.Today.AddYears(100);
                else
                    fechaFin = DateTime.Parse(fechaFinTexto);

                string textoPrestamo = libro + " - " + usuario;
                prestamos.Add((textoPrestamo, fechaFin));
            }

            return prestamos;
        }

        private void CargarTarjetas(List<(string texto, DateTime fechaFin)> prestamos)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var p in prestamos)
            {
                TarjetaPrestamo tarjeta = new TarjetaPrestamo();
                tarjeta.Width = flowLayoutPanel1.ClientSize.Width - 20;

                tarjeta.PonerDatos(p.texto, p.fechaFin);

                flowLayoutPanel1.Controls.Add(tarjeta);
            }
        }
    }
}
