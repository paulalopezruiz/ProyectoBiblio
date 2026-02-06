using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Biblioteca.MODELO;

namespace Biblioteca.CONTROLADOR
{
    public class BibliotecaBBDD
    {


        private static string ObtenerRutaBBDD()
        {
            // Ruta de la raíz del proyecto (no bin)
            string rutaBin = AppDomain.CurrentDomain.BaseDirectory;
            string rutaRaiz = Path.Combine(rutaBin, @"..\..\Biblioteca.db");
            return Path.GetFullPath(rutaRaiz);
        }

        public static SQLiteConnection Conectar()
        {
            string cs = "Data Source=" + ObtenerRutaBBDD() + ";Version=3;";
            SQLiteConnection conexion = new SQLiteConnection(cs);
            conexion.Open();
            return conexion;
        }

        public static DataTable GetDataTable(SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection conexion = Conectar())
                {
                    cmd.Connection = conexion;
                    DataTable tabla = new DataTable();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataTable: " + ex.Message);
            }
        }
        // =========================
        // Obtener nombre del usuario desde ID (DNI)
        // =========================
        public static string GetNombreUsuario(string idUsuario)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT Nombre FROM Usuarios WHERE ID = @id;");
            cmd.Parameters.AddWithValue("@id", idUsuario);

            DataTable dt = GetDataTable(cmd);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Nombre"].ToString();

            return "Desconocido"; // Por si no encuentra
        }

        public static string GetIDUsuario(string dniUsuario)
        {
            if (string.IsNullOrWhiteSpace(dniUsuario)) return "";

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID FROM Usuarios WHERE DNI = @dni LIMIT 1;");
            cmd.Parameters.AddWithValue("@dni", dniUsuario);

            DataTable dt = GetDataTable(cmd);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["ID"].ToString();

            return "";
        }



        // =========================
        // Obtener título del libro desde ID
        // =========================
        public static string GetTituloLibro(int idLibro)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT Titulo FROM Libros WHERE ID = @id;");
            cmd.Parameters.AddWithValue("@id", idLibro);

            DataTable dt = GetDataTable(cmd);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Titulo"].ToString();

            return "Desconocido"; // Por si no encuentra
        }

        // Devuelve el DNI del usuario desde su nombre
        public static string GetDNIUsuario(string nombreUsuario)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT DNI FROM Usuarios WHERE Nombre = @nombre;");
            cmd.Parameters.AddWithValue("@nombre", nombreUsuario);

            DataTable dt = GetDataTable(cmd);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["DNI"].ToString();

            return ""; // Devuelve vacío si no se encuentra
        }


        // Devuelve el ID del libro desde su título
        public static int GetIDLibro(string titulo)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT ID FROM Libros WHERE Titulo = @titulo;");
            cmd.Parameters.AddWithValue("@titulo", titulo);

            DataTable dt = GetDataTable(cmd);

            if (dt.Rows.Count > 0)
                return int.Parse(dt.Rows[0]["ID"].ToString());

            return 0; // 0 significa "todos los libros"
        }

        // =========================
        // Obtener lista completa de libros con préstamos activos
        // =========================
        public static List<Libro> GetLibros()
        {
            List<Libro> libros = new List<Libro>();

            SQLiteCommand cmd = new SQLiteCommand(@"
        SELECT 
            l.ID,
            l.Titulo,
            l.Escritor,
            l.Portada,
            l.NEjemplares,
            COUNT(p.ID) AS PrestamosActivos
        FROM Libros l
        LEFT JOIN Prestamos p 
            ON l.ID = p.ID  -- columna que indica el libro en Prestamos
            AND p.Devuelto = 0  -- aquí contamos solo los préstamos no devueltos
        GROUP BY l.ID;
    ");

            DataTable dt = GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro(
                    int.Parse(row["ID"].ToString()),
                    row["Titulo"].ToString(),
                    row["Escritor"].ToString(),
                    row["Portada"].ToString(),
                    int.Parse(row["NEjemplares"].ToString()),
                    int.Parse(row["PrestamosActivos"].ToString())
                );

                libros.Add(libro);
            }

            return libros;
        }





        public static void Ejecuta(SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection conexion = Conectar())
                {
                    cmd.Connection = conexion;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en Ejecuta: " + ex.Message);
            }
        }
    }
}
