
/*
Fazer um programa para ler os dados de N produtos (N fornecido pelo usuário). 
Ao final, mostrar a etiqueta de preço de cada produto na mesma ordem em que foram digitados.
Todo produto possui; 
                nome,
                preço. 

Produtos importados possuem uma taxa de alfândega que deve ser acrescentada ao preço final do produto.

produtos usados possuem data de fabricação;

Estes dados específicos devem ser acrescentados na etiqueta de preço. 
*/



using System;
using System.Linq;
using System.Globalization;

using TREINO.Entities;
using TREINO.Entities.Enums;
using System.Collections.Generic;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static List<Produto> Leitura()
        {
            var listaProdutos = new List<Produto>();
            Tipo tipo;
            DateTime dataFabricacao;
            int qtdProdutos;
            string nome;
            double taxa, preco = 0;

            while (true)
            {
                Console.Write(">Digite a quantidade de produtos a cadastrar: ");
                string qtd = Console.ReadLine().Trim();
                if(int.TryParse(qtd, out qtdProdutos) && qtdProdutos > 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' maior que zero!");
                }
            }
            for(int i = 0; i < qtdProdutos; i++)
            {
                Console.Clear();
                Console.WriteLine($"\t\t{i + 1}ª Produto\n");
                while (true)
                {
                    Console.Write(">Este produto é [Normal | Usado | Importado]? ");
                    string t = Console.ReadLine().Trim();
                    if(Enum.TryParse<Tipo>(t, true, out tipo))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um tipo correto:  [Normal | Usado | Importado]!");
                    }
                }

                Console.Clear();
                Console.WriteLine($"\t\t{i+1}ª Produto\n");
                while (true)
                {
                    Console.Write($">Nome do produto {tipo}? ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrWhiteSpace(nome) && nome.All(c=>char.IsLetter(c)|| c == ' '))
                    {
                        nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                    }
                }
                while (true)
                {
                    Console.Write($">Preço do produto {tipo}? R$");
                    string pre = Console.ReadLine().Trim();
                    if (double.TryParse(pre, NumberStyles.Any, CultureInfo.InvariantCulture, out preco) && preco > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                    }
                }

                if (tipo == Tipo.Normal)
                {
                    listaProdutos.Add(new Produto(nome, tipo, preco));
                }

                if(tipo == Tipo.Importado)
                {
                    while (true)
                    {
                        Console.Write($">Taxa para o produto {tipo}? ");
                        string tax = Console.ReadLine().Trim();
                        if (double.TryParse(tax, NumberStyles.Any, CultureInfo.InvariantCulture, out taxa) && taxa >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                        }
                    }
                    listaProdutos.Add(new ProdutoImportado(taxa, nome, tipo, preco));
                }
                if (tipo == Tipo.Usado)
                {
                    while (true)
                    {
                        Console.Write($">Data de fabricação para o produto {tipo}? dd/MM/yyyy - ");
                        string dt = Console.ReadLine().Trim();
                        if (DateTime.TryParse(dt, out dataFabricacao))
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Digite uma data válida: dd/MM/yyyy");
                        }
                    }
                    listaProdutos.Add(new ProdutoUsado(dataFabricacao,nome,tipo,preco));
                }
            }
            return listaProdutos;

        }
        static void Exibir()
        {
            var listaProdutos = Leitura();

            Console.Clear();
            Console.WriteLine("\t\tEtiqueta dos produtos\n");
            foreach(var p in listaProdutos)
            {
                Console.WriteLine(p);
            }
        }
    }
}

