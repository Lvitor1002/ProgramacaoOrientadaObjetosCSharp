namespace treino.Entities
{
    public class Item
    {
        private string _nome { get; set; }
        private int _unidades { get; set; }
        public decimal Preco { get; set; }

        public Item(string nome, int unidades, decimal preco)
        {
            _nome = nome;
            _unidades = unidades;
            Preco = preco;
        }

        public decimal RetornarSubTotal()
            => _unidades * Preco;

        public override string ToString()
            => $@"
Nome: {_nome}
Unidade: {_unidades}
Preço: {Preco:C2}
----------------------------
";
    }
}