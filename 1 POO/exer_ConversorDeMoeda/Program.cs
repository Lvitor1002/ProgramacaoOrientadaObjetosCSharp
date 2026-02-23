
/*
Faça um programa para ler a cotação do dólar, e depois um valor em dólares a ser comprado por uma pessoa em reais. 
Informar quantos reais a pessoa vai pagar pelos dólares, considerando ainda que a pessoa terá que pagar 6% de IOF sobre o valor em dólar. 
Criar uma classe ConversorDeMoeda para ser responsável pelos cálculos.
*/

using System;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Leitura();
        }
        public static void Leitura()
        {
            double valorDolar;

            while (true)
            {
                Console.Write("(Cotação atual - 5,54)\n>Informe quantos dólares deseja comprar: $");
                string vDolar = Console.ReadLine().Trim();
                if(!double.TryParse(vDolar, out valorDolar) || valorDolar < 0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número inteiro ou real maior ou igual a zero!");
                    continue;
                }
                break;
            }
            Console.Clear();
            ConversorDeMoeda cm = new ConversorDeMoeda(valorDolar);
            Console.WriteLine(cm.ToString());
        }
    }
}

