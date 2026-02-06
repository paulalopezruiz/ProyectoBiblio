namespace Biblioteca.MODELO
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Escritor { get; set; }
        public string Portada { get; set; }   // Ruta de la imagen
        public int NEjemplares { get; set; }  // Total en la biblioteca

        // Número de préstamos activos (se calcula desde la BD)
        public int PrestamosActivos { get; set; }

        // Disponibilidad calculada, no almacenada
        public bool Disponible
        {
            get { return NEjemplares - PrestamosActivos > 0; }
        }

        public Libro(int idLibro, string titulo, string escritor, string portada, int nEjemplares, int prestamosActivos)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Escritor = escritor;
            Portada = portada;
            NEjemplares = nEjemplares;
            PrestamosActivos = prestamosActivos;
        }

        public override string ToString()
        {
            return $"{Titulo} - {Escritor}";
        }
    }
}
