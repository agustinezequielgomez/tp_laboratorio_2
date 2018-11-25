using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TrackingIdRepetidoException"/>.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe la excepcion ocurrida.</param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TrackingIdRepetidoException"/>.
        /// </summary>
        /// <param name="mensaje">Mensaje que describe la excepcion ocurrida.</param>
        /// <param name="inner">Excepcion que es la causa de la excepcion actual (innerException).</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner) : base(mensaje,inner)
        {
        }
    }
}
