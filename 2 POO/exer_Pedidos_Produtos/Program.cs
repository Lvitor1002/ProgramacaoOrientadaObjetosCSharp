


/*
Ler os dados de um [pedido]:
                            InstantePedido,
                            Status,
                            Quantidade de Itens. 

com [N itens] (N fornecido pelo usuário) considerando os seus atributos; nome, 
                                                                        unidades, 
                                                                        preco. 

Depois, mostrar um sumário do pedido; 
                                    instante do pedido, 
                                    Status do Pedido, 
                                    cliente(Nome, email, dt nascimento),
                                    itens do pedido,
                                    preço total.

Nota: o instante do pedido deve ser o instante do sistema: DateTime.Now
*/



using System;
using System.Linq;
using System.Globalization;
using TREINO.Entities;
using TREINO.Enums;
using System.Collections.Generic;
using System.Collections;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static Pedido Leitura()
        {
            string nome, email, nomeItem;
            DateTime dataNascimento;
            int quantidadeUnidades = 0, quantidadeItem = 0;
            double precoItem = 0;

            //Sorteio do status para ser aleatório:

            var valores = Enum.GetValues(typeof(Status));
            Random sorteio = new Random();

            // Sorteando um índice aleatório
            Status status = (Status)valores.GetValue(sorteio.Next(valores.Length));

            while(true){
                Console.Write(">Digite o nome do cliente: ");
                nome = Console.ReadLine().ToLower().Trim();
                if (string.IsNullOrEmpty(nome) || !nome.All(c=>char.IsLetter(c) || c == ' ')) {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um nome válido!");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            while (true)
            {
                Console.Write(">Digite o email do cliente: ");
                email = Console.ReadLine().ToLower().Trim();
                if (string.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.') || email.StartsWith("@") || email.EndsWith("@") || email.StartsWith(".") || email.EndsWith("."))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um email válido!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write(">Digite a data de nascimento do cliente: [dd/mm/aaaa] - ");
                string dtNascimento = Console.ReadLine().Trim();
                if (!DateTime.TryParse(dtNascimento, out dataNascimento))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma data válida: [dd/mm/aaaa]!");
                    continue;
                }
                break;
            }

            Cliente cliente = new Cliente(nome,email,dataNascimento);
            Pedido pedido = new Pedido(DateTime.Now, status, cliente);

            while (true)
            {
                Console.Write($">Digite a quantidade de Itens ao todo: ");
                string qtdItemTodo = Console.ReadLine().Trim();
                if (!int.TryParse(qtdItemTodo, out quantidadeItem) || quantidadeItem <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' positivo!");
                    continue;
                }
                break;
            }

            for(int i = 0; i < quantidadeItem; i++)
            {
                Console.Clear();
                Console.Write($"\t      {i+1}ª\n\n");
                while (true)
                {
                    Console.Write(">Digite o nome do item: ");
                    nomeItem = Console.ReadLine().ToLower().Trim();
                    if (string.IsNullOrEmpty(nomeItem) || !nomeItem.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nomeItem = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeItem.ToLower());
                    break;
                }

                while (true)
                {
                    Console.Write($">Digite a quantidade de unidades para este Item - {nomeItem}: ");
                    string qtdItem = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdItem, out quantidadeUnidades) || quantidadeUnidades < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' positivo!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($">Digite o preço do Item {nomeItem}: R$ ");
                    string pItem = Console.ReadLine().Trim();
                    if (!double.TryParse(pItem, out precoItem) || precoItem <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo!");
                        continue;
                    }
                    break;
                }

                Item item = new Item(nomeItem,quantidadeUnidades,precoItem);
                pedido.Additem(item);
            }
            return pedido;
        }
        static void Exibir()
        {
            var pedido = Leitura();
            Console.Clear();
            Console.WriteLine(pedido.ToString());
        }
    }
}

