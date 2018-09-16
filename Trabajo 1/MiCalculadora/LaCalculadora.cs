using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            string[] operadores = { "+", "-", "*", "/" };
            foreach(string operador in operadores)
            {
                this.cmbOperador.Items.Add(operador);
            }
            this.cmbOperador.Items.Add("");
            this.cmbOperador.SelectedItem = ("");
            lblResultado.Text = "";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Metodo que cierra el programa al hacer click en el boton cerrar;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que limpia el texto ingresado por el usuario en los textbox, combobox y label de resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Metodo que realiza una operacion al hacer click en el boton operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (!((txtNumero1.Text).All(char.IsDigit))||txtNumero1.Text == "")
            {
                txtNumero1.Text = "0";
            }
            if(!((txtNumero2.Text).All(char.IsDigit))||txtNumero2.Text == "")
            {
                txtNumero2.Text = "0";
            }
            if(cmbOperador.Text != "+" && cmbOperador.Text != "-" && cmbOperador.Text != "*" && cmbOperador.Text != "/")
            {
                cmbOperador.Text = "+";
            }
            lblResultado.Text = resultado.ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }
        
        /// <summary>
        /// Metodo que opera los valores ingresados
        /// </summary>
        /// <param name="Numero1">Primer numero de tipo string</param>
        /// <param name="Numero2">Segundo numero de tipo string</param>
        /// <param name="operador">Caracter que representa la operacion a realizar</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string Numero1, string Numero2, string operador)
        {
            Numero numeroUno = new Numero(Numero1);
            Numero numeroDos = new Numero(Numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }

        /// <summary>
        /// Metodo que limpia el texto ingresado por el usuario en los textbox, combobox y label de resultado
        /// </summary>
        private void Limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is ComboBox || item is Label)
                {
                    item.Text = "";
                }
            }
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Metodo que se encarga de llamar al conversor Decimal/Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            if(lblResultado.Text != "Valor invalido")
            {
                btnConvertirABinario.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo que se encarga de llamar al conversor Binario/Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            btnConvertirABinario.Enabled = true;
        }
    }
}
