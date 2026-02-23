
/*
Fazer um programa para ler os dados de um funcionário (nome, salário bruto e imposto). 

Em seguida, mostrar os dados do funcionário (nome e salário líquido). 

Em seguida, aumentar o salário do funcionário com base em uma porcentagem dada (somente o salário bruto é afetado pela porcentagem) 

e mostrar novamente os dados do funcionário. 

Use a classe projetada na imagem.

 */

using System;
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
            string nome;
            double salarioBruto, imposto, porcentagem;

            while (true)
            {
                Console.Write(">Digite o nome do funcionário: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            while (true)
            {
                Console.Write(">Digite o salario bruto do funcionário: R$");
                string sBruto = Console.ReadLine().Trim();
                if (!double.TryParse(sBruto, out salarioBruto) || salarioBruto <= 0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero e válido!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write(">Digite o valor de imposto cobrado: R$");
                string im = Console.ReadLine().Trim();
                if (!double.TryParse(im, out imposto) || imposto < 0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' válido!");
                    continue;
                }
                break;
            }

            Funcionario funcionario = new Funcionario(nome,salarioBruto,imposto);
            Console.Clear();
            Console.WriteLine(funcionario.ToString());

            while (true)
            {
                Console.Write(">Em quantos '%' deseja aumentar o seu salário? %");
                string porc = Console.ReadLine().Trim();
                if (!double.TryParse(porc, out porcentagem) || porcentagem < 0)
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' ou 'real' válido!");
                    continue;
                }
                break;
            }

            funcionario.AumentoSalarial(porcentagem);
            Console.WriteLine(funcionario.ToString());
        }
    }
}

