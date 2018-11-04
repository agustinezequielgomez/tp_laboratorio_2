using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa los atributos estaticos de la clase <see cref="Profesor"/>.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase <see cref="Profesor"/>.
        /// </summary>
        public Profesor()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase <see cref="Profesor"/>.
        /// </summary>
        /// <param name="id">Legajo del Profesor.</param>
        /// <param name="nombre">Nombre del Profesor.</param>
        /// <param name="apellido">Apellido del Profesor.</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de una instancia de un <see cref="Profesor"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene todos los datos del <see cref="Profesor"/></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo que elige al azar dos clases que dara un <see cref="Profesor"/>. 
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
        }

        /// <summary>
        /// Muestra que clase dicta el <see cref="Profesor"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene la clase dictada por el <see cref="Profesor"/></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de una instancia de tipo <see cref="Profesor"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos del <see cref="Profesor"/>.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Verifica si un <see cref="Profesor"/> dicta una clase.
        /// </summary>
        /// <param name="i">Profesor en el cual se verificara si dicta la clase.</param>
        /// <param name="clase">Clase que se verificara si es dictada por el Profesor.</param>
        /// <returns>Retorna <see cref="true"/> si el Profesor dicta la clase, <see cref="false"/> si no la dicta.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Verifica si un <see cref="Profesor"/> no dicta una clase.
        /// </summary>
        /// <param name="i">Profesor en el cual se verificara si no dicta la clase.</param>
        /// <param name="clase">Clase que se verificara si no es dictada por el Profesor.</param>
        /// <returns>Retorna <see cref="true"/> si el Profesor no dicta la clase, <see cref="false"/> si la dicta.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}
