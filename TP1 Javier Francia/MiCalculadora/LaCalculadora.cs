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
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult deseaContinuar = MessageBox.Show("¿Desea continuar?", "Salir del programa", MessageBoxButtons.YesNo);
            if (deseaContinuar == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text == string.Empty)
            {
                MessageBox.Show("No existe un resultado para convertir.", "Error");
            }
            else if (Numero.DecimalBinario(lblResultado.Text) == "Valor inválido")
            {
                MessageBox.Show("No se puede convertir a binario.", "Error");
            }
            else if(lblResultado.Text[0] == '-')
            {
                MessageBox.Show("Este programa no puede convertir un decimal negativo en binario.", "Error");
            }
            else
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (Numero.BinarioDecimal(lblResultado.Text) == "Valor inválido")
            {
                MessageBox.Show("No se puede convertir a decimal.", "Error");
            }
            else if (lblResultado.Text == string.Empty)
            {
                MessageBox.Show("No existe un resultado para convertir.", "Error");
            }
            else
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

        private void Limpiar ()
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            lblResultado.Text = string.Empty;
            cmbOperador.Text = string.Empty;
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double output;
            if (operador == "/" && numero2 == "0")
            {
                output = 0;
                MessageBox.Show("No se puede dividir por cero.", "Error");
            }
            else
            {
                Numero num1 = new Numero(numero1);
                Numero num2 = new Numero(numero2);
                output = Calculadora.Operar(num1, num2, operador);
            }
            return output;
        }
    }
}
