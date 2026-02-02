using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Biblioteca.CONTROLADOR
{
    public class BibliotecaBBDD
    {
        public static SQLiteConnection Conectar(string bbdd)
        {
            var cs = ConfigurationManager.ConnectionStrings[bbdd];

            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
            {
                throw new Exception(
                    $"No existe la cadena de conexión '{bbdd}' en App.config (connectionStrings)."
                );
            }

            // Validación rápida: debe contener "Data Source="
            // (evita el error de pasar solo una ruta)
            if (!cs.ConnectionString.ToLower().Contains("data source="))
            {
                throw new Exception(
                    $"La cadena '{bbdd}' no es válida. Debe tener formato: " +
                    $"Data Source=RUTA\\archivo.db;Version=3;"
                );
            }

            SQLiteConnection conexion = new SQLiteConnection(cs.ConnectionString);
            conexion.Open();
            return conexion;
        }

        public static SQLiteDataReader GetDataReader(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                SQLiteConnection conexion = Conectar(bbdd);
                cmd.Connection = conexion;

                // Se cerrará la conexión cuando se cierre el reader
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataReader: " + ex.Message);
            }
        }

        public static DataTable GetDataTable(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection conexion = Conectar(bbdd))
                {
                    cmd.Connection = conexion;

                    DataSet ds = new DataSet();
                    ds.Tables.Add("datos");

                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(ds.Tables["datos"]);

                    return ds.Tables["datos"];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en GetDataTable: " + ex.Message);
            }
        }

        public static void Ejecuta(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                using (SQLiteConnection conexion = Conectar(bbdd))
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
