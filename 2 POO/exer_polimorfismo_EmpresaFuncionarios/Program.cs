


/*
Uma empresa possui funcionários próprios e terceirizados.
Para cada funcionário, deseja-se registrar; 
                                            nome, 
                                            horas trabalhadas,
                                            valor por hora, considerando que os mesmos trabalham 30 dias.. 
                

Funcionários terceirizados possuem ainda uma despesa adicional.
O pagamento dos funcionários terceirizados corresponde ao (valor da hora trabalhadas multiplicado pelas dias trabalhados), 
sendo que os funcionários terceirizados ainda recebem um bônus correspondente a 110% de sua despesa adicional.

Faça um programa para ler os dados de N funcionários (N fornecido pelo usuário) e armazená-los em uma lista. 

Depois de ler todos os dados, 
                            mostrar nome,
                            pagamento mensal de cada funcionário,

na mesma ordem em que foram digitados.
 
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
        static List<Funcionario> Leitura()
        {
            string nome; 
            int horasTrabalhadas, qtdFuncionarios = 0; 
            Tipo tipo;
            double despesaAdicional, valorPorHora;

            var listaFuncionario = new List<Funcionario>();

            while (true)
            {
                Console.Write($">Quantos funcionarios existem ao todo na empresa? ");
                string qtd= Console.ReadLine().Trim();
                if (int.TryParse(qtd, out qtdFuncionarios) && qtdFuncionarios > 0)
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido maior que zero!");
            }
            Console.Clear();
            for (int i = 0; i < qtdFuncionarios; i++)
            {
                Console.Clear();
                Console.Write($"\t\t{i+1}ª\n\n");
                while (true)
                {
                    Console.Write(">Digite o nome do funcionário: ");
                    nome = Console.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrWhiteSpace(nome) && nome.All(c => char.IsLetter(c) || c == ' '))
                    {
                        nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                }
                while (true)
                {
                    Console.Write($">Quantas horas {nome} trabalha por dia? ");
                    string hTrabalhadas = Console.ReadLine().Trim();
                    if (int.TryParse(hTrabalhadas, out horasTrabalhadas) && horasTrabalhadas > 0 && horasTrabalhadas <= 10){
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido, sendo ele permitido de 1 à 10!");
                }
                while (true)
                {
                    Console.Write($">Qual o valor recebido para trabalhar {horasTrabalhadas} horas por dia? ");
                    string vHora = Console.ReadLine().Trim();
                    if (double.TryParse(vHora, out valorPorHora) && valorPorHora > 0)
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' válido!");
                }
                while (true)
                {
                    Console.Write($">{nome} é funcionario [Terceiro / Particular]? ");
                    string tFuncionario = Console.ReadLine().Trim();
                    if (Enum.TryParse<Tipo>(tFuncionario,true, out tipo))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite apenas: [Terceiro ou Particular]!");
                }
                Funcionario funcionario = new Funcionario(nome,horasTrabalhadas,tipo,valorPorHora);
                

                if (tipo == Tipo.Particular)
                {
                    funcionario.Pagamento();
                    listaFuncionario.Add(funcionario);
                }
                if (tipo == Tipo.Terceiro)
                {
                    while (true)
                    {
                        Console.Write($">Qual a despesa adicional do funcionário {tipo}? ");
                        string despesaA = Console.ReadLine().Trim();
                        if (double.TryParse(despesaA, out despesaAdicional) && despesaAdicional >= 0)
                        {
                            break;
                        }
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' válido!");
                    }
                    FuncionarioTerceiro funcionarioTerceiro = new FuncionarioTerceiro(despesaAdicional,nome,horasTrabalhadas,tipo,valorPorHora);
                    listaFuncionario.Add(funcionarioTerceiro);

                }
            }
            
            return listaFuncionario;
        }

        static void Exibir()
        {
            var listaFuncionario = Leitura();
            Console.Clear();

            Console.WriteLine("Dados dos Funcionario\n");
            foreach (var f in listaFuncionario)
            {
                Console.WriteLine(f.ToString());
            }
        }
    }
}

