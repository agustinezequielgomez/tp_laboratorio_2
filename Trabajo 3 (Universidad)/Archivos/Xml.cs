using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa un objeto de cualquier tipo en un archivo xml. 
        /// </summary>
        /// <param name="archivo">Ruta al archivo xml.</param>
        /// <param name="datos">Objeto a serializar.</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se serializo exitosamente. De no ser asi se lanza <see cref="ArchivosException"/>.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa un archivo xml y retorna el contenido como un objeto.
        /// </summary>
        /// <param name="archivo">Ruta al archivo xml.</param>
        /// <param name="datos">Parametro de salida que retornara el objeto deserializado.</param>
        /// <returns>Retorna <see cref="true"/> si se deserializo exitosamente. De no ser asi se lanza <see cref="ArchivosException"/></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T) xml.Deserialize(reader);
                    retorno = true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
