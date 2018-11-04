using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Universitario"/>.
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Universitario"/>. 
        /// </summary>
        /// <param name="legajo">Legajo del Universitario.</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">DNI del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de un <see cref="Universitario"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos del <see cref="Universitario"/></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NUMERO: {0}\n", this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto sin implementacion.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara un <see cref="object"/> con un <see cref="Universitario"/>
        /// </summary>
        /// <param name="obj">Objeto a comparar con la instancia de <seealso cref="Universitario"/></param>
        /// <returns>Retorna <see cref="true"/> si son iguales, <see cref="false"/> si no lo son.</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Universitario)
            {
                retorno = (((Universitario)obj) == this);
            }
            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Compara si dos instancias de tipo <see cref="Universitario"/> son iguales.
        /// </summary>
        /// <param name="pg1">Primera instancia a comparar.</param>
        /// <param name="pg2">Segunda instancia a comparar.</param>
        /// <returns>Retorna <see cref="true"/> si son iguales, <see cref="false"/> si no lo son.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo);
        }

        /// <summary>
        /// Compara si dos instancias de tipo <see cref="Universitario"/> son distintas.
        /// </summary>
        /// <param name="pg1">Primera instancia a comparar.</param>
        /// <param name="pg2">Segunda instancia a comparar.</param>
        /// <returns>Retorna <see cref="true"/> si son distintas, <see cref="false"/> si no lo son. </returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
