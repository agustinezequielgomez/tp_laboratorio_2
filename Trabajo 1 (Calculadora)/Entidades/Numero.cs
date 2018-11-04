using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene la logica para operar Numeros entre si, convertirlos de Binario a decimal y viceversa
    /// </summary>
    public class Numero
    {
        #region Atributos
        /// <summary>
        /// Numero con el que se realizaran las operaciones
        /// </summary>
        private double _numero;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que le asigna un valor al campo _numero de la clase Numero
        /// </summary>
        private string SetNumero
        {
            set
            {
                _numero = ValidarNumero(value);
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor que inicializa en 0 a un objeto de tipo Numero
        /// </summary>
        public Numero() : this(0)
        {

        }

        /// <summary>
        /// Constructor que inicializa a un objeto de tipo Numero con el valor pasado por parametro
        /// </summary>
        /// <param name="numero">Numero con el que se va a inicializar al objeto</param>
        public Numero(double numero) : this(numero.ToString())
        {

        }

        /// <summary>
        /// Constructor que inicializa a un objeto de tipo Numero con el valor de tipo string pasado por parametro
        /// </summary>
        /// <param name="strNumero">Valor con el que se va a inicializar al objeto</param>
        public Numero(string strNumero) 
        {
            SetNumero = strNumero;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que pasa un numero de binario a decimal
        /// </summary>
        /// <param name="binario">Numero binario en formato string</param>
        /// <returns>Retorna el numero convertido a decimal o "Valor invalido" si el valor ingresado es incorrecto</returns>
        public static string BinarioDecimal(string binario)
        {
            int[] cadenaInt = new int[binario.Length];
            string retorno = "";
            double numero = 0;
            bool flag = true;
            int i;
            for (i = 0; i < binario.Length; i++)
            {
                cadenaInt[i] = (int)char.GetNumericValue(binario[i]);
                if (cadenaInt[i] != 0 && cadenaInt[i] != 1)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                for (i = 0; i < binario.Length; i++)
                {
                    numero += (cadenaInt[i] * Math.Pow(2, binario.Length - i - 1));
                }
                retorno = numero.ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }

            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que valida que la cadena pasada por parametro sea correcta
        /// </summary>
        /// <param name="numero">Numero decimal de tipo string</param>
        /// <returns>Retorna un numero decimal de tipo string si el valor es correcto. Si es incorrecto retorna "Valor invalido"</returns>
        public static string DecimalBinario(string numero)
        {
            string retorno;
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
            {
                retorno = DecimalBinario(numeroDouble);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del metodo DecimalBinario que convierte un numero decimal de tipo double a un numero binario
        /// </summary>
        /// <param name="entero">Numero de tipo double que sera convertido</param>
        /// <returns>Retorna el numero convertido a binario en tipo string</returns>
        public static string DecimalBinario(double entero)
        {
            int numero = (int)entero;
            string binario = "";
            while (numero > 0)
            {
                binario += (numero % 2).ToString();
                numero = numero / 2;
            }
            char[] charArray = binario.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Metodo que valida que el numero de tipo string ingresado sea convertible a double
        /// </summary>
        /// <param name="strNumero">Numero de tipo string</param>
        /// <returns>Retorna el numero convertido a tipo double o 0 si no puede ser convertido</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            double.TryParse(strNumero, out numero);
            return numero;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador + encargada de sumar dos datos de tipo Numero
        /// </summary>
        /// <param name="n1">Primer sumandor</param>
        /// <param name="n2">Segundo sumandor</param>
        /// <returns>Retorna el resultado de la suma</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1._numero + n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador - encargada de restar dos datos de tipo Numero
        /// </summary>
        /// <param name="n1">Minuendor</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>Retorna el resto</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1._numero - n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador * encargada de multiplicar dos datos de tipo Numero
        /// </summary>
        /// <param name="n1">Primer factor</param>
        /// <param name="n2">Segundo factorr</param>
        /// <returns>Retorna el producto de la multiplicacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1._numero * n2._numero;
        }

        /// <summary>
        /// Sobrecarga del operador / encargada de dividir dos datos de tipo Numero
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>Retorna el cociente de la division</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1._numero / n2._numero;
        }
        #endregion

    }
}
