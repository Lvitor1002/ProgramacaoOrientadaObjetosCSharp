

/*
Instancie manualmente os objetos mostrados na imagem e mostre-os na tela do
terminal, conforme exemplo:

                       Postagem:
                            21/06/2018 13:05:44
                            Viajando para a Nova Zelândia
                            Vou visitar esse país maravilhoso!
                            12 curtidas    
                Comentários:
                            Tenham uma boa viagem
                            Uau, isso é demais!
                            
        ----------------------------------------------------
                       Postagem:
                            28/07/2018 23:14:19                            
                            Boa noite, pessoal
                            Até amanhã
                            5 curtidas
                Comentários:
                            Boa noite
                            Que a Força esteja com vocês
*/

using System;
using System.Collections.Generic;
using treino.Entities;

namespace TREINO
{
    class Program
    {
        private static Postagem _postagem;

        static void Main()
            => ExibirInformacoes();

        private static List<Postagem> PopularPostagem()
        {
            string descricaoPostagem;
            int quantidadeCurtidasPostagem, quantidadePostagem, quantidadeComentariosPostagem;
            var listaPostagem = new List<Postagem>();

            while (true)
            {
                Console.Write("Digite a quantidade de postagem: ");
                string entrada = Console.ReadLine().Trim().ToLower();
                if (!int.TryParse(entrada, out quantidadePostagem) || quantidadePostagem <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' e positivo maior que zero!");
                    continue;
                }
                break;
            }

            for(int p = 0; p < quantidadePostagem; p++)
            {
                Console.Clear();
                Console.WriteLine($"{p + 1}ª Postagem");
            
                while (true)
                {
                    Console.Write($"Digite a descrição da postagem: ");
                    descricaoPostagem = Console.ReadLine().Trim().ToLower();
                    if (string.IsNullOrWhiteSpace(descricaoPostagem))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um comentário válido!");
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    Console.Write("Digite a quantidade de curtidas para esta postagem: ");
                    string entrada = Console.ReadLine().Trim().ToLower();
                    if (!int.TryParse(entrada, out quantidadeCurtidasPostagem) || quantidadeCurtidasPostagem < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' e positivo!");
                        continue;
                    }
                    break;
                }
                _postagem = new Postagem(descricaoPostagem,quantidadeCurtidasPostagem);

                while (true)
                {
                    Console.Write("Digite a quantidade de comentários para esta postagem: ");
                    string entrada = Console.ReadLine().Trim().ToLower();
                    if (!int.TryParse(entrada, out quantidadeComentariosPostagem) || quantidadeComentariosPostagem < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Digite um número 'inteiro' e positivo!");
                        continue;
                    }
                    break;
                }
                for (int i = 0; i < quantidadeComentariosPostagem; i++)
                {
                    Console.Write($"{i + 1}ª ");
                    _postagem.AdicionarComentariosNaPostagem(PopularComentario());
                }
                listaPostagem.Add(_postagem);
            }
            return listaPostagem;
        }
        private static Comentario PopularComentario()
        {
            string comentario = "";
            while (true)
            {
                Console.Write($"Comentário: ");
                comentario = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(comentario))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um comentário válido!");
                    continue;
                }
                break;
            }
            return new Comentario(comentario);
        }
        private static void ExibirInformacoes()
        {
            var listaPostagem = PopularPostagem();

            Console.Clear();
            foreach(var postagem in listaPostagem)
                Console.WriteLine(postagem);

        }
    }
}

