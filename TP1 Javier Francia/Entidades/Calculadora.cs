using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {

        public static double Operar (Numero num1, Numero num2, string operador)
        {
            double output;
            switch(operador)
            {
                case "-":
                    output = num1 - num2;
                    break;
                case "/":
                    output = num1 / num2;
                    break;
                case "*":
                    output = num1 * num2;
                    break;
                default:
                    output = num1 + num2;
                    break; 
            }
            return output;
        }

        private static string ValidarOperador (string operador)
        {
            string output;
            switch (operador)
            {
                case "*":
                case "/": 
                case "-":
                    output = operador;
                    break;
                default:
                    output = "+";
                    break;
            }

            return output;
        }
    }
}
