using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
     public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NacionalidadInvalidaException"/>.
        /// </summary>
        public NacionalidadInvalidaException() : this("La nacionalidad no se condice con el número de DNI")
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NacionalidadInvalidaException"/>.
        /// </summary>
        /// <param name="message">Mensaje que describe la excepcion ocurrida.</param>
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
    }
}
