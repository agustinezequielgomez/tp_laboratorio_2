using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ArchivosException"/>.
        /// </summary>
        /// <param name="innerException">Excepcion que es causa de la excepcion actual (innerException)</param>
        public ArchivosException(Exception innerException) : base("Error en el archivo",innerException)
        {
        }
    }
}
