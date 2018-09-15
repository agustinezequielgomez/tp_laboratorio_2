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
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            if (!((txtNumero1.Text).All(char.IsDigit)))
            {
                txtNumero1.Text = "0";
            }
            if(!((txtNumero2.Text).All(char.IsDigit)))
            {
                txtNumero2.Text = "0";
            }
            if(cmbOperador.Text != "+" && cmbOperador.Text != "-" && cmbOperador.Text != "*" && cmbOperador.Text != "/")
            {
                cmbOperador.Text = "+";
            }
            lblResultado.Text = resultado.ToString();
        }
        
        private static double Operar(string Numero1, string Numero2, string operador)
        {
            Numero numeroUno = new Numero(Numero1);
            Numero numeroDos = new Numero(Numero2);
            return Calculadora.Operar(numeroUno, numeroDos, operador);
        }

        private void Limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is ComboBox || item is Label)
                {
                    item.Text = "";
                }
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(txtNumero1.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(txtNumero1.Text);
        }
    }
}
