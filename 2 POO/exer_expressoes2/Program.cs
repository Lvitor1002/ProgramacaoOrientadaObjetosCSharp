
/*
Fazer um programa para ler um conjunto de produtos a partir de um arquivo em formato .csv (suponha que exista pelo menos um produto).

Em seguida mostrar o preço médio dos produtos. 

Depois, mostrar;
               nomes, em ordem decrescente, dos produtos que possuem preço inferior ao preço médio.

//C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_tratamento_excecoes2\txt.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using exer_expressoes2.Entities;


namespace exer_expressoes2
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static List<Produto> Leitura()
        {
            string nomeProduto;
            double precoProduto;
            

            Console.Write(">Entre com o arquivo: ");
            string arquivo = Console.ReadLine();//C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_tratamento_excecoes2\txt.txt

            

            var listaArquivo = new List<Produto>();

            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream){

                        string[] arquivoDividido = sr.ReadLine().Split(',');
                        
                        nomeProduto = arquivoDividido[0];
                        precoProduto = double.Parse(arquivoDividido[1], CultureInfo.InvariantCulture);

                        Produto produto = new Produto(nomeProduto, precoProduto);
                        listaArquivo.Add(produto);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            return listaArquivo;
            
        }

        static void Exibir()
        {
            var lista = Leitura();
            Console.Clear();

            //Média dos produtos
            var mediaPreco = lista.Select(p => p.Preco).DefaultIfEmpty(0).Average(); //[DefaultIfEmpty] = Se alista for vazia, coloque o zero
            Console.WriteLine($">Media dos valores: {mediaPreco:F2}\n");


            //Nomes, em ordem decrescente, dos produtos que possuem preço inferior ao preço médio.
            var nomes = lista.Where(p => p.Preco < mediaPreco).OrderByDescending(p => p.Nome).Select(p => p.Nome);

            Console.WriteLine(">Nomes em ordem decrescente:");
            foreach(var n in nomes)
            {
                Console.WriteLine($"\t\t\t   {n}");
            }
        }
    }
}
