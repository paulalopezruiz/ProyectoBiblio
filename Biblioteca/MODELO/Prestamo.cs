using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.MODELO
{
        public class Prestamo
        {
            public int ID_Libro { get; set; }
            public string ID_Usuario { get; set; }
            public DateTime Fecha_Inicio { get; set; }

            // opcional si luego haces devolución
            public DateTime? Fecha_Fin { get; set; }

            public Prestamo(int idLibro, string dniUsuario, DateTime fechaInicio)
            {
                ID_Libro = idLibro;
                ID_Usuario = dniUsuario;
                Fecha_Inicio = fechaInicio;
                Fecha_Fin = null;
            }
        }
    }

