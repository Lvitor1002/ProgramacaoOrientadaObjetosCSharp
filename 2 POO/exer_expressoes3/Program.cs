
/*
Fazer um programa para ler os dados dos funcionários;
                                                    nome, 
                                                    email,
                                                    salário.
de um arquivo em formato .csv.

Em seguida mostrar, em ordem alfabética o email dos funcionários cujo salário seja superior a um dado valor fornecido pelo usuário.

Mostrar também a soma dos salários dos funcionários cujo nome começa com a letra 'M'.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using exer_expressoes3.Entities;

namespace exer_expressoes3
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static List<Funcionarios> Leitura()
        {
            var listaF = new List<Funcionarios>();

            string nomeF, emailF;
            double salarioF;


            Console.Write(">Entre com o arquivo: ");//C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_expressoes3\in.txt
            string arquivo = Console.ReadLine();

            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] arquivoDividido = sr.ReadLine().Split(',');

                        nomeF = arquivoDividido[0];
                        emailF = arquivoDividido[1];
                        salarioF = double.Parse(arquivoDividido[2], CultureInfo.InvariantCulture);

                        Funcionarios funcionarios = new Funcionarios(nomeF, emailF, salarioF);
                        listaF.Add(funcionarios);
                    }
                }
            }
            catch(IOException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
            return listaF;

        }
        static void Exibir()
        {
            var lista = Leitura();
            double valorFornecido = 0;

            while (true)
            {
                Console.Clear();
                Console.Write(">Entre com um valor de salário: ");
                string vs = Console.ReadLine().Trim();

                if(double.TryParse(vs, out valorFornecido) & valorFornecido > 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrda inválida. Digite um número 'inteiro' ou 'real' positivo!");
                }
            }

            Console.Clear();

            //Exibir o email dos funcionários em ordem alfabética cujo salário seja superior a [valorFornecido]
            var emails = lista.Where(f => f.Salario > valorFornecido).OrderBy(f => f.Email).Select(f => new {f.Email,f.Salario});
            
            Console.WriteLine($"\n>Email dos Funcionários cujo salário seja superior a R${valorFornecido:F2}:\n");
            foreach(var e in emails)
            {
                Console.WriteLine($"{e.Email} | {e.Salario:F2}\n" +
                    $"---------------------");
            }


            //Soma dos salários dos funcionários cujo nome começa com a letra 'M'
            double soma = lista.Where(f => f.Nome.StartsWith("M")).Sum(f => f.Salario);
            Console.WriteLine($"\n\n>Soma dos salários dos funcionários cujo nome começa com a letra 'M': {soma:F2}\n");
        }
    }
}
