
/*
Fazer um programa para ler um número inteiro N e depois os dados (id, nome e salario) de N funcionários. 

Não deve haver repetição de id.

Em seguida, efetuar o aumento de X por cento no salário de um determinado funcionário.
Para isso, o programa deve ler um id e o valor X. Se o id informado não existir, mostrar uma
mensagem e abortar a operação. 

Ao final, mostrar a listagem atualizada dos funcionários.

Lembre-se de aplicar a técnica de encapsulamento para não permitir que o salário possa ser mudado livremente. 
Um salário só pode ser aumentado com base em uma operação de aumento por porcentagem dada.
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
        public static List<Funcionario> Leitura()
        {
            var listaFuncionarios = new List<Funcionario>();
            
            // HashSet para controlar IDs únicos 
            HashSet<int> idsUtilizados = new HashSet<int>();
            
            int id, qtd = 0;
            string nome;
            double salario;



            while (true)
            {
                Console.Write("Quantos funcionários serão cadastrados ao todo? ");
                string qtdFun = Console.ReadLine().Trim();
                if (!int.TryParse(qtdFun, out qtd) || qtd <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }

            for (int i = 0; i < qtd; i++) {
                
                Console.Clear();
                Console.Write($"\t\t  {i + 1}ª\n\n");

                while (true)
                {
                    Console.Write("Nome do funcionário: ");
                    nome = Console.ReadLine().Trim().ToLower();
                                                            //função lambda que retorna true se o caractere c for: uma letra(A-Z, a - z, acentuadas etc.); ou um espaço.
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
                    Console.Write("Id do funcionário:");
                    string idFun = Console.ReadLine().Trim();
                    if (!int.TryParse(idFun, out id) || id <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                        continue;
                    }
                    if (idsUtilizados.Contains(id))
                    {
                        Console.Clear();
                        Console.WriteLine("ERRO: Este ID já está em uso. Digite um ID único.");
                        continue;
                    }
                    idsUtilizados.Add(id);
                    break;
                }

                while (true)
                {
                    Console.Write("Salário do funcionário: R$");
                    string saFun = Console.ReadLine().Trim();
                    if (!double.TryParse(saFun, out salario) || salario <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                        continue;
                    }
                    break;
                }
                Funcionario funcionario = new Funcionario(id,nome,salario);

                listaFuncionarios.Add(funcionario);
            }
            Console.Clear();
            Console.WriteLine("\n\t Status dos funcionários\n\n");
            foreach (var f in listaFuncionarios)
            {
                Console.WriteLine(f.ToString());
            }

            return listaFuncionarios;
        }
        public static void Exibir()
        {
            Console.Clear();
            var lista = Leitura();
            double porcentagem;
            int idEscolhido;

            while (true)
            {
                Console.Write("Escolha um funcionário pelo ID para o aumento de salário: ");
                string idFun = Console.ReadLine().Trim();
                if (!int.TryParse(idFun, out idEscolhido) || idEscolhido <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }
            Funcionario funcionarioAlvo = lista.First(f=>f.Id == idEscolhido);
            
            if(funcionarioAlvo == null)
            {
                Console.Clear();
                Console.WriteLine("\nERRO: Funcionário com este ID não encontrado. Operação cancelada.");
                return;
            }
                
            while (true)
            {
                Console.Write($"Em quantos '%' deseja aumentar o salário do funcionário {funcionarioAlvo.Nome}? %");
                string porFun = Console.ReadLine().Trim();
                if (!double.TryParse(porFun, out porcentagem) || porcentagem < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior ou igual à zero!");
                    continue;
                }
                break;
            }

            funcionarioAlvo.Aumento(porcentagem);

            Console.WriteLine("\n\t Novo status dos funcionários\n\n");
            foreach(var f in lista)
            {
                Console.WriteLine(f.ToString());
            }
        }
    }
}

