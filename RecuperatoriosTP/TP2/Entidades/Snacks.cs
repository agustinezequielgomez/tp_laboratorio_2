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
        /// Inicializa una nueva instancia de la clase <see cref="Snacks"/>.
        /// </summary>
        /// <param name="marca">Marca del Snack.</param>
        /// <param name="patente">Codigo de bararas del Snack.</param>
        /// <param name="color">Color del empaque del Snack.</param>
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene la cantidad de calorias de un <see cref="Snacks"/>.
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
        /// Muestra todos los datos del <see cref="Snacks"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos del <see cref="Snacks"/>.</returns>
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
