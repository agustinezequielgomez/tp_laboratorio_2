using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IMostrar<T>
    {
        /// <summary>
        /// Muestra los elementos de una clase que implemente la interfaz <see cref="IMostrar{T}"/>.
        /// </summary>
        /// <param name="elemento">Elemento a mostrar.</param>
        /// <returns>Retorna un <see cref="string"/> con los datos del elemento pasado por parametro.</returns>
        string MostrarDatos(IMostrar<T> elemento);
    }
}
