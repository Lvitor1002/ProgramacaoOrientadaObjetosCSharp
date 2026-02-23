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
using TREINO.Entities;
using System.IO;
using TREINO.Enums;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        public static List<Figura> Leitura()
        {
            var listaFiguras = new List<Figura>();
            
            Cor cor;
            Modelo modelo;
            double raio, largura, altura;
            int qtd = 0;

            while (true)
            {
                Console.Write(">Digite a quantidade total de figuras: ");
                string qtdF = Console.ReadLine().Trim();
                if (!int.TryParse(qtdF, out qtd) || qtd <=0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Entre com um número 'inteiro' e maior que zero!");
                    continue;
                }
                break;
            }

            for (int i = 0; i < qtd; i++)
            {
                Console.Clear();
                Console.Write($"\t\t    {i+1}ª\n\n");

                while (true)
                {
                    Console.Write(">Digite o modelo da figura: [Retângulo / Círculo] - ");
                    string mol = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Modelo>(mol, true, out modelo))
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite apenas: [Retangulo ou Circulo]!");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write($">Digite a cor do {modelo}: [Preto / Azul / Vermelho] - ");
                    string c = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Cor>(c, true, out cor))
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite apenas: [preto ou azul ou vermelho]!");
                        continue;
                    }
                    break;
                }

                Console.Clear();

                if(modelo == Modelo.Circulo)
                {
                    while (true)
                    {
                        Console.Write($">Digite o raio do {modelo}: ");
                        string r = Console.ReadLine().Trim();
                        if (!double.TryParse(r, out raio) || raio <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Entre com um número 'inteiro' ou 'real' e maior que zero!");
                            continue;
                        }
                        break;
                    }
                    listaFiguras.Add(new Circulo(raio,cor,modelo));
                }
                if (modelo == Modelo.Retangulo)
                {
                    while (true)
                    {
                        Console.Write($">Digite a largura do {modelo}: ");
                        string lar = Console.ReadLine().Trim();
                        if (!double.TryParse(lar, out largura) || largura < 0)
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Entre com um número 'inteiro' ou 'real'!");
                            continue;
                        }
                        break;
                    }
                    while (true)
                    {
                        Console.Write($">Digite a altura do {modelo}: ");
                        string alt = Console.ReadLine().Trim();
                        if (!double.TryParse(alt, out altura) || altura < 0)
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Entre com um número 'inteiro' ou 'real'!");
                            continue;
                        }
                        break;
                    }
                    listaFiguras.Add(new Retangulo(largura,altura,cor,modelo));
                }
            }

            return listaFiguras;
        }
        public static void Exibir()
        {
            var listaFiguras = Leitura();

            Console.Clear();    
            foreach(var f in listaFiguras)
            {
                Console.WriteLine(f.ToString());
            }
        }
    }
}

