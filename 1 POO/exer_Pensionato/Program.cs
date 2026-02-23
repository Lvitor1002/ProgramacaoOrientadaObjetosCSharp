

/*
A dona de um pensionato possui dez quartos para alugar para estudantes,
sendo esses quartos identificados pelos números 0 a 9.

Quando um estudante deseja alugar um quarto, deve-se registrar; 
                                                                o nome
                                                                e email 
deste estudante.

Fazer um programa que inicie com todos os dez quartos vazios. 
E pergunte quantos quartos serão alugados.

Para cada registro de aluguel, informar; 
                                        o nome 
                                        e email 
do estudante, bem como qual dos quartos ele escolheu (de 0 a 9). 

Suponha que seja escolhido um quarto vago. 
Ao final, seu programa deve imprimir um relatório de todas ocupações do pensionato, por ordem de quarto.
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
            Leitura();
        }
        public static void Leitura()
        {
            string nome, email;
            int quantidadeQuartos = 0, numeroQuarto;
            Pensionato[] pensionato = new Pensionato[10];

            while (true)
            {
                Console.Write("Quantos quartos serão alugados? (0 à 10) ");
                string qtdQ = Console.ReadLine().Trim();
                if (!int.TryParse(qtdQ, out quantidadeQuartos) || quantidadeQuartos < 0 || quantidadeQuartos > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número entre 0 e 10.");
                    continue;
                }
                break;
            }
            for (int i = 0; i < quantidadeQuartos; i++)
            {
                Console.Clear();
                Console.Write($"\t\t{i+1}ª Quarto\n\n");
                while (true)
                {
                    Console.Write("Nome do estudante: ");
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
                    Console.Write("Email do estudante: ");
                    email = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um email válido. Ex: usuario@gmail.com!");
                        continue;
                    }
                    break;
                }

                bool quartoDisponivel;
                while (true)
                {
                    Console.Write("Número do quarto (0-9): ");
                    string qtdQ = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdQ, out numeroQuarto) || numeroQuarto < 0 || numeroQuarto > 9)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número entre 0 e 9.");
                        continue;
                    }
                    quartoDisponivel = pensionato[numeroQuarto] == null;
                    
                    if (!quartoDisponivel)
                    {
                        Console.Clear();
                        Console.WriteLine("Quarto já ocupado! Escolha outro.");
                        continue;
                    }
                    pensionato[numeroQuarto] = new Pensionato(nome,email,numeroQuarto);
                    break;
                }
            }

            Console.WriteLine("\nQuartos ocupados:");
            for (int i = 0; i < 10; i++)
            {
                if (pensionato[i] != null)
                {
                    Console.WriteLine(pensionato[i]);
                }
            }
        }
    }
}

