using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece una <see cref="List{T}"/> de tipo <see cref="Alumno"/> que contiene los Alumnos que forman parte de la <see cref="Universidad"/>.
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
        /// Obtiene o establece una <see cref="List{T}"/> de tipo <see cref="Profesor"/> que contiene los Profesores que dictan clases en la <see cref="Universidad"/>.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Obtiene o establece una <see cref="List{T}"/> de tipo <see cref="Jornada"/> que contiene las Jornadas que forman parte de la <see cref="Universidad"/>.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }

            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad que permite obtener o establecer una <see cref="Jornada"/> concreta.
        /// </summary>
        /// <param name="i">Indice en el cual se obtendra o establecera una Jornada.</param>
        /// <returns>Retorna la Jornada correspondiente al indice</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i >= 0 && i <this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if(i >= 0 && i < this.Jornadas.Count)
                {
                    this.Jornadas[i] = value;
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Universidad"/>.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Serializa una <see cref="Universidad"/> en un archivo Xml
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>Retorna <see cref="true"/> si se serializo exitosamente, <see cref="false"/> si no fue posible serializar.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();              
            return xml.Guardar((AppDomain.CurrentDomain.BaseDirectory + @"../../Archivos/Universidad.xml"), uni); //Archivo localizado en: tp_laboratorio_2/Trabajo 3/Console TP3/Archivos/Universidad.xml
        }

        /// <summary>
        /// Lee una <see cref="Universidad"/> de un archivo xml.
        /// </summary>
        /// <returns>Retorna una <see cref="Universidad"/> creada con el archivo leido.</returns>
        public static Universidad Leer()
        {
            Universidad retorno = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer((AppDomain.CurrentDomain.BaseDirectory + @"../../Archivos/Universidad.xml"), out retorno);//Archivo localizado en: tp_laboratorio_2/Trabajo 3/Console TP3/Archivos/Universidad.xml
            return retorno;
        }

        /// <summary>
        /// Muestra los datos de una <see cref="Universidad"/>.
        /// </summary>
        /// <param name="uni">Universidad de la que se mostraran los datos.</param>
        /// <returns>Retorna un <see cref="string"/> con los datos de la Universidad.</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.Append(jornada.ToString());
                sb.AppendLine("<-------------------------------------------------->\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los daatos de una <see cref="Universidad"/>.
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos de la Universidad.</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba si un <see cref="Alumno"/> esta inscriptio en una <see cref="Universidad"/>.
        /// </summary>
        /// <param name="g">Universidad en la que se comprueba si el Alumno esta inscripto.</param>
        /// <param name="a">Alumno que se comprueba si esta inscripto en la Universidad.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno esta inscripto, <see cref="false"/> si no esta inscripto.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in g.Alumnos)
            {
                if(a == alumno)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si un <see cref="Alumno"/> no esta inscriptio en una <see cref="Universidad"/>.
        /// </summary>
        /// <param name="g">Universidad en la que se comprueba si el Alumno no esta inscripto.</param>
        /// <param name="a">Alumno que se comprueba si no esta inscripto en la Universidad.</param>
        /// <returns>Retorna <see cref="true"/> si el Alumno no esta inscripto, <see cref="false"/> si esta inscripto.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si un <see cref="Profesor"/> da clases en una <see cref="Universidad"/>.
        /// </summary>
        /// <param name="g">Universidad en la que se comprueba si el Profesor da clases.</param>
        /// <param name="i">Profesor que se comprueba si da clases en la Universidad</param>
        /// <returns>Retorna <see cref="true"/> si el profesor da clases en la Universidad, <see cref="false"/> si no da clases.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor profesor in g.Instructores)
            {
                if(profesor == i)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Comprueba si un <see cref="Profesor"/> no da clases en una <see cref="Universidad"/>.
        /// </summary>
        /// <param name="g">Universidad en la que se comprueba si el Profesor no da clases.</param>
        /// <param name="i">Profesor que se comprueba si no da clases en la Universidad</param>
        /// <returns>Retorna <see cref="true"/> si el profesor no da clases en la Universidad, <see cref="false"/> si da clases.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Comprueba si hay un <see cref="Profesor"/> existente en la <see cref="Universidad"/> que pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad en la que se comprueba si hay un profesor existente para dar la clase.</param>
        /// <param name="clase">Clase que se quiere dar.</param>
        /// <returns>Retorna el primer <see cref="Profesor"/> que sea capaz de dar la clase. Si no hay ninguno capaz de dar la clase lanza <see cref="SinProfesorException"/>.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if(profesor == clase)
                {
                    retorno = profesor;
                    break;
                }
            }

            if(retorno is null)
            {
                throw new SinProfesorException();
            }
           return retorno;
        }

        /// <summary>
        /// Comprueba si no hay un <see cref="Profesor"/> existente en la <see cref="Universidad"/> que pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad en la que se comprueba si no hay un profesor para dar la clase.</param>
        /// <param name="clase">Clase que se quiere dar.</param>
        /// <returns>Retorna el primer <see cref="Profesor"/> que no pueda dar la clase. Si no hay ninguno que no pueda dar la clase, se retorna <see cref="null"/>.</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if(profesor!=clase)
                {
                    retorno = profesor;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Agrega una clase a la <see cref="Universidad"/>.
        /// </summary>
        /// <param name="g">Universidad a la que se le agregara la clase.</param>
        /// <param name="clase">Clase que se agregara a la Universidad.</param>
        /// <returns>Retorna una <see cref="Universidad"/> con la clase agregada. Si no fue posible agregarla, retorna la misma <see cref="Universidad"/> pasada por parametro.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada;
            Profesor profesor = (g == clase);
            jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    jornada +=alumno;
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un <see cref="Alumno"/> a la <see cref="Universidad"/>, comprobando que el <see cref="Alumno"/> no este repetido.
        /// </summary>
        /// <param name="u">Universidad a la que se agregara el Alumno.</param>
        /// <param name="a">Alumno que se agregara a la Universidad.</param>
        /// <returns>Retorna una <see cref="Universidad"/> con el <see cref="Alumno"/> agregado. Si el Alumno esta repetido y no fue posible agregarlo, se lanza <see cref="AlumnoRepetidoException"/>.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrega un <see cref="Profesor"/> a la <see cref="Universidad"/>, comprobando que el <see cref="Profesor"/> no este repetido.
        /// </summary>
        /// <param name="u">Universidad en la que se agregara el Profesor.</param>
        /// <param name="i">Profesor a agregar a la Universidad.</param>
        /// <returns>Retorna una <see cref="Universidad"/> con el <see cref="Profesor"/> agregado. Si no fue posible agregarlo, retorna la misma <see cref="Universidad"/> pasada por parametro.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u!=i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion

        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion
    }
}
