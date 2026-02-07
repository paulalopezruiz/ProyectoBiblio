using System;

namespace Biblioteca.MODELO
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Escritor { get; set; }
        public string Portada { get; set; }
        public int NEjemplares { get; set; }
        public int PrestamosActivos { get; set; } // calculado dinámicamente

        // Disponibilidad calculada
        public bool Disponible => NEjemplares - PrestamosActivos > 0;

        public Libro(int idLibro, string titulo, string escritor, string portada, int nEjemplares, int prestamosActivos)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Escritor = escritor;
            Portada = portada;
            NEjemplares = nEjemplares;
            PrestamosActivos = prestamosActivos;
        }
    }
}
