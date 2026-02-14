using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using Biblioteca.MODELO;

namespace Biblioteca.CONTROLADOR
{
    // Clase de acceso a la base de datos
    public static class BibliotecaBBDD
    {
        private static string ObtenerRutaBBDD()
        {
            string rutaBin = AppDomain.CurrentDomain.BaseDirectory;
            string rutaRaiz = Path.Combine(rutaBin, @"..\..\Biblioteca.db");
            return Path.GetFullPath(rutaRaiz);
        }

        // Conecta con SQLite
        public static SQLiteConnection Conectar()
        {
            string cs = "Data Source=" + ObtenerRutaBBDD() + ";Version=3;";
            SQLiteConnection conexion = new SQLiteConnection(cs);
            conexion.Open();
            return conexion;
        }

        // Ejecuta un comando y devuelve un DataTable
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

        // Métodos de consulta para usuarios
        public static string GetNombreUsuario(string idUsuario)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT Nombre FROM Usuarios WHERE ID = @id;");
            cmd.Parameters.AddWithValue("@id", idUsuario);

            DataTable dt = GetDataTable(cmd);
            return dt.Rows.Count > 0 ? dt.Rows[0]["Nombre"].ToString() : "Desconocido";
        }

        public static string GetIDUsuario(string dniUsuario)
        {
            if (string.IsNullOrWhiteSpace(dniUsuario)) return "";

            SQLiteCommand cmd = new SQLiteCommand("SELECT ID FROM Usuarios WHERE DNI = @dni LIMIT 1;");
            cmd.Parameters.AddWithValue("@dni", dniUsuario);

            DataTable dt = GetDataTable(cmd);
            return dt.Rows.Count > 0 ? dt.Rows[0]["ID"].ToString() : "";
        }

        public static string GetDNIUsuario(string nombreUsuario)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT DNI FROM Usuarios WHERE Nombre = @nombre;");
            cmd.Parameters.AddWithValue("@nombre", nombreUsuario);

            DataTable dt = GetDataTable(cmd);
            return dt.Rows.Count > 0 ? dt.Rows[0]["DNI"].ToString() : "";
        }

   
        // Métodos de consulta para libros
        public static string GetTituloLibro(int idLibro)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT Titulo FROM Libros WHERE ID = @id;");
            cmd.Parameters.AddWithValue("@id", idLibro);

            DataTable dt = GetDataTable(cmd);
            return dt.Rows.Count > 0 ? dt.Rows[0]["Titulo"].ToString() : "Desconocido";
        }

        public static int GetIDLibro(string titulo)
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT ID FROM Libros WHERE Titulo = @titulo;");
            cmd.Parameters.AddWithValue("@titulo", titulo);

            DataTable dt = GetDataTable(cmd);
            return dt.Rows.Count > 0 ? int.Parse(dt.Rows[0]["ID"].ToString()) : 0;
        }



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
                    ON l.ID = p.ID_Libro AND p.Devuelto = 0
                GROUP BY l.ID;
            ");

            DataTable dt = GetDataTable(cmd);

            foreach (DataRow row in dt.Rows)
            {
                libros.Add(new Libro(
                    int.Parse(row["ID"].ToString()),
                    row["Titulo"].ToString(),
                    row["Escritor"].ToString(),
                    row["Portada"].ToString(),
                    int.Parse(row["NEjemplares"].ToString()),
                    int.Parse(row["PrestamosActivos"].ToString())
                ));
            }

            return libros;
        }

    
        // Actualizar usuarios
       

        public static void UpdateUsuarioNombre(string idUsuario, string nuevoNombre)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Usuarios SET Nombre = @nombre WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@nombre", nuevoNombre);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            Ejecuta(cmd);
        }

        public static void UpdateUsuarioTelefono(string idUsuario, string nuevoTelefono)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Usuarios SET Telefono = @telefono WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@telefono", nuevoTelefono);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            Ejecuta(cmd);
        }

        public static void UpdateUsuarioDNI(string idUsuario, string nuevoDNI)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Usuarios SET DNI = @dni WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@dni", nuevoDNI);
            cmd.Parameters.AddWithValue("@id", idUsuario);
            Ejecuta(cmd);
        }

        // Actualizar libro
        

        public static void ActualizarTituloLibro(int idLibro, string nuevoTitulo)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Libros SET Titulo = @titulo WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@titulo", nuevoTitulo);
            cmd.Parameters.AddWithValue("@id", idLibro);
            Ejecuta(cmd);
        }

        public static void ActualizarAutorLibro(int idLibro, string nuevoAutor)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Libros SET Escritor = @autor WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@autor", nuevoAutor);
            cmd.Parameters.AddWithValue("@id", idLibro);
            Ejecuta(cmd);
        }

        public static void ActualizarNEjemplares(int idLibro, int nEjemplares)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Libros SET NEjemplares = @nEjemplares WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@nEjemplares", nEjemplares);
            cmd.Parameters.AddWithValue("@id", idLibro);
            Ejecuta(cmd);
        }

        public static void ActualizarPortada(int idLibro, string rutaPortada)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE Libros SET Portada = @portada WHERE ID = @id;"
            );
            cmd.Parameters.AddWithValue("@portada", rutaPortada);
            cmd.Parameters.AddWithValue("@id", idLibro);
            Ejecuta(cmd);
        }

        public static void BorrarLibro(int idLibro)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Libros WHERE ID = @id;");
            cmd.Parameters.AddWithValue("@id", idLibro);
            Ejecuta(cmd);
        }



    }
}
