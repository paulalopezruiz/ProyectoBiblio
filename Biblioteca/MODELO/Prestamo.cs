using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.MODELO
{
        public class Prestamo
        {
            public int IdLibro { get; set; }
            public string DNIUsuario { get; set; }
            public DateTime FechaInicio { get; set; }

            // opcional si luego haces devolución
            public DateTime? FechaFin { get; set; }

            public Prestamo(int idLibro, string dniUsuario, DateTime fechaInicio)
            {
                IdLibro = idLibro;
                DNIUsuario = dniUsuario;
                FechaInicio = fechaInicio;
                FechaFin = null;
            }
        }
    }

