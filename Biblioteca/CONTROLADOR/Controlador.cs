using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Biblioteca.MODELO;

namespace Biblioteca.CONTROLADOR
{
    public class Controlador
    {
        // =========================
        // USUARIOS
        // =========================

        public List<Usuario> ObtenerUsuarios()
        {
            var dt = BibliotecaBBDD.GetDataTable(new SQLiteCommand(
                "SELECT ID, Nombre, Telefono, DNI FROM Usuarios ORDER BY Nombre;"
            ));

            var lista = new List<Usuario>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Usuario(
                    row["ID"].ToString(),
                    row["Nombre"].ToString(),
                    row["Telefono"].ToString(),
                    row["DNI"].ToString()
                ));
            }
            return lista;
        }

        public void InsertarUsuario(string nombre, string telefono, string dni)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO Usuarios (Nombre, Telefono, DNI) VALUES (@nombre, @telefono, @dni);"
            );
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@dni", dni);
            BibliotecaBBDD.Ejecuta(cmd);
        }

        public void BorrarUsuario(string dni)
        {
            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM Usuarios WHERE DNI = @dni;");
            cmd.Parameters.AddWithValue("@dni", dni);
            BibliotecaBBDD.Ejecuta(cmd);
        }

        public List<Usuario> BuscarUsuariosPorNombre(string texto)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT ID, Nombre, Telefono, DNI FROM Usuarios WHERE Nombre LIKE @patron ORDER BY Nombre;"
            );
            cmd.Parameters.AddWithValue("@patron", texto + "%");

            DataTable dt = BibliotecaBBDD.GetDataTable(cmd);
            var lista = new List<Usuario>();
            foreach (DataRow row in dt.Rows)
            {
                lista.Add(new Usuario(
                    row["ID"].ToString(),
                    row["Nombre"].ToString(),
                    row["Telefono"].ToString(),
                    row["DNI"].ToString()
                ));
            }
            return lista;
        }

        public string ObtenerNombreUsuario(string idUsuario) => BibliotecaBBDD.GetNombreUsuario(idUsuario);
        public string ObtenerDNIUsuario(string nombreUsuario) => BibliotecaBBDD.GetDNIUsuario(nombreUsuario);
        public string ObtenerIDUsuario(string dniUsuario) => BibliotecaBBDD.GetIDUsuario(dniUsuario);

        // =========================
        // LIBROS
        // =========================

        public List<Libro> ObtenerLibros() => BibliotecaBBDD.GetLibros();
        public string ObtenerTituloLibro(int idLibro) => BibliotecaBBDD.GetTituloLibro(idLibro);
        public int ObtenerIDLibro(string titulo) => BibliotecaBBDD.GetIDLibro(titulo);

        public List<string> ObtenerTitulosLibros()
        {
            var titulos = new List<string>();
            foreach (var l in BibliotecaBBDD.GetLibros())
                titulos.Add(l.Titulo);
            return titulos;
        }

        public void InsertarLibro(string titulo, string autor, string portada, int nEjemplares)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO Libros (Titulo, Escritor, Portada, NEjemplares) " +
                "VALUES (@titulo, @autor, @portada, @nEjemplares);"
            );
            cmd.Parameters.AddWithValue("@titulo", titulo);
            cmd.Parameters.AddWithValue("@autor", autor);
            cmd.Parameters.AddWithValue("@portada", portada);
            cmd.Parameters.AddWithValue("@nEjemplares", nEjemplares);
            BibliotecaBBDD.Ejecuta(cmd);
        }

        // =========================
        // PRÉSTAMOS
        // =========================

        // Comprueba si hay ejemplares disponibles
        public bool LibroDisponible(int idLibro)
        {
            // Traemos todos los libros y buscamos el que corresponda
            var libro = BibliotecaBBDD.GetLibros().Find(l => l.IdLibro == idLibro);
            if (libro == null) return false;

            int disponibles = libro.NEjemplares - libro.PrestamosActivos;
            return disponibles > 0;
        }

        // Inserta préstamo solo si hay ejemplares disponibles
        public void InsertarPrestamo(int idLibro, int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        {
            if (!LibroDisponible(idLibro))
                throw new Exception("No se puede realizar el préstamo: todos los ejemplares están prestados.");

            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO Prestamos (ID_Libro, ID_Usuario, Fecha_Inicio, Fecha_Fin, Devuelto) " +
                "VALUES (@libro, @usuario, @inicio, @fin, @devuelto);"
            );
            cmd.Parameters.AddWithValue("@libro", idLibro);
            cmd.Parameters.AddWithValue("@usuario", idUsuario);
            cmd.Parameters.AddWithValue("@inicio", fechaInicio);
            cmd.Parameters.AddWithValue("@fin", fechaFin);
            cmd.Parameters.AddWithValue("@devuelto", 0);

            BibliotecaBBDD.Ejecuta(cmd);
        }

        // =========================
        // MÉTODOS GENERALES
        // =========================

        public void EjecutarComando(SQLiteCommand cmd) => BibliotecaBBDD.Ejecuta(cmd);
        public DataTable GetDataTable(SQLiteCommand cmd) => BibliotecaBBDD.GetDataTable(cmd);

        //EDICION DE USUARIOS Y LIBROS

      



    }
}
