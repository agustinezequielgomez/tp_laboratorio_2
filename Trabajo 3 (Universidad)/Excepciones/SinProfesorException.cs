using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SinProfesorException"/>.
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.")
        {
        }
    }
}
