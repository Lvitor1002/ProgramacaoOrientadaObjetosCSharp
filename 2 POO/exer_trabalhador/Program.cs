
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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using treino.Entities;
using treino.Entities.Enuns;
using treino.Exception;

namespace TREINO
{
    class Program
    {
        static void Main()
            => ExibirInfos();

        private static void PopularContrato()
        {
            DateTime dataContrato;
            decimal valorPorHora;
            int duracaoEmHorasContrato, qtdContratos;
            var trabalhador = PopularTrabalhador();

            while (true)
            {
                Console.Write($"\n>Quantos contratos serão ao todo? ");
                string qtdcon = Console.ReadLine().Trim();
                if (!int.TryParse(qtdcon, out qtdContratos) && qtdContratos <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro'!");
                    continue;
                }
                break;
            }

            for(int i = 0; i < qtdContratos; i++)
            {
                Console.Clear();
                Console.Write($"\t\t{i + 1}ª Contrato");
                while (true)
                {
                    Console.Write("Entre com a data do contrato, ex: dd/mm/yyyy - ");
                    string entrada = Console.ReadLine().Trim();
                    if(!DateTime.TryParse(entrada, out dataContrato))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite uma data válida. Exemplo: 05/02/2022");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Entre com o valor recebido por hora: R$");
                    string entrada = Console.ReadLine().Trim();
                    if (!decimal.TryParse(entrada, out valorPorHora) || valorPorHora <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um valor válido 'inteiro' ou 'real' positivo");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Entre com a duração em horas do contrato: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out duracaoEmHorasContrato) || duracaoEmHorasContrato <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número inteiro");
                        continue;
                    }
                    break;
                }
                
                trabalhador.AdicionarContrato(new Contrato(dataContrato, valorPorHora, duracaoEmHorasContrato));
            }
            trabalhador.RetornarRendaTotalTrabalhador(02, 2026); //Inserido manualmente. Ganho de tempo
            
            Console.Clear();
            Console.WriteLine(trabalhador);
        }
        private static Trabalhador PopularTrabalhador()
        {
            string nome, departamento;
            Nivel nivelExperiencia;
            decimal salarioBase;

            while (true)
            {
                Console.Write("Entre com o nome do trabalhador: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um nome válido");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            while (true)
            {
                Console.Write("Entre com o departamento do trabalhador: ");
                departamento = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(departamento) || !departamento.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um departamento válido");
                    continue;
                }
                departamento = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(departamento.ToLower());
                break;
            }
            while (true)
            {
                Console.Write($"Entre com o nível de experiência do trabalhador {nome}; [Junior | Pleno | Senior] - ");
                string entrada = Console.ReadLine().Trim();
                if (!Enum.TryParse<Nivel>(entrada, true, out nivelExperiencia))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um nível válido.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write($"Entre com o salário base do trabalhador {nome}: ");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out salarioBase) || salarioBase <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um valor 'inteiro' ou 'real' válido e positivo.");
                    continue;
                }
                break;
            }
            return new Trabalhador(nome, departamento, nivelExperiencia, salarioBase);
        }

        private static void ExibirInfos() 
            =>PopularContrato();
    }    
}

