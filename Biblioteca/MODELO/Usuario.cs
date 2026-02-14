using System;

namespace Biblioteca.MODELO
{
    public class Usuario
    {
       
        public string ID { get; set; }        
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }


        public Usuario(string id, string nombre, string telefono, string dni)
        {
            ID = id;
            Nombre = nombre;
            Telefono = telefono;
            DNI = dni;
        }

        public Usuario(string nombre, string telefono, string dni)
        {
            ID = null;
            Nombre = nombre;
            Telefono = telefono;
            DNI = dni;
        }

        public Usuario(string nombre, string dni)
        {
            ID = null;
            Nombre = nombre;
            DNI = dni;
            Telefono = null;
        }

 
        public override string ToString()
        {
            return string.Format("{0} - {1}", Nombre, DNI);
        }

        public override bool Equals(object obj)
        {
            Usuario usuario = obj as Usuario;
            return usuario != null &&
                   string.Equals(ID, usuario.ID, StringComparison.Ordinal) &&
                   string.Equals(Nombre, usuario.Nombre, StringComparison.Ordinal) &&
                   string.Equals(Telefono, usuario.Telefono, StringComparison.Ordinal) &&
                   string.Equals(DNI, usuario.DNI, StringComparison.Ordinal);
        }

       
    }
}
