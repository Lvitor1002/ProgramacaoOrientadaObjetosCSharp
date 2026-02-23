/*
Fazer um programa para ler os dados de N contribuintes (N fornecido pelo usuário), 
os quais podem ser pessoa física ou pessoa jurídica,

Os dados de pessoa física são: nome, 
                               renda mensal,
                               gastos com saúde. 
Os dados de pessoa jurídica são: 
                               nome, 
                               renda mensal, 
                               número de funcionários. 

As regras para cálculo de imposto são as seguintes:

Pessoa física: 
             pessoas cuja renda foi abaixo de 20000.00 pagam 15% de imposto. 
             Pessoas com renda de 20000.00 em diante pagam 25% de imposto. 
             Se a pessoa teve gastos com saúde, 50% destes gastos são abatidos no imposto.
Exemplo: uma pessoa cuja renda foi 50000.00 e teve 2000.00 em gastos com saúde, o imposto fica: (50000 * 25%) - (2000 * 50%) = 11500.00

Pessoa jurídica: 
                pessoas jurídicas pagam 16% de imposto. 
                Porém, se a empresa possuir mais de 10 funcionários, ela paga 14% de imposto.
Exemplo: uma empresa cuja renda foi 400000.00 e possui 25 funcionários, o imposto fica: 400000 * 14% = 56000.00

Por fim, exibir; 
                valor do imposto pago por cada um, 
                total de imposto arrecadado.
 */



using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using TREINO.Entities;
using TREINO.Enums;



namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        public static List<Colaborador> Leitura()
        {
            var listaPessoas = new List<Colaborador>();
            string nome;
            double rendaMensal;
            Tipo tipo;
            int quantidadePessoas = 0;

            while (true)
            {
                Console.Write(">Ao todo, quantas pessoas serão cadastradas? ");
                string qtd = Console.ReadLine().Trim();
                if (!int.TryParse(qtd, out quantidadePessoas) || quantidadePessoas < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um valor 'inteiro' positivo.");
                    continue;
                }
                break;
            }

            Console.Clear();
            for(int i = 0; i < quantidadePessoas; i++){

                Console.Clear();
                Console.Write($"\t\t{i+1}ª Pessoa:\n\n");

                while (true)
                {
                    Console.Write(">Digite o nome do funcionario: ");
                    nome = Console.ReadLine().ToLower().Trim();
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
                    Console.Write($">{nome} é pessoa; [Fisica / Juridica]? ");
                    string tPessoa = Console.ReadLine().Trim();
                    if (!Enum.TryParse<Tipo>(tPessoa, true, out tipo))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas: [fisica ou juridica]");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write($">{nome}, qual sua renda mensal? R$");
                    string rMensal = Console.ReadLine().Trim();
                    if (!double.TryParse(rMensal, out rendaMensal) || rendaMensal <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um valor 'inteiro' ou 'real' positivo.");
                        continue;
                    }
                    break;
                }

                if (tipo == Tipo.Fisica)
                {
                    double gastoSaude;
                    while (true)
                    {
                        Console.Write($">{nome}, qual o valor gasto com saúde?\n>Caso contrário digite zero\n");
                        string gSaude = Console.ReadLine().Trim();
                        if (!double.TryParse(gSaude, out gastoSaude) || gastoSaude < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um valor 'inteiro' ou 'real' positivo.");
                            continue;
                        }
                        break;
                    }
                    listaPessoas.Add(new PessoaFisica(gastoSaude, nome, rendaMensal, tipo));
                }

                if (tipo == Tipo.Juridica)
                {
                    int numeroFuncionarios;
                    while (true)
                    {
                        Console.Write($">{nome}, qual a quantidade total de funcionários atualmente em sua empresa? ");
                        string nFuncio = Console.ReadLine().Trim();
                        if (!int.TryParse(nFuncio, out numeroFuncionarios) || numeroFuncionarios < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um valor 'inteiro' positivo.");
                            continue;
                        }
                        break;
                    }
                    listaPessoas.Add(new PessoaJuridica(numeroFuncionarios, nome, rendaMensal, tipo));
                }

            }
            return listaPessoas;
        }
        public static void Exibir()
        {
            var listaPessoas = Leitura();
            var totalImposto = listaPessoas.Sum(p => p.Imposto());

            Console.Clear();
            Console.WriteLine("\n--------------------------------------\n" +
                "\t     Dados de todos os colaboradores");
            foreach (var p in listaPessoas)
            {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine($">Total de imposto dos colaboradores: {totalImposto:F2}\n\n" +
                $"--------------------------------------------------\n");
        }
    }
}

