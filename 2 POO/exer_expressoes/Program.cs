
/*
exer_expressoes

                    //Produtos de categoria [simples] com preço menor que R$900
                    //Nome dos produtos da categoria Escolar 
                    //Produtos de Categoria 2 ordenados por preço 
                    //Maior preço da lista
                    //Soma dos produtos de id 1
*/

using System;
using System.Linq;
using System.Collections.Generic;
using TREINO.Entities;
using TREINO.Entities.Enums;


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
            Categoria c1 = new Categoria() { Id = 1, Nome = "Escolar", Nivel = Nivel.Simples};
            Categoria c2 = new Categoria() { Id = 2, Nome = "Computadores", Nivel = Nivel.Medio};
            Categoria c3 = new Categoria() { Id = 3, Nome = "Eletrônicos", Nivel = Nivel.Robusto };

            var listaProdutos = new List<Produto>() {new Produto() { Id = 1, Nome = "Computador", Preco = 4500.00, Categoria = c2 },
                                                    new Produto() { Id = 2, Nome = "Mouse", Preco = 50.00, Categoria = c3 },
                                                    new Produto() { Id = 3, Nome = "Teclado", Preco = 120.00, Categoria = c3 },
                                                    new Produto() { Id = 4, Nome = "Caderno Espiral", Preco = 15.00, Categoria = c1 },
                                                    new Produto() { Id = 5, Nome = "Notebook", Preco = 3800.00, Categoria = c2 },
                                                    new Produto() { Id = 6, Nome = "Impressora", Preco = 750.00, Categoria = c2 },
                                                    new Produto() { Id = 7, Nome = "Fone de Ouvido", Preco = 200.00, Categoria = c3 },
                                                    new Produto() { Id = 8, Nome = "Lápis", Preco = 2.50, Categoria = c1 },
                                                    new Produto() { Id = 9, Nome = "Tablet", Preco = 2500.00, Categoria = c2 },
                                                    new Produto() { Id = 10, Nome = "Smartphone", Preco = 3000.00, Categoria = c3 },
                                                    new Produto() { Id = 11, Nome = "Agenda", Preco = 25.00, Categoria = c1 },
                                                    new Produto() { Id = 12, Nome = "Câmera Digital", Preco = 1200.00, Categoria = c3 },
                                                    new Produto() { Id = 13, Nome = "Monitor", Preco = 950.00, Categoria = c2 },
                                                    new Produto() { Id = 14, Nome = "Pen Drive", Preco = 40.00, Categoria = c3 },
                                                    new Produto() { Id = 15, Nome = "Borracha", Preco = 1.50, Categoria = c1 }
            };
            return listaProdutos;
        }
        static void Exibir()
        {

            var produtos = Leitura();

            Console.Clear();

            //Produtos de categoria [simples] com preço menor que R$900
            var produtosSimples900 = produtos.Where(p=>p.Preco < 900 && p.Categoria.Nivel == Nivel.Simples).Select(p=> new { p.Preco, p.Categoria.Nivel } ).ToList();
            Console.WriteLine(">Produtos de categoria [simples] com preço menor que R$900:\n");
            foreach(var p in produtosSimples900)
            {
                Console.WriteLine(p);
            }


            //Nome dos produtos da categoria Escolar
            var nomeCategoriaEscolar = produtos.Where(c => c.Categoria.Nome == "Escolar").Select(c => new { c.Nome, c.Categoria.Nivel });
            Console.WriteLine("\n>Nome dos produtos da categoria Escolar:\n");
            foreach(var n in nomeCategoriaEscolar)
            {
                Console.WriteLine(n);
            }


            //Produtos de Categoria 2 ordenados por preço 
            var produtosC2 = produtos.Where(c=>c.Categoria.Nivel == Nivel.Medio).OrderBy(c => c.Preco).Select(c =>new {c.Categoria.Nivel,c.Preco}).ToList();
            Console.WriteLine("\n>Produtos de Categoria 2 ordenados por preço:\n");
            foreach(var n in produtosC2)
            {
                Console.WriteLine(n);
            }


            //Maior preço da lista
            var maiorPreco = produtos.Max(p=>p.Preco);
            Console.Write($"\n>Maior preço da lista: R${maiorPreco:F2}\n");


            //Soma dos produtos de id 1
            var somaId1 = produtos.Where(p => p.Id == 1).Sum(p => p.Preco);
            Console.Write($"\n>Soma dos produtos de id 1: R${somaId1:F2}\n\n");
        }
    }
}
