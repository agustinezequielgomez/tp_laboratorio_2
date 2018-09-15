using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase que se encarga de realizar operaciones entre datos de tipo Numero
    /// </summary>
    public class Calculadora
    {
        #region Metodos
        /// <summary>
        /// Metodo que opera dos valores de tipo Numero segun la operacion aricmetica basica seleccionada
        /// </summary>
        /// <param name="num1">Primer dato de tipo Numero que sera operado</param>
        /// <param name="num2">Segundp dato de tipo Numero que sera operado</param>
        /// <param name="operador">Operacion aricmetica a realizar (+,-,*,/)</param>
        /// <returns>Retorna un valor de tipo Double con el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    retorno = num1 / num2;
                    break;
                default:
                    break;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo que valida que el operador ingresado sea correcto
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador ingresado si la validacion es correcta. Caso contrario retorna el operador +</returns>
        private static string ValidarOperador(string operador)
        {
            string retorno;
            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                retorno = operador;
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }
        #endregion
    }
}
