
/*


Em um portal de cursos online, cada usuário possui um código único, representado por um número inteiro.

Cada _instrutor do portal pode lecionar vários cursos, 
sendo que um mesmo aluno pode se matricular em quantos cursos quiser. 

Assim, o número total de alunos de um _instrutor não é simplesmente a soma dos alunos de todos os cursos que ele possui, pois pode haver alunos repetidos em mais de um curso.

O _instrutor Alex possui quatro cursos exatas e humanas e deseja saber seu número total de alunos..

Seu programa deve ler os;
                        alunos dos cursos exatas e humanas do _instrutor Alex 
                        depois mostrar a quantidade total de alunos dele.
 
*/

using System;
using System.Globalization;
using System.Linq;
using treino.Entities;
using treino.Entities.Enuns;

namespace TREINO
{
    class Program
    {
        static void Main()
            => ExibirInfos();

        private static Instrutor _instrutor;

        private static void PopularAlunos()
        {
            Curso[] cursos = { Curso.Exatas, Curso.Humanas };
            int quantidadeAlunos = 0;
            string nomeAluno;
            int idAluno;
            
            foreach (Curso curso in cursos)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write($"Quantos alunos no curso {curso}? ");
                    string entrada = Console.ReadLine().Trim();
                    
                    if(!int.TryParse(entrada, out quantidadeAlunos) || quantidadeAlunos <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com um número inteiro maior que zero.");
                        continue;
                    }
                    break;
                }

                for (int i = 0; i < quantidadeAlunos; i++) {
                    Console.Clear();
                    Console.WriteLine($"{i+1}ª Aluno");

                    while (true)
                    {
                        Console.Write($"Entre com o nome do aluno: ");
                        nomeAluno = Console.ReadLine().Trim().ToLower();

                        if (string.IsNullOrWhiteSpace(nomeAluno) || !nomeAluno.All(c=>char.IsLetter(c) || c == ' '))
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um nome válido.");
                            continue;
                        }
                        nomeAluno = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeAluno.ToLower());
                        break;
                    }
                    while (true)
                    {
                        Console.Write($"Entre com o id do aluno {nomeAluno}: ");
                        string entrada = Console.ReadLine().Trim();

                        if (!int.TryParse(entrada, out idAluno) || quantidadeAlunos <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Entrada inválida. Entre com um número inteiro maior que zero.");
                            continue;
                        }
                        break;
                    }
                    _instrutor.AdicionarAluno(new Alunos(idAluno, nomeAluno, curso));
                }
            }
        }
        private static void PopularInstrutor()
        {
            string nomeInstrutor;
            while (true)
            {
                Console.Write($"Entre com o nome do Instrutor: ");
                nomeInstrutor = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(nomeInstrutor) || !nomeInstrutor.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um nome válido.");
                    continue;
                }
                nomeInstrutor = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomeInstrutor.ToLower());
                break;
            }
            _instrutor = new Instrutor(nomeInstrutor);
        }

        private static void ExibirInfos()
        {
            PopularInstrutor();
            PopularAlunos();

            Console.Clear();
            Console.WriteLine(_instrutor.ToString());
        }
    }    
}

