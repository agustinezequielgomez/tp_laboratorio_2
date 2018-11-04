using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece una <see cref="List{Alumno}"/> de tipo <see cref="Alumno"/> que contiene los Alumnos que tomaran la clase de la <see cref="Jornada"/>.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Obtiene o establece las Clases que se dictaran en la <see cref="Jornada"/>.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el <see cref="Profesor"/> que dictara clases en la <see cref="Jornada"/>.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Jornada"/>.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Jornada"/>.
        /// </summary>
        /// <param name="clase">Clase que se dictara en la Jornada.</param>
        /// <param name="instructor">Profseor que dictara la Clase de la Jornada.</param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de una <see cref="Jornada"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene todos los datos de la <see cref="Jornada"/>.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Guarda los datos de la <see cref="Jornada"/> en un archivo de texto.
        /// </summary>
        /// <param name="jornada"><see cref="Jornada"/> que se guardara en un archivo de texto.</param>
        /// <returns>Retorna <see cref="true"/> si logro guardar la <see cref="Jornada"/> con exito, <see cref="false"/> si no lo logro.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();   
            return texto.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"../../Archivos/Jornadas.txt"), jornada.ToString()); //Archivo localizado en: tp_laboratorio_2/Trabajo 3/Console TP3/Archivos/Jornadas.txt
        }

        /// <summary>
        /// Lee una <see cref="Jornada"/> de un archivo de texto.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> que contiene la <see cref="Jornada"/> leida del archivo.</returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string retorno = "";
            texto.Leer((AppDomain.CurrentDomain.BaseDirectory + @"../../Archivos/Jornadas.txt"), out retorno); //Archivo localizado en: tp_laboratorio_2/Trabajo 3/Console TP3/Archivos/Jornadas.txt
            return retorno;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un <see cref="Alumno"/> a la <see cref="Jornada"/>, validando que este no este previamente agregado.
        /// </summary>
        /// <param name="j">Jornada a la que se le va a agregar un Alumno.</param>
        /// <param name="a">Alumno a agregar a la Jornada.</param>
        /// <returns>Retorna una <see cref="Jornada"/> con el alumno ya agregado a ella si este no forma parte. Si el alumno forma parte de la <see cref="Jornada"/>, se lanza <see cref="AlumnoRepetidoException"/>.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j!=a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }

        /// <summary>
        /// Comprueba si el <see cref="Alumno"/> ya forma parte de la <see cref="Jornada"/>.
        /// </summary>
        /// <param name="j">Jornada en la que se comprueba si el Alumno ya forma parte de ella.</param>
        /// <param name="a">Alumno que se comprabara si forma parte de la Jornada.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno forma parte de la Jornada, <see cref="false"/> si no forma parte.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if(alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si el <see cref="Alumno"/> no forma parte de la <see cref="Jornada"/>.
        /// </summary>
        /// <param name="j">Jornada en la que se comprueba si el Alumno no forma parte de ella.</param>
        /// <param name="a">Alumno que se comprabara si no forma parte de la Jornada.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno no forma parte de la Jornada, <see cref="false"/> si forma parte.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion
    }
}
