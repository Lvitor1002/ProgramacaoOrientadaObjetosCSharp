
/*
Uma empresa possui funcionários próprios e terceirizados. 
Para cada funcionário, devem ser registrados: 
                                            nome, 
                                            horas trabalhadas no mês 
                                            e valor por hora. 
Considere que o mês tem 30 dias, mas as horas informadas já representam o total trabalhado no período.

Os funcionários terceirizados possuem, adicionalmente, uma despesa extra. 
O pagamento mensal deles é composto por duas partes:
                                        O pagamento base, calculado como horas trabalhadas × valor por hora;
                                        Um bônus de 110% sobre a despesa adicional, ou seja, acrescenta-se despesa adicional × 1,1 ao valor base.

Assim, o pagamento total do terceirizado é:
(horas trabalhadas × valor por hora) + (despesa adicional × 1,1).

Faça um programa que leia a quantidade N de funcionários (fornecida pelo usuário) e, 
em seguida, os dados de cada um, armazenando-os em uma lista. 

Para funcionários próprios, os dados são: 
                                        nome, 
                                        horas trabalhadas e 
                                        valor por hora.

Para terceirizados, além desses, deve-se ler a:
                                                despesa adicional.

Após a leitura de todos os dados, exiba, na mesma ordem de digitação, 
o nome e o pagamento mensal de cada funcionário, formatados com duas casas decimais.
 
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

        private static List<Funcionario> PopularFuncionario()
        {
            string nome;
            int horasTrabalhadas, quantidadeFuncionario;
            decimal valorPorHora, despesaAdicional;
            TipoFuncionario tipoFuncionario;
            var listaFuncionarios = new List<Funcionario>();

            while (true)
            {
                Console.Write("Quantos funcionários serão cadastrados? ");
                string entrada = Console.ReadLine().Trim();

                if(!int.TryParse(entrada, out quantidadeFuncionario) || quantidadeFuncionario <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número inteiro positivo maior que zero!");
                    continue;
                }
                break;
            }
            for(int i = 0; i < quantidadeFuncionario; i++)
            {
                Console.Clear();
                Console.WriteLine($"{i+1}ª Funcionário");

                while (true)
                {
                    Console.Write("É funcionario; [Terceiro / Padrao]? ");
                    string entrada = Console.ReadLine().Trim();

                    if (!Enum.TryParse<TipoFuncionario>(entrada, true, out tipoFuncionario))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um nome válido, sendo; \"Terceiro\" ou \"Padrao\"!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($"Nome do funcionário {tipoFuncionario}? ");
                    nome = Console.ReadLine().Trim().ToLower();

                    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um nome válido!");
                        continue;
                    }
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com as horas trabalhadas do funcionário {tipoFuncionario}? ");
                    string entrada = Console.ReadLine().Trim();

                    if (!int.TryParse(entrada, out horasTrabalhadas) || horasTrabalhadas <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro positivo maior que zero!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write($"Entre com o valor recebido por hora para o funcionário {tipoFuncionario}? ");
                    string entrada = Console.ReadLine().Trim();

                    if (!decimal.TryParse(entrada, out valorPorHora) || valorPorHora<= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo maior que zero!");
                        continue;
                    }
                    break;
                }

                if(tipoFuncionario == TipoFuncionario.Padrao)
                    listaFuncionarios.Add(new Funcionario(nome,horasTrabalhadas,valorPorHora,tipoFuncionario));
                
                if (tipoFuncionario == TipoFuncionario.Terceiro)
                {
                    while (true)
                    {
                        Console.Write($"Entre com o valor da despesa do funcionário {tipoFuncionario}? ");
                        string entrada = Console.ReadLine().Trim();

                        if (!decimal.TryParse(entrada, out despesaAdicional) || despesaAdicional < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' positivo maior que zero!");
                            continue;
                        }
                        break;
                    }
                    listaFuncionarios.Add(new FuncionarioTerceiro(despesaAdicional, nome, horasTrabalhadas, valorPorHora, tipoFuncionario));
                }
            }
            return listaFuncionarios;
        }

        private static void ExibirInformacoes()
        {
            var listaFuncionarios = PopularFuncionario();

            Console.Clear();
            foreach(var funcionarios in listaFuncionarios)
                Console.WriteLine(funcionarios.ToString());
        }
    }    
}

