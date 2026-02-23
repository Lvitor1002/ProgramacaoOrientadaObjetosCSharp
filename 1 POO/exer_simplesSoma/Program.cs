

/*
    Classe Calculo contendo uma função de soma que recebe uma quantia variável de valores como prâmetro
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
            Exibir();   
        }
        public static Calculo Leitura()
        {
            var valores = new int[2];
            int valor;

            Console.WriteLine("\t   Digite 2 valores para soma\n\n");
            for(int i = 0; i< valores.Length; i++)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"\t\t   {i + 1} Valor:\n> ");
                    string v = Console.ReadLine().Trim();
                    if (!int.TryParse(v, out valor)|| valor < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                        continue;
                    }
                    break;
                }
                valores[i] = valor;
            }
            Calculo calculo = new Calculo(valores);

            return calculo;
        }
        public static void Exibir()
        {
            var classe = Leitura();
            
            Console.Clear();

            Console.WriteLine(classe);
        }
    }
}

