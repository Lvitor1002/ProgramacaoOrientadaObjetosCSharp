using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using treino.Entities.Enuns;

namespace treino.Entities
{
    public class Pedido
    {
        private DateTime _instanteDoPedido{ get; set; }
        private Status _status { get; set; }
        private List<Item> _listaItens { get; set; } = new List<Item>();
        private Cliente _cliente { get; set; }
        
        public Pedido(Status status, Cliente cliente)
        {
            _instanteDoPedido = DateTime.Now;
            _status = status;
            _cliente = cliente;
        }
        public void AdicionarItemAoPedido(Item item)
            => _listaItens.Add(item);

        private decimal RetornarPrecoTotal()
            => _listaItens.Sum(i => i.RetornarSubTotal());

        public override string ToString()
        {
            int soma = 0;
            var sb = new StringBuilder();

            sb.Append($@"
Instante do Pedido: {_instanteDoPedido.ToString("dd/MM/yyyy HH:mm")}
Status do Pedido: {_status}
{_cliente.ToString()}
");

            if(!_listaItens.Any())
                return sb.ToString();

            sb.AppendLine($@"Quantidade de itens: {_listaItens.Count} itens");
            foreach (var item in _listaItens)
                sb.Append($@"
{soma+=1}ª Item 
{item.ToString()}
");
            sb.AppendLine($"Preço Total: {RetornarPrecoTotal():C2}");

            return sb.ToString();
        }
    }
}
