using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca.MODELO
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }

        public Usuario(string nombre, string telefono, string dni)
        {
            Nombre = nombre;
            Telefono = telefono;
            DNI = dni;
        }

        public Usuario(string nombre, string dni)
        {
            Nombre = nombre;
            DNI = dni;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Nombre, DNI);
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;

            return usuario != null &&
                   string.Equals(Nombre, usuario.Nombre, StringComparison.Ordinal) &&
                   string.Equals(Telefono, usuario.Telefono, StringComparison.Ordinal) &&
                   string.Equals(DNI, usuario.DNI, StringComparison.Ordinal);
        }
    }
}