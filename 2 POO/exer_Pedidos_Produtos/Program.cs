
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using treino.Entities;
using treino.Entities.Enuns;

namespace TREINO
{
    class Program
    {
        private static Cliente _cliente;
        private static Pedido _pedido;
        static void Main()
            => ExibirInformacoes();

        
        private static void PopularPedido()
        {
            Status status;

            while (true)
            {
                Console.Write("Entre com o status do pedido: [Preparando / Concluido / Enviado] - ");
                string entrada = Console.ReadLine().Trim();
                if(!Enum.TryParse<Status>(entrada, true, out status))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite apenas 'Preparando', 'Concluido' ou 'Enviado'!");
                    continue;
                }
                break;
            }
            _pedido = new Pedido(status, _cliente);
        }
        private static void PopularCliente()
        {
            string nome, email;
            DateTime dataNascimento;

            while (true)
            {
                Console.Write("Entre com o nome do cliente: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
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
                Console.Write($"Entre com o email do cliente. Ex de email válido[nome@gmail.com] - ");
                email = Console.ReadLine().Trim().ToLower();
                string padraoEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

                if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email,padraoEmail))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um nome válido!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Entre com a data de nascimento do cliente. Ex: 'dd/mm/yyyy' - ");
                string entrada = Console.ReadLine().Trim();
                if (!DateTime.TryParse(entrada, out dataNascimento))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite uma data válida: 'dd/mm/yyyy'!");
                    continue;
                }
                break;
            }
            _cliente = new Cliente(nome,email,dataNascimento);
        }
        private static void PopularItem()
        {
            string nome;
            int unidades, qtdItens = 0; 
            decimal preco;
            while (true)
            {
                Console.Write("Digite a quantidade de itens ao todo: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out qtdItens) || qtdItens <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo.");
                    continue;
                }
                break;
            }

            for (int i = 0; i < qtdItens; i++) 
            {
                Console.Clear();
                Console.Write($"\t      {i + 1}ª\n\n");
                while (true)
                {
                    Console.Write(">Digite o nome do item: ");
                    nome = Console.ReadLine().ToLower().Trim();
                    if (string.IsNullOrEmpty(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um nome válido!");
                        continue;
                    }
                    nome= CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }

                while (true)
                {
                    Console.Write($">Digite a quantidade de unidades para este Item - {nome}: ");
                    string qtdItem = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdItem, out unidades) || unidades < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' positivo!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($">Digite o preço do Item {nome}: R$ ");
                    string pItem = Console.ReadLine().Trim();
                    if (!decimal.TryParse(pItem, NumberStyles.Any, CultureInfo.InvariantCulture,out preco) || preco <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' positivo!");
                        continue;
                    }
                    break;
                }
                _pedido.AdicionarItemAoPedido(new Item(nome, unidades, preco));
            }
        }
        private static void ExibirInformacoes()
        {
            PopularCliente();
            PopularPedido();
            PopularItem();

            Console.Clear();
            Console.WriteLine(_pedido);
        }
    }
}

