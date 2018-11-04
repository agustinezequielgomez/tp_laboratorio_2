using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene o establece el Apellido de una <see cref="Persona"/>
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Obtiene o establece el DNI de una <see cref="Persona"/>
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }

            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        /// <summary>
        /// Obtiene o establece la Nacionalidad de una <see cref="Persona"/>
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
               return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de una <see cref="Persona"/>
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Establece el DNI de una persona (de tipo <see cref="string"/>)
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la Clase <see cref="Persona"/>.
        /// </summary>
        public Persona()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase <see cref="Persona"/>.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase <see cref="Persona"/>.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona (de tipo <see cref="int"/>)</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la Clase persona.
        /// </summary>
        /// <param name="nombre">Nombre de la Persona</param>
        /// <param name="apellido">Apellido de la Persona</param>
        /// <param name="dni">DNI de la Persona (de tipo <see cref="string"/>)</param>
        /// <param name="nacionalidad">Nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la <see cref="Persona"/>
        /// </summary>
        /// <returns>Retorna un <see cref="string"/> con los datos de la <see cref="Persona"/></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Valida que un DNI este entre los rangos apropiados para las distintas nacionalidades.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que servira para establecer los rangos en los que se debera encontrar el DNI</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>Retorna el DNI validado. Si el DNI es invalido para la nacionalidad, lanza <see cref="NacionalidadInvalidaException"/>.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Valida que el DNI posea un formato correcto
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que servira para establecer los rangos en los que se debera encontrar el DNI</param>
        /// <param name="dato">DNI a validar (de tipo <see cref="string"/>)</param>
        /// <returns>Retorna el DNI validado. Si el DNI ingresado posee caracteres invalidos, lanza <see cref="DniInvalidoException"/>. </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int retorno = 0;
            if (dato.Length >= 1 && dato.Length <= 8 && (int.TryParse(dato, out dni)))
            {
                retorno = dni;
            }
            else
            {
                throw new DniInvalidoException();
            }
            return retorno;
        }

        /// <summary>
        /// Valida que una cadena no posea numeros u otros caracteres.
        /// </summary>
        /// <param name="dato">Dato a validar</param>
        /// <returns>Retorna un <see cref="string"/> que contiene la cadena validada, o una cadena vacia si el dato es incorrecto.</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            string retorno = "";
            foreach (char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Enumerado
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
