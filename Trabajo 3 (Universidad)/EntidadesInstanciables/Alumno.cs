using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Alumno"/>.
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Alumno"/>.
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Alumno"/>.
        /// </summary>
        /// <param name="id">ID del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">DNI del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de la cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de un <see cref="Alumno"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene todos los datos del <see cref="Alumno"/></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendFormat("\nESTADO DE CUENTA: {0}", "Cuota al día");
                    break;
                case EEstadoCuenta.Deudor:
                case EEstadoCuenta.Becado:
                    sb.AppendFormat("\nESTADO DE CUENTA: {0}", this.estadoCuenta);
                    break;
                default:
                    break;
            }
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Muestra a que clase asiste el <see cref="Alumno"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene la clase tomada por el <see cref="Alumno"/></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("\nTOMA CLASES DE {0}", this.claseQueToma);
        }

        /// <summary>
        /// Hace publicos los datos de una instancia de tipo <see cref="Alumno"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos del <see cref="Alumno"/>.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un <see cref="Alumno"/> toma una Clase.
        /// </summary>
        /// <param name="a">Alumno en el cual se verificara si toma la Clase.</param>
        /// <param name="clase">Clase que se verificara si es tomada por el Alumno.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno toma la clase, <see cref="false"/> si no la toma.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Comrpueba si un <see cref="Alumno"/> no toma una Clase.
        /// </summary>
        /// <param name="a">Alumno en el cual se verificara si no toma la Clase.</param>
        /// <param name="clase">Clase que se verificara si no es tomada por el Alumno.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno  no toma la clase, <see cref="false"/> si la toma.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
        #endregion

        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
