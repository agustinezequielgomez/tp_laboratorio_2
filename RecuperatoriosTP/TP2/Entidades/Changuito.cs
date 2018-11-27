using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region Atributos
        private List<Producto> _productos;
        private int _espacioDisponible;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Changuito"/>.
        /// </summary>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Changuito"/>.
        /// </summary>
        /// <param name="espacioDisponible">Espacio total disponible que tendra el changuito.</param>
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Muestra los datos de los <see cref="Producto"/> en el <see cref="Changuito"/> que sean de un Tipo en especifico.
        /// </summary>
        /// <param name="c"><see cref="Changuito"/> del que se van a mostrar los <see cref="Producto"/>.</param>
        /// <param name="ETipo">Tipo de <see cref="Producto"/> que va a ser mostrado.</param>
        /// <returns>Retorna un <see cref="string"/> conteniendo los datos de los Productos del tipo especificado.</returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto producto in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(producto is Snacks)
                        {
                           sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if(producto is Dulce)
                        {
                           sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if(producto is Leche)
                        {
                            sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Muestra todos los <see cref="Producto"/> dentro de un <see cref="Changuito"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene todos los datos de los <see cref="Producto"/> del <see cref="Changuito"/>.</returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un <see cref="Producto"/> al <see cref="Changuito"/> siempre y cuando este cuente con el espacio disponible.
        /// </summary>
        /// <param name="c"><see cref="Changuito"/> al que se agregara el <see cref="Producto"/>.</param>
        /// <param name="p"><see cref="Producto"/> que se agregara al <see cref="Changuito"/>.</param>
        /// <returns>Retorna el <see cref="Changuito"/> con el <see cref="Producto"/> pasado por parametro agregado a el. De no tener espacio disponible, retorna el mismo <see cref="Changuito"/> pasado por parametro.</returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c._productos.Count < c._espacioDisponible)
            {
                foreach (Producto producto in c._productos)
                {
                    if (producto == p)
                    {
                        return c;
                    }
                }
                c._productos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quita un <see cref="Producto"/> del <see cref="Changuito"/> siempre y cuando este esté agregado a el.
        /// </summary>
        /// <param name="c"><see cref="Changuito"/> del que se quitara el <see cref="Producto"/>.</param>
        /// <param name="p"><see cref="Producto"/> que se quitara del <see cref="Changuito"/>.</param>
        /// <returns>Retorna el <see cref="Changuito"/> con el <see cref="Producto"/> quitado. Si el <see cref="Producto"/> no esta agregado, se retorna el mismo <see cref="Changuito"/> pasado por parametro.</returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto producto in c._productos)
            {
                if (producto == p)
                {
                    c._productos.Remove(producto);
                    break;
                }
            }
            return c;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que especifica los Tipos posibles de producto.
        /// </summary>
        public enum ETipo
        {
            Dulce,
            Leche,
            Snacks,
            Todos,
        }
        #endregion
    }
}
