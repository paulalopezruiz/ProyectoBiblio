using System;

namespace Biblioteca.MODELO
{
    public class Prestamo
    {
        public int ID { get; set; }         
        public int ID_Libro { get; set; }   
        public string ID_Usuario { get; set; } 
        public DateTime Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; } 
        public bool Devuelto { get; set; }

        public Prestamo(int id, int idLibro, string idUsuario, DateTime fechaInicio, int devuelto = 0)
        {
            ID = id;
            ID_Libro = idLibro;
            ID_Usuario = idUsuario;
            Fecha_Inicio = fechaInicio;
            Fecha_Fin = fechaInicio.AddDays(15); // Fecha límite por defecto
            Devuelto = devuelto == 1;
        }

        public int DevueltoParaBD()
        {
            return Devuelto ? 1 : 0;
        }
    }
}
