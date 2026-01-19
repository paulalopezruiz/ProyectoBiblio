namespace Biblioteca.MODELO
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }

        public Libro(int idLibro, string titulo)
        {
            IdLibro = idLibro;
            Titulo = titulo;
        }

        public override string ToString() => Titulo;
    }
}
