
//Post:
//21 / 06 / 2018 13:05:44
//                            Viajando para a Nova Zelândia
//                            Vou visitar esse país maravilhoso!
//                            12 curtidas    

using System;
using System.Collections.Generic;
using System.Text;

namespace TREINO.Entities
{
    internal class Post
    {
        public DateTime DataPublicacao { get; set; } = DateTime.UtcNow;
        public string Titulo { get; set; }
        public string Descricao{ get; set; }
        public int QuantidadeCurtidas{ get; set; }
        public List<Comentario> ListaComentarios { get; set; } = new List<Comentario>();

        public Post(DateTime dataPublicacao, string titulo, string descricao, int quantidadeCurtidas)
        {
            DataPublicacao = dataPublicacao;
            Titulo = titulo;
            Descricao = descricao;
            QuantidadeCurtidas = quantidadeCurtidas;
        }

        public void AddComentario(Comentario comentario)
        {
            ListaComentarios.Add(comentario);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
     
            sb.Append($"Data e hora: {DataPublicacao.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                $"'{Titulo}'\n" +
                $"'{Descricao}'\n" +
                $"{QuantidadeCurtidas} curtidas\n\n" +
                $"\t    Comentários\n\n");

            foreach (var c in ListaComentarios)
            {
                sb.Append($"'{c.Descricao}'\n");
            }
            return sb.ToString();
        }

    }
}
