using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AlumnoRepetidoException"/>.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {
        }
    }
}
