/*
Fazer um programa em design [Herança junto com Interface] e ler primeiramente a quantidade de figuras ao todo, 
depois os dados de cada N figuras (N fornecido pelo usuário);
                                                                Retângulo ou Círculo?
                                                if == Retângulo:
                                                                Cor[preto,azul,vermelho]:,
                                                                Largura:,
                                                                Altura:,
                                                if == Círculo:
                                                                Cor[preto,azul,vermelho]:,
                                                                Raio:
e depois mostrar as áreas destas figuras na mesma ordem em que foram digitadas.
 */

using System;
using System.Collections.Generic;
using treino.Entities;
using treino.Entities.Enuns;

namespace TREINO
{
    class Program
    {

        static void Main()
            => ExibirInformacoes();

        private static List<Figura> RetornarListaFiguras()
        {
            var listaFiguras = new List<Figura>();
            ECorFigura corFigura;
            ETipoFigura tipoFigura;
            int quantidadeFiguras;
            double largura, altura, raio;

            while (true)
            {
                Console.Write("Entre com a quantidade de figuras: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out quantidadeFiguras) || quantidadeFiguras <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número inteiro maior que zero.");
                    continue;
                }
                break;
            }

            for (int f = 0; f < quantidadeFiguras; f++)
            {
                Console.Clear();
                Console.WriteLine($"{f + 1}ª Figura\n");

                while (true)
                {
                    Console.Write("Entre com o tipo da figura; [Retangulo | Circulo] - ");
                    string entrada = Console.ReadLine().Trim();
                    if (!Enum.TryParse<ETipoFigura>(entrada, true, out tipoFigura))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 'Retangulo' ou 'Circulo'.");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write($"Entre com a cor do {tipoFigura}; [Preto | Azul | Vermelho] - ");
                    string entrada = Console.ReadLine().Trim();
                    if (!Enum.TryParse<ECorFigura>(entrada, true, out corFigura))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 'Preto', 'Azul' ou 'Vermelho'.");
                        continue;
                    }
                    break;
                }

                if (tipoFigura == ETipoFigura.Retangulo)
                {
                    while (true)
                    {
                        Console.Write($"Entre com a largura do {tipoFigura}: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!double.TryParse(entrada, out largura) || largura <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write($"Entre com a altura do {tipoFigura}: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!double.TryParse(entrada, out altura) || altura <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                            continue;
                        }
                        break;
                    }
                    listaFiguras.Add(new Retangulo(corFigura, largura, altura));
                }

                if (tipoFigura == ETipoFigura.Circulo)
                {
                    while (true)
                    {
                        Console.Write($"Entre com o raio do {tipoFigura}: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!double.TryParse(entrada, out raio) || raio <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número inteiro ou real maior que zero.");
                            continue;
                        }
                        break;
                    }
                    listaFiguras.Add(new Circulo(corFigura, raio));
                }
            }
            return listaFiguras;
        }
        private static void ExibirInformacoes()
        {
            var listaFiguras = RetornarListaFiguras();

            Console.Clear();
            Console.WriteLine("Todas as figuras");
            foreach(var f in listaFiguras)
                Console.WriteLine(f.ToString());
        }

    }
}

