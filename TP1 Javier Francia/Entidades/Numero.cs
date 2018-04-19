using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        //
        //          ATRIBUTOS
        //

        private double numero;


        //
        //          PROPIEDADES
        //


        string SetNumero
        {
            set
            {
                if (ValidarNumero(value) != 0) numero = ValidarNumero(value);
            }
        }


        //
        //          CONSTRUCTORES
        //


        public Numero()
        {

        }

        public Numero(double numero)
        {
            SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        //
        //          SOBRECARGA DE OPERADORES
        //

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double output = double.MinValue;
            if (n2.numero != 0) output = n1.numero / n2.numero;
            return output;
        }


        //
        //          METODOS
        //


        private static double ValidarNumero(string strNumero)
        {
            double output;
            if (!(double.TryParse(strNumero, out output))) output = 0;
            return output;
        }

        public static string DecimalBinario(double input)
        {
            ulong cociente = (ulong)input;
            ulong binaryNumber = 0;
            ulong position = 1;

            while (cociente > 0)
            {
                if (cociente % 2 == 1) binaryNumber += position;

                cociente /= 2;
                position *= 10;
            }
            return binaryNumber.ToString();
        }

        public static string DecimalBinario(string input)
        {
            string output;
            double numero;

            if (double.TryParse(input, out numero)) output = DecimalBinario(numero);
            else output = "Valor inválido";

            return output;
        }

        public static string BinarioDecimal(string binario)
        {
            string output;
            bool esBinario = true;
            foreach (char c in binario)
            {
                if (c != '1' && c != '0')
                {
                    esBinario = false;
                    break;
                }
            }

            if (esBinario)
            {
                int potencia = 1;
                int numero = 0;
                var chars = binario.ToCharArray();
                for (int i = chars.Length - 1; i >= 0; i--)
                {
                    if (chars[i] == '1') numero += potencia;
                    potencia *= 2;
                }
                output = numero.ToString();
            }
            else  output = "Valor inválido";

            return output;
        }
    }
}
