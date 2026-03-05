
using System.Text;

namespace treino.Entities
{
    public class Comentario
    {
        private string _comentario { get; set; }

        public Comentario(string comentarios)
            =>_comentario = comentarios;

        public override string ToString()
            =>$"{_comentario.ToString()}\n";
    }
}
