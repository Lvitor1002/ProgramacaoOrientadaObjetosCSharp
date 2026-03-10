
namespace treino.Entities
{
    public class Candidato
    {
        private string _nome{ get; set; }
        private int _quantidadeVotos { get; set; }

        public Candidato(string nome, int quantidadeVotos)
        {
            _nome = nome;
            _quantidadeVotos = quantidadeVotos;
        }

        public override string ToString()
            => $@"
Nome: {_nome}
Quantidade de Votos: {_quantidadeVotos}
";
    }
}
