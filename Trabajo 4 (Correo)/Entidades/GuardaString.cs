using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension para la clase <see cref="String"/> que guardara una cadena en un archivo de texto.
        /// </summary>
        /// <param name="texto">Cadena a guardar en el archivo de texto.</param>
        /// <param name="archivo">Ruta al archivo de texto.</param>
        /// <returns>Retorna <see cref="true"/> si el archivo logro guardarse, <see cref="false"/> si sucedio un error.</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+@"\"+archivo, true))
                {
                    writer.Write(texto);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
