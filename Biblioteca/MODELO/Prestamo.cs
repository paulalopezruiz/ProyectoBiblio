using System;

namespace Biblioteca.MODELO
{
    public class Prestamo
    {
        public int ID_Libro { get; set; }
        public string ID_Usuario { get; set; } // se usará para mostrar texto
        public DateTime Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public bool Devuelto { get; set; } // true si devuelto, false si no

        public Prestamo(int idLibro, string idUsuario, DateTime fechaInicio, int devuelto = 0)
        {
            ID_Libro = idLibro;
            ID_Usuario = idUsuario;
            Fecha_Inicio = fechaInicio;
            Fecha_Fin = null;
            Devuelto = devuelto == 1; // convierte 0/1 a bool
        }
    }
}


