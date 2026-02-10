using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
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
            // =========================
            // VALIDACIONES
            // =========================
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El teléfono no puede estar vacío.");

            if (!telefono.All(char.IsDigit))
                throw new Exception("El teléfono solo puede contener números.");

            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("El DNI no puede estar vacío.");

            if (!EsDNIValido(dni))
                throw new Exception("El DNI no tiene un formato válido.");

            // =========================
            // INSERTAR EN BBDD
            // =========================
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO Usuarios (Nombre, Telefono, DNI) VALUES (@nombre, @telefono, @dni);"
            );
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@dni", dni);
            BibliotecaBBDD.Ejecuta(cmd);
        }

   
        private bool EsDNIValido(string dni)
        {
            if (dni.Length != 9) return false;

            string numeros = dni.Substring(0, 8);
            char letra = char.ToUpper(dni[8]);

            if (!numeros.All(char.IsDigit)) return false;

            string letrasDNI = "TRWAGMYFPDXBNJZSQVHLCKE";
            int num = int.Parse(numeros);
            char letraCorrecta = letrasDNI[num % 23];

            return letra == letraCorrecta;
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

        // =========================
        // EDICIÓN DE USUARIOS
        // =========================

        public void ActualizarNombreUsuario(string idUsuario, string nuevoNombre)
        {
            BibliotecaBBDD.UpdateUsuarioNombre(idUsuario, nuevoNombre);
        }

        public void ActualizarTelefonoUsuario(string idUsuario, string nuevoTelefono)
        {
            BibliotecaBBDD.UpdateUsuarioTelefono(idUsuario, nuevoTelefono);
        }

        public void ActualizarDNIUsuario(string idUsuario, string nuevoDNI)
        {
            BibliotecaBBDD.UpdateUsuarioDNI(idUsuario, nuevoDNI);
        }

        // =========================
        // ACTUALIZAR LIBRO
        // =========================
        public void ActualizarTituloLibro(int idLibro, string nuevoTitulo)
        {
            BibliotecaBBDD.ActualizarTituloLibro(idLibro, nuevoTitulo);
        }

        public void ActualizarAutorLibro(int idLibro, string nuevoAutor)
        {
            BibliotecaBBDD.ActualizarAutorLibro(idLibro, nuevoAutor);
        }

        public void ActualizarNEjemplares(int idLibro, int nEjemplares)
        {
            BibliotecaBBDD.ActualizarNEjemplares(idLibro, nEjemplares);
        }

        public void ActualizarPortadaLibro(int idLibro, string rutaPortada)
        {
            BibliotecaBBDD.ActualizarPortada(idLibro, rutaPortada);
        }


        // BORRAR LIBRO
        public void BorrarLibro(int idLibro)
        {
            BibliotecaBBDD.BorrarLibro(idLibro);
        }




    }
}
