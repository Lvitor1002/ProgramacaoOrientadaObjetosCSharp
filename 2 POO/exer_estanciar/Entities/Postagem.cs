using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace treino.Entities
{
    public class Postagem
    {
        private DateTime _dataPostagem{ get; set; }
        private string _descricaoPostagem { get; set; }
        private int _quantidadeCurtidasPostagem { get; set; }
        private List<Comentario> _listaComentarios { get; set; } = new List<Comentario>();

        public Postagem(string descricaoPostagem, int quantidadeCurtidasPostagem)
        {
            _dataPostagem = DateTime.Now;
            _descricaoPostagem = descricaoPostagem;
            _quantidadeCurtidasPostagem = quantidadeCurtidasPostagem;
        }

        public void AdicionarComentariosNaPostagem(Comentario comentario)
            =>_listaComentarios.Add(comentario);

        public override string ToString()
        {
            var sb = new StringBuilder();
            int i = 0;

            sb.Append($@"
Postado em {_dataPostagem.ToString("dd/MM/yyy HH:mm")}
{_descricaoPostagem}
{_quantidadeCurtidasPostagem} Curtidas

");
            
            if(!_listaComentarios.Any())
                return sb.ToString();

            sb.AppendLine("Comentários:");
            foreach (var comentario in _listaComentarios)
                sb.AppendLine(comentario.ToString());
            
            return sb.ToString();
        }
    }
}
