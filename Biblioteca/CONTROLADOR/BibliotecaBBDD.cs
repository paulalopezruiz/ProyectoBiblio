using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;


namespace Biblioteca.CONTROLADOR
{
    internal class BibliotecaBBDD
    {
        public static SQLiteConnection Conectar(string bbdd)
        {
            string cadena = ConfigurationManager.ConnectionStrings[bbdd].ConnectionString;
            SQLiteConnection conexion = new SQLiteConnection(cadena);
            conexion.Open();
            return conexion;
        }

        public static SQLiteDataReader GetDataReader(string bbdd, SQLiteCommand cmd)
        {
            try
            {
                SQLiteConnection conexion = Conectar(bbdd);
                cmd.Connection = conexion;
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
