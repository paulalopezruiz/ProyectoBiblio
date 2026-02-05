using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Biblioteca.CONTROLADOR
{
    public class BibliotecaBBDD
    {
        private static string ObtenerRutaBBDD()
        {
            string rutaProyecto = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(rutaProyecto, "Biblioteca.db");
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


