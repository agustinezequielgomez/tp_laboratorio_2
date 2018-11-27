using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Atributos
        private ETipo _tipo;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de tipo <see cref="Leche"/>. Por defecto, <see cref="ETipo"/> será <see cref="ETipo.Entera"/>.
        /// </summary>
        /// <param name="marca">Marca de la <see cref="Leche"/></param>
        /// <param name="patente">Codigo de barras de la <see cref="Leche"/></param>
        /// <param name="color">Color del empaque de la <see cref="Leche"/></param>
        public Leche(EMarca marca, string patente, ConsoleColor color) : this(marca,patente,color,ETipo.Entera)
        { 
        }


        /// <summary>
        /// Nueva instancia de un objeto Leche que acepta especificacion del TIPO
        /// </summary>
        /// <param name="marca">Marca de la <see cref="Leche"/></param>
        /// <param name="patente">Codigo de barras de la <see cref="Leche"/></param>
        /// <param name="color">Color del empaque de la <see cref="Leche"/></param>
        /// <param name="tipo">Tipo de <see cref="Leche"/></param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base(patente, marca, color)
        {
            this._tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la cantidad de calorias de una <see cref="Leche"/>.
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de una <see cref="Leche"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene los datos de la <see cref="Leche"/>.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}\r\n\n", this._tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que define los tipos posibles de Leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada,
        }
        #endregion
    }
}
