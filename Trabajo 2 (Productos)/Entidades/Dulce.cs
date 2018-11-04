using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructor
        /// <summary>
        /// Nueva instancia de un objeto Dulce
        /// </summary>
        /// <param name="marca">Marca del Dulce</param>
        /// <param name="patente">Codigo de barras del Dulce</param>
        /// <param name="color">Color del empaque del dulce</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente,marca,color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retorna la cantidad de calorias del dulce. (Los dulces tienen 80 calorías)
        /// </summary>
        /// 
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Dulce
        /// </summary>
        /// <returns>Retorna los datos del dulce</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
