

namespace TREINO.Entities
{
    internal class Produtos
    {
        public string Nome{ get; set; }
        public double Preco { get; set; }

        public Produtos(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\n" +
                    $"Preço: {Preco}\n\n";
        }
    }
}
