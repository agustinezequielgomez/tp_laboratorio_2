using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Atributos
        private string mensajeBase;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DniInvalidoException"/>.
        /// </summary>
        public DniInvalidoException() : this("Formato de DNI invalido.")
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DniInvalidoException"/>.
        /// </summary>
        /// <param name="e">Excepcion que es causa de la excepcion actual (innerException)</param>
        public DniInvalidoException(Exception e) : base("Formato de DNI invalido.",e)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DniInvalidoException"/>.
        /// </summary>
        /// <param name="message">Mensaje que describe el error ocurrido</param>
        public DniInvalidoException(string message) :  base(message)
        {
            this.mensajeBase = message;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="DniInvalidoException"/>.
        /// </summary>
        /// <param name="message">Mensaje que describe el error ocurrido</param>
        /// <param name="e">Excepcion que es causa de la excepcion actual (innerException)</param>
        public DniInvalidoException(string message, Exception e) : base(message,e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
