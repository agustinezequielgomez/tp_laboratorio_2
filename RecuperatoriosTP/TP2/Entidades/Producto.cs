using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Atributos
        private EMarca _marca;
        private string _codigoDeBarras;
        private ConsoleColor _colorPrimarioEmpaque;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa un nuevo objeto de la clase <see cref="Producto"/>.
        /// </summary>
        /// <param name="patente">Codigo de barras del <see cref="Producto"/>.</param>
        /// <param name="marca">Marca del <see cref="Producto"/>.</param>
        /// <param name="color">Color del empaque del <see cref="Producto"/>.</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this._codigoDeBarras = patente;
            this._marca = marca;
            this._colorPrimarioEmpaque = color;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la cantidad de calorias de un <see cref="Producto"/>.
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra todos los datos del <see cref="Producto"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="String"/> conteniendo los datos del <see cref="Producto"/>.</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Convierte explicitamente los datos de un <see cref="Producto"/> a un <see cref="string"/>.
        /// </summary>
        /// <param name="p">Datos del <see cref="Producto"/> que se convertiran a <see cref="string"/>.</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara si dos productos son iguales. Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1">Primer Producto</param>
        /// <param name="v2">Segundo Prodcuto</param>
        /// <returns>True si son iguales; False si son distintos</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Compara si dos productos son distintos. Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1">Primer producto</param>
        /// <param name="v2">Segundo producto</param>
        /// <returns>True si son distintos, False si son iguales</returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return !(v1 == v2);
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que define las distintas marcas de producto
        /// </summary>
        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico,
        }
        #endregion

    }
}
