using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo que Guarda los datos especificados en un Archivo.
        /// </summary>
        /// <param name="archivo">Ruta al Archivo.</param>
        /// <param name="datos">Datos a guardar en el Archivo</param>
        /// <returns>Retorna <see cref="true"/> si el Archivo se guardo exitosamente, <see cref="false"/> si no pudo guardarse.</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo que Lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta al Archivo.</param>
        /// <param name="datos">Parametro de salida de los datos</param>
        /// <returns>Retorna <see cref="true"/> si el Archivo se leyó exitosamente, <see cref="false"/> si no pudo leerse.</returns>
        bool Leer(string archivo, out T datos);
    }
}
