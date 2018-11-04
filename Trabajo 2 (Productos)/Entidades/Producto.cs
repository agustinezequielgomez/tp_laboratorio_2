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
        EMarca marca;
        string codigoDeBarras;
        ConsoleColor colorPrimarioEmpaque;
        #endregion

        #region Constructores
        /// <summary>
        /// Nueva instancia de un objeto Producto
        /// </summary>
        /// <param name="patente">Codigo de barras del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="color">Color del empaque del producto</param>
        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
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
            Pepsico
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns>Retorna los datos del producto</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Convierte explicitamente los datos de un Producto a un String
        /// </summary>
        /// <param name="p">Datos del producto convertidos en String</param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
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
            return (v1.codigoDeBarras == v2.codigoDeBarras);
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
        
    }
}
