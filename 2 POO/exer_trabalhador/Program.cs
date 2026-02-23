
/*

Ler os dados de um trabalhador;
                                nome,
                              departamento
                              nivel de experiência(junior,pleno,senior),
                              salário base
em seguida entrar com N contratos (N fornecido pelo usuário), 
em cada N contrato é solicitado;
                               data do contrato(DD/MM/YYYY),
                               valor por hora
                               duração em horas. 

Calcule a renda para contrato. 

Por fim, exiba os Dados do Trabalhador:
                                       Nome,
                                       Departamento,
                                       Nivel,
                                       Renda total para a data (mes=MM/ano=YYYY)
*/



using System;
using System.Linq;
using System.Globalization;

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
        static Trabalhador Leitura()
        {
            string nomeTrabalhador, departamento;
            Nivel nivel;
            int qtdContratos = 0, duracaoHoras = 0;
            double salarioBase, valorPorHora = 0;
            DateTime dataContrato;

            

            while (true)
            {
                Console.Write(">Nome do trabalhador: ");
                nomeTrabalhador = Console.ReadLine().Trim().ToLower();
                if(!string.IsNullOrWhiteSpace(nomeTrabalhador) && nomeTrabalhador.All(c=>char.IsLetter(c) || c== ' '))
                {
                    nomeTrabalhador = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeTrabalhador.ToLower());
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
                Console.Write(">Nome do departamento: ");
                departamento = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(departamento) && departamento.All(c => char.IsLetter(c) || c == ' '))
                {
                    departamento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(departamento.ToLower());
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
                Console.Write($">Digite o nível de experiência de {nomeTrabalhador}: [Junior/Pleno/Senior] ");
                string exp = Console.ReadLine().Trim();
                if (Enum.TryParse<Nivel>(exp, true, out nivel))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite uma das opções: [Junior/Pleno/Senor]!");
                }
            }
            while (true)
            {
                Console.Write($">Qual o salário base de {nomeTrabalhador}? R$");
                string salario = Console.ReadLine().Trim();
                if (double.TryParse(salario, NumberStyles.Any, CultureInfo.InvariantCulture, out salarioBase) && salarioBase > 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                }
            }
            
            Trabalhador trabalhador = new Trabalhador(nomeTrabalhador, nivel, salarioBase, departamento);


            while (true)
            {
                Console.Write($">Quantos contratos ao todo para {nomeTrabalhador}? ");
                string qtdcon = Console.ReadLine().Trim();
                if (int.TryParse(qtdcon, out qtdContratos) && qtdContratos >= 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro'!");
                }
            }

            
            Console.Clear();
            for(int i = 0; i< qtdContratos; i++)
            {
                Console.Write($"\t\t{i+1}ª Contrato\n");

                while (true)
                {
                    Console.Write($">Digite a data para o contrato: dd/MM/yyyy ");
                    string dt = Console.ReadLine().Trim();
                    if (DateTime.TryParse(dt, out dataContrato))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite uma data válida: dd/MM/yyyy");
                    }
                }
                while (true)
                {
                    Console.Write($">Qual o valor por hora recebido por {nomeTrabalhador}? R$");
                    string vph = Console.ReadLine().Trim();
                    if (double.TryParse(vph, NumberStyles.Any, CultureInfo.InvariantCulture, out valorPorHora) && valorPorHora > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                    }
                }
                while (true)
                {
                    Console.Write($">Quantas horas são necessárias para receber R${valorPorHora}? ");
                    string vph = Console.ReadLine().Trim();
                    if (int.TryParse(vph, out duracaoHoras) && duracaoHoras >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro'!");
                    }
                }
                trabalhador.AddContrato(new Contratos(dataContrato, valorPorHora, duracaoHoras));
            }
            return trabalhador;
        }
        static void Exibir()
        {
            var trabalhador = Leitura();
            int mes, ano;

            Console.Clear();
            Console.WriteLine(">Entre com o mês e ano para calcular o acréscimo na renda");
            while (true)
            {
                Console.Write("[MM/YYYY]: ");
                string entradaData = Console.ReadLine().Trim();

                //Substring(início, comprimento)
                if (int.TryParse(entradaData.Substring(0, 2), out mes) &&
                    int.TryParse(entradaData.Substring(3), out ano))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um valor 'inteiro'!");
                }
            }

            Console.Clear();
            Console.WriteLine("\n\t\tDados do Contrato\n\n");
            Console.WriteLine(trabalhador);
            Console.WriteLine($">Renda Total da data {mes}/{ano}: {trabalhador.RendaTotal(ano,mes):F2}\n");
        }
    }
}

