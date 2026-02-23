
/*
Instancie manualmente os objetos mostrados na imagem e mostre-os na tela do
terminal, conforme exemplo:

                       Post:
                            21/06/2018 13:05:44
                            Viajando para a Nova Zelândia
                            Vou visitar esse país maravilhoso!
                            12 curtidas    
                Comentários:
                            Tenham uma boa viagem
                            Uau, isso é demais!
                            
        ----------------------------------------------------
                       Post:
                            28/07/2018 23:14:19                            
                            Boa noite, pessoal
                            Até amanhã
                            5 curtidas
                Comentários:
                            Boa noite
                            Que a Força esteja com vocês
*/



using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Collections;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
           
        }
        public static List<Post> Leitura()
        {
            string titulo, descricao, descricaoComentario;
            DateTime dataPublicacao = DateTime.UtcNow;
            int quantidadeCurtidas, qtdPost;

            var listaPostagens = new List<Post>();
            while (true)
            {
                Console.Write($">Quantas postagem foram publicadas? ");
                string qtdP = Console.ReadLine().Trim();
                if (!int.TryParse(qtdP, out qtdPost) && qtdPost < 0)
                {
                    Console.Clear();
                    Console.WriteLine($">Entrada inválida. Digite um número 'inteiro'!");
                    continue;
                }

                break;
            }

            for (int p = 0; p < qtdPost; p++)
            {
                Console.Clear();
                Console.Write($"\t{p + 1}ª - Postagem\n\n");

                while (true)
                {
                    Console.Write(">Digite um titulo para a postagem: ");
                    titulo = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(titulo) || !titulo.All(c => char.IsLetter(c) || c == ' '))
                    {
                        Console.Clear();
                        Console.WriteLine($">Entrada inválida. Titulo incorreto!");
                        continue;
                    }

                    titulo = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titulo.ToLower());

                    break;
                }
                while (true)
                {
                    Console.Write($">Digite uma descrição para a postagem - '{titulo}': ");
                    descricao = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(descricao))
                    {
                        Console.Clear();
                        Console.WriteLine($">Entrada inválida. descrição incorreto!");
                        continue;
                    }

                    break;
                }
        

                while (true)
                {
                    Console.Write($">Digite a quantidade de curtidas para a postagem - '{titulo}': ");
                    string qtdLikes = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdLikes, out quantidadeCurtidas) && quantidadeCurtidas < 0)
                    {
                        Console.Clear();
                        Console.WriteLine($">Entrada inválida. Digite um número 'inteiro'!");
                        continue;
                    }

                    break;
                }
                int qtdC = 0;
                while (true)
                {
                    Console.Write($">Digite o total de comentários para a postagem - '{titulo}': ");
                    string qtdCom = Console.ReadLine().Trim();
                    if (!int.TryParse(qtdCom, out qtdC) && qtdC < 0)
                    {
                        Console.Clear();
                        Console.WriteLine($">Entrada inválida. Digite um número 'inteiro'!");
                        continue;
                    }

                    break;
                }

                Post postagem = new Post(dataPublicacao, titulo, descricao, quantidadeCurtidas);

                for (int i = 0; i < qtdC; i++)
                {
                    Console.Clear();
                    Console.Write($"\t{i + 1}ª - Comentário\n\n");
                    
                    while (true)
                    {
                        Console.Write($">Digite uma descrição para o comentário: ");
                        descricaoComentario = Console.ReadLine().Trim().ToLower();
                        if (string.IsNullOrWhiteSpace(descricaoComentario))
                        {
                            Console.Clear();
                            Console.WriteLine($">Entrada inválida. descrição incorreto!");
                            continue;
                        }

                        break;
                    }
                    Comentario comentario = new Comentario(descricaoComentario);
                    postagem.AddComentario(comentario);
                }

                listaPostagens.Add(postagem);
            }

            return listaPostagens;
        }
        public static void Exibir()
        {
            var postagens = Leitura();
            int i = 0;
            Console.Clear();
            Console.WriteLine("\t   Todas as Postagens\n" +
                "----------------------------------------------");
            foreach (var p in postagens)
            {
                i += 1;
                Console.WriteLine($"\n\t    {i}ª Publicação\n");
                Console.WriteLine(p.ToString());
            }
        }
    }
}

