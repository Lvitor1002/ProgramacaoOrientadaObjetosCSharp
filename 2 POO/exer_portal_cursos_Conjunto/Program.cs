
/*
Em um portal de cursos online, cada usuário possui um código único, representado por um número inteiro.

Cada instrutor do portal pode ter vários cursos, 
sendo que um mesmo aluno pode se matricular em quantos cursos quiser. 

Assim, o número total de alunos de um instrutor não é simplesmente a soma dos alunos de todos os cursos que ele possui, pois pode haver alunos repetidos em mais de um curso.

O instrutor Alex possui quatro cursos exatas e humanas e deseja saber seu número total de alunos..

Seu programa deve ler os;
                        alunos dos cursos exatas e humanas do instrutor Alex 
                        depois mostrar a quantidade total de alunos dele.
 */


using System;
using System.Linq;
using System.Globalization;

using TREINO.Entities;
using System.Collections.Generic;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static (HashSet<int> exatas, HashSet<int> humanas, Instrutor instrutor) Leitura()
        {
            HashSet<int> exatas = new HashSet<int>();
            HashSet<int> humanas = new HashSet<int>();
       

            string nomeInstrutor;
            int idAluno, qtdExatas = 0,qtdHumanas = 0;

            while (true)
            {
                Console.Write(">Qual o nome do instrutor: ");
                nomeInstrutor = Console.ReadLine().Trim().ToLower();

                if(!string.IsNullOrWhiteSpace(nomeInstrutor) && nomeInstrutor.All(c=>char.IsLetter(c) || c==' '))
                {
                    nomeInstrutor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeInstrutor.ToLower());
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                }
            }
            Instrutor instrutor = new Instrutor(nomeInstrutor);
            Console.Clear();
            while (true)
            {
                Console.Write($">Quantos alunos o instrutor {nomeInstrutor} possui em exatas? ");
                string qtd = Console.ReadLine().Trim();

                if (int.TryParse(qtd, out qtdExatas) && qtdExatas >= 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido!");
                }
            }
            Console.WriteLine($">Digite o id para cada aluno de exatas: ");
            for (int i = 0; i < qtdExatas; i++)
            {
                while (true)
                {
                    Console.Write($"{i+1}ª ID: ");

                    string idaluno = Console.ReadLine().Trim();
                    if(int.TryParse(idaluno, out idAluno) && idAluno >= 0)
                    {
                        exatas.Add(idAluno);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido!");
                    }
                }
            }
            Console.Clear();
            while (true)
            {
                Console.Write($">E quantos em humanas? ");
                string qtd = Console.ReadLine().Trim();

                if (int.TryParse(qtd, out qtdHumanas) && qtdHumanas >= 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido!");
                }
            }
            Console.WriteLine($">Digite o id para cada aluno de humanas: ");
            for (int i = 0; i < qtdHumanas; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}ª ID: ");

                    string idaluno = Console.ReadLine().Trim();
                    if (int.TryParse(idaluno, out idAluno) && idAluno >= 0)
                    {
                        humanas.Add(idAluno);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' válido!");
                    }
                }
            }
            return (exatas, humanas, instrutor);
        }
        static void Exibir()
        {
            var (exatas, humanas, instrutor) = Leitura();
            

            HashSet<int> todos = new HashSet<int>(exatas);    //Garante que não há duplicação de ID's:
            
            //Exatas junta com humanas para então diferencialos no .Count
            todos.UnionWith(humanas);

            Console.Clear();
            Console.WriteLine(instrutor);
            Console.WriteLine($">Quantidade total de alunos distintos em seus dois cursos: {todos.Count}\n");
        }
    }
}
