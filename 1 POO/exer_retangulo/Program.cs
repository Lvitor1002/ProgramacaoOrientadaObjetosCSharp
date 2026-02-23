

/*
Fazer um programa para ler os valores da largura e altura de um retângulo. Em
seguida, mostrar na tela o valor de sua área, perímetro e diagonal. Usar uma classe
como mostrado no projeto ao lado.

Diagonal = raíz de a²+b²
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            double largura, altura;

            while (true)
            {
                Console.Write(">Digite a altura do triângulo: ");
                string triAlt = Console.ReadLine().Trim();
                if(!double.TryParse(triAlt, out altura) || altura <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo maior que zero!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write(">Digite a largura do triângulo: ");
                string triLar = Console.ReadLine().Trim();
                if (!double.TryParse(triLar, out largura) || largura <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo maior que zero!");
                    continue;
                }
                break;
            }
            Retangulo retangulo = new Retangulo(largura,altura);
            Console.Clear();

            Console.WriteLine(retangulo.ToString());
        }
    }
}

