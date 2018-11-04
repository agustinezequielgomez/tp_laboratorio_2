using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructor
        /// <summary>
        /// Instancia un nuevo objeto Snack.
        /// </summary>
        /// <param name="marca">Marca del snack</param>
        /// <param name="patente">Codigo de bararas del Snack</param>
        /// <param name="color">Color del empaque del Snack</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retorna la cantidad de calorias del snack (Los snacks tienen 104 calorías)
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica todos los datos del Snack
        /// </summary>
        /// <returns>Retorna los datos del Snack</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
