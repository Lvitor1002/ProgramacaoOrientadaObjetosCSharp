

/*
Fazer um programa para ler um conjunto de produtos a partir de um arquivo em formato .csv 
(suponha que exista pelo menos um produto).

Em seguida mostrar o preço médio dos produtos. 

Depois, mostrar;
                nomes em ordem decrescente dos produtos que possuem preço inferior ao preço médio.

*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using treino.Entities;

namespace TREINO
{
    class Program
    {
        static void Main()
            => ExibirInformacoes();

        private static List<Produto> RetornarListaFuncionarios()
        {
            var listaProdutos = new List<Produto>();
            string nome, arquivo; 
            decimal preco;

            while (true)
            {
                Console.Write("Entre com o caminho do arquivo: ");
                arquivo = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(arquivo)) 
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                    continue;
                }
                break;
            }

            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream) 
                    {
                        string[] dados = sr.ReadLine().Split(',');
                        nome = dados[0];

                        if (!decimal.TryParse(dados[1], NumberStyles.Any, CultureInfo.InvariantCulture, out preco))
                            preco = 0;

                        listaProdutos.Add(new Produto(nome, preco));
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return listaProdutos;
        }

        private static void ExibirInformacoes()
        {
            var listaProdutos = RetornarListaFuncionarios();

            //Nomes em ordem decrescente dos produtos que possuem preço inferior ao preço médio.
            decimal precoMedio = listaProdutos.Average(p=> p.Preco);
            var nomesDecrescentePrecoMenorPrecoMedio = listaProdutos.Where(p=>p.Preco < precoMedio)
                .OrderByDescending(p=>p.Nome) 
                .Select(p=> new { p.Nome, p.Preco})
                .ToList();

            Console.Clear();
            Console.WriteLine($"Nomes em ordem decrescente dos produtos que possuem preço inferior a {precoMedio:C2}:\n");
            foreach (var produto in listaProdutos)
                Console.WriteLine($"Nome: {produto.Nome}\nPreço: {produto.Preco:C2}\n----------------------------------\n");
        }
    }
}

