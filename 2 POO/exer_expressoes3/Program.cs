
/*
Fazer um programa para ler os dados dos funcionários;
                                                    nome, 
                                                    funcionario,
                                                    salário.
de um arquivo em formato .csv.

Em seguida mostrar, em ordem alfabética o funcionario dos funcionários cujo salário seja 
superior a um dado valor fornecido pelo usuário.

Mostrar também a soma dos salários dos funcionários cujo nome começa com a letra 'M'.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using treino.Entities;

namespace TREINO
{
    class Program
    {
        static void Main()
            => ExibirInformacoes();
        
        private static List<Funcionario> RetornarListaFuncionarios()
        {
            string arquivo, nome, email;
            decimal salario;
            var listaFuncionarios = new List<Funcionario>();

            while (true)
            {
                Console.Write("Entre com o caminho do arquivo CSV: ");
                arquivo = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(arquivo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida para caminho do arquivo. Tente novamente.");
                    continue;
                }
                break;
            }

            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream) 
                    {
                        string[] dados = sr.ReadLine().Split(',');

                        nome = dados[0];
                        email = dados[1];
                        
                        if(!decimal.TryParse(dados[2], NumberStyles.Any, CultureInfo.InvariantCulture,out salario))
                            salario = 0;

                        listaFuncionarios.Add(new Funcionario(nome,email,salario));
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            return listaFuncionarios;
        }

        private static void ExibirInformacoes()
        {
            var listaFuncionarios = RetornarListaFuncionarios();

            //Em seguida mostrar, em ordem alfabética o funcionario dos funcionários cujo salário seja superior a um dado valor fornecido pelo usuário.
            int valor = 0;
            while (true)
            {
                Console.Write("Entre com um valor desejado para que o mesmo seja avaliado com o salário posteriormente: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out valor) || valor <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' positivo.");
                    continue;
                }
                break;
            }
            var emailCujoSalarioMaiorValor = listaFuncionarios.Where(f => f.Salario > valor)
                .Select(f => new { f.Email, f.Salario })
                .OrderBy(f => f.Email)
                .ToList();

            Console.Clear();
            Console.WriteLine($"Email dos funcionários cujo salário seja superior a {valor} em ordem alfabética:\n");
            foreach(var funcionario in emailCujoSalarioMaiorValor)
                Console.WriteLine($"Email: {funcionario.Email}\nSalário: {funcionario.Salario:C2}\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");


            //Mostrar também a soma dos salários dos funcionários cujo nome começa com a letra 'M'.
            decimal somaSalarioComecaComM = listaFuncionarios.Where(f => f.Nome.StartsWith("M"))
                .Sum(f=>f.Salario);

            Console.WriteLine($"Soma dos salários dos funcionários cujo nome começa com a letra 'M': {somaSalarioComecaComM:C2}\n");
        }
    }
}

