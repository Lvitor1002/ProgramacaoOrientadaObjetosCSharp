

using System;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main()
        {
            double raio;

            while (true)
            {
                Console.Write("Para saber o volume de um recipente é necessário entrar com o raio do mesmo: ");
                string r = Console.ReadLine().Trim();
                if(!double.TryParse(r, out raio))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Para saber a circunferencia de um circulo é necessário entrar com o raio do mesmo: ");
                string r = Console.ReadLine().Trim();
                if (!double.TryParse(r, out raio))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo!");
                    continue;
                }
                break;
            }

            Console.Clear();
            Calculo calculo = new Calculo();
            
            Console.Write($"Volume de um recipente: {calculo.Volume(raio):F2}^3\n");
            Console.Write($"Circunferencia de um círculo: {calculo.Circunferencia(raio):F2}\n\n");
        }
    }
}

