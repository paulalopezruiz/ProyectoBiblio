using System;

namespace Biblioteca.MODELO
{
    public class Usuario
    {
        // =========================
        // PROPIEDADES
        // =========================
        public string ID { get; set; }          // ID interno en la BD
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }

        // =========================
        // CONSTRUCTORES
        // =========================
        // Constructor completo con ID
        public Usuario(string id, string nombre, string telefono, string dni)
        {
            ID = id;
            Nombre = nombre;
            Telefono = telefono;
            DNI = dni;
        }

        // Constructor sin ID (se puede asignar después)
        public Usuario(string nombre, string telefono, string dni)
        {
            ID = null;
            Nombre = nombre;
            Telefono = telefono;
            DNI = dni;
        }

        // Constructor con nombre y DNI
        public Usuario(string nombre, string dni)
        {
            ID = null;
            Nombre = nombre;
            DNI = dni;
            Telefono = null;
        }

        // =========================
        // MÉTODOS
        // =========================
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
