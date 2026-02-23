
/*
 
Fazer um programa para ler o nome de um aluno e a nota que ele obteve em cada um dos três trimestres do ano
(primeiro trimestre vale 30 e o segundo e terceiro valem 35 cada). Ao final, mostrar qual a nota final do aluno no
ano. 

Dizer também se o aluno está APROVADO ou REPROVADO e, em caso negativo, quantos pontos faltam
para o aluno obter o mínimo para ser aprovado (que é 60 pontos). 

Você deve criar uma classe Aluno para resolver este problema.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main()
        {

            Exibir();
        }
        static Aluno Leitura()
        {
            Trimestre[] trimestres = new Trimestre[3];
            string nome;
            double nota;

            while (true)
            {
                Console.Write(">Digite o nome do aluno: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.All(c=>char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            Console.Clear();
            Console.Write($">Digite 3 notas para o aluno {nome}: \n\n");
            for (int i = 0; i < trimestres.Length; i++)
            {
                Console.Write($">Nota do {i + 1}º trimestre ({(i == 0 ? "0 à 30" : "0 á 35")}): ");

                while (true)
                {
                    string n = Console.ReadLine().Trim();
                    if (!double.TryParse(n, out nota) || nota < 0 || nota > 35)
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite uma nota de 0 à 35!");
                        continue;
                    }
                    trimestres[i] = new Trimestre(i,nota);
                    break;
                }
            }
            Aluno aluno = new Aluno(nome, trimestres);
            return aluno;
        }
        static void Exibir()
        {
            var aluno = Leitura();
            Console.Clear();
            Console.WriteLine("> Sistema de Notas Escolares <");
            Console.WriteLine(aluno.ToString());
        }
    }
}

