

namespace TREINO.Entities
{
    internal class Item
    {
        public string Nome{ get; set; }
        public int QuantidadeUnidades{ get; set; }
        public double Preco{ get; set; }
            
        public Item(string nome, int quantidadeUnidades, double preco)
        {
            Nome = nome;
            QuantidadeUnidades = quantidadeUnidades;
            Preco = preco;
        }
        public double SubTotal()
        {
            return QuantidadeUnidades * Preco;
        }

    }
}
