

/*
Fazer um programa para ler um número inteiro N e os dados (nome e
preço) de N Produtos. Armazene os N produtos em um vetor. Em
seguida, mostrar o preço médio dos produtos.
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
        public static Produtos[] Leitura()
        {

            int N=0;
            string nome;
            double preco;
            while (true)
            {
                Console.Write("Digite o número de produtos: ");
                string numero = Console.ReadLine().Trim();
                if(!int.TryParse(numero, out N) || N <=0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }
            var arrayProdutos = new Produtos[N];
            

            for(int i = 0;i< arrayProdutos.Length;i++)
            {
                Console.Clear();
                Console.Write($"\t\t  {i+1}ª\n\n");
                while (true)
                {
                    Console.Write("Digite o nome do produto: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                while (true)
                {
                    Console.Write("Digite o preço do produto: ");
                    string entradaPreco = Console.ReadLine().Trim();
                    if (!double.TryParse(entradaPreco, out preco) || preco <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                        continue;
                    }
                    break;
                }
                Produtos produtos = new Produtos(nome,preco);
                arrayProdutos[i] = produtos;
            }

            return arrayProdutos;
        }
        public static void Exibir()
        {
            var produtos = Leitura();

            Console.Clear();

            foreach (var p in produtos)
            {
                Console.WriteLine(p.ToString());
            }
            double media = produtos.Average(p => p.Preco);
            Console.WriteLine($"Média dos produtos: {media:F2}\n");
        }
    }
}

