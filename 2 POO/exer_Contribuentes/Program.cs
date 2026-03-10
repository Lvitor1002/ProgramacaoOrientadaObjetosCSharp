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
Exemplo: uma pessoa cuja renda foi 50000.00 e 
            teve 2000.00 em gastos com saúde, o imposto fica: (50000 * 25%) - (2000 * 50%) = 11500.00

Pessoa jurídica: 
                pessoas jurídicas pagam 16% de imposto. 
                Porém, se a empresa possuir mais de 10 funcionários, ela paga 14% de imposto.
Exemplo: uma empresa cuja renda foi 400000.00 e possui 25 funcionários, o imposto fica: 400000 * 14% = 56000.00

Por fim, exibir; 
                valor do imposto pago por cada um, 
                total de imposto arrecadado.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using treino.Entities;
using treino.Entities.Enuns;

namespace TREINO
{
    class Program
    {

        static void Main()
            => ExibirInformacoes();

        private static List<Contribuinte> RetornarListaContribuintes()
        {
            decimal gastoComSaude, rendaMensal;
            int quantidadeFuncionarios, quantidadeContribuinte = 0;
            TipoContribuintes tipoContribuintes;
            string nome;
            var listaContribuintes = new List<Contribuinte>();

            while (true)
            {
                Console.Write("Entre com a quantidade de contribuintes a ser cadastrados: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out quantidadeContribuinte) || quantidadeContribuinte <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' e maior que zero!");
                    continue;
                }
                break;
            }

            for (int i = 0; i < quantidadeContribuinte; i++) 
            {
                Console.Clear();
                Console.WriteLine($"{i+1}ª Contribuinte");

                while (true)
                {
                    Console.Write("Entre com tipo de contribuinte. Pessoa: [Fisica | Juridica] ");
                    string entrada = Console.ReadLine().Trim();
                    if (!Enum.TryParse<TipoContribuintes>(entrada, true, out tipoContribuintes))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite apenas 'Fisica' ou 'Juridica'!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write("Entre com o nome do contribuinte: ");
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
                    Console.Write("Entre com a renda mensal do contribuintes: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!decimal.TryParse(entrada, out rendaMensal) || rendaMensal < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real', maior ou igual à zero!");
                        continue;
                    }
                    break;
                }

                if(tipoContribuintes == TipoContribuintes.Juridica)
                {
                    while (true)
                    {
                        Console.Write($"Entre com a quantidade de funcionarios do contribuintes {tipoContribuintes}: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!int.TryParse(entrada, out quantidadeFuncionarios) || quantidadeFuncionarios < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' e maior ou igual à zero!");
                            continue;
                        }
                        break;
                    }
                    listaContribuintes.Add(new PessoaJuridica(tipoContribuintes,nome,rendaMensal,quantidadeFuncionarios));
                }
                if (tipoContribuintes == TipoContribuintes.Fisica)
                {
                    while (true)
                    {
                        Console.Write($"Se houve gasto com saúde infrome o valor, se não, digite zero: ");
                        string entrada = Console.ReadLine().Trim();
                        if (!decimal.TryParse(entrada, out gastoComSaude) || gastoComSaude < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real', maior ou igual à zero!");
                            continue;
                        }
                        break;
                    }
                    listaContribuintes.Add(new PessoaFisica(tipoContribuintes, nome, rendaMensal, gastoComSaude));
                }
            }
            return listaContribuintes;
        }

        private static void ExibirInformacoes()
        {
            var listaContribuinte = RetornarListaContribuintes();

            //total de imposto arrecadado.
            Console.Clear();
            if (!listaContribuinte.Any())
                return;

            Console.WriteLine("Contribuintes cadastrados");
            foreach (var contribuinte in listaContribuinte)
                Console.WriteLine(contribuinte);
        }

    }
}

