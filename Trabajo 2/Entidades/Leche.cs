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
      
        #region Constructores
        /// <summary>
        /// Nueva instancia de un objeto Leche. Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color del empaque de la leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color) : this(marca,patente,color,ETipo.Entera)
        { 
        }

        
        /// <summary>
        /// Nueva instancia de un objeto Leche que acepta especificacion del TIPO
        /// </summary>
        /// <param name="marca">Marca de la leche</param>
        /// <param name="patente">Codigo de barras de la leche</param>
        /// <param name="color">Color del empaque de la leche</param>
        /// <param name="tipo">Tipo de leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo) : base(patente, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado que define los tipos posibles de Leche
        /// </summary>
        public enum ETipo
        {
            Entera,
            Descremada
        }
        ETipo tipo;
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retorna la cantidad de calorias de la leche (Las leches tienen 20 calorías)
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
        /// Publica todos los datos de la leche
        /// </summary>
        /// <returns>Retorna los datos de la leche</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}\r\n\n", this.tipo.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
