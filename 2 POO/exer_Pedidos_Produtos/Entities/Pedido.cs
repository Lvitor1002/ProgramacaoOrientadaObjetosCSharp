

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Pedido
    {
        public DateTime InstantePedido { get; set; } = DateTime.Now;
        public Status Status{ get; set; }
        public Cliente Cliente { get; set; } //<----- Composição -------> Associação de [Objetos]
        public List<Item> ListaItens { get; set; } = new List<Item>();

        public Pedido(DateTime instantePedido, Status status, Cliente cliente)
        {
            InstantePedido = instantePedido;
            Status = status;
            Cliente = cliente;
        }

        public void Additem(Item item)
        {
            ListaItens.Add(item);
        }

        public double Total()
        {
            double soma = 0;
            foreach(Item item in ListaItens)
            {
                soma += item.SubTotal();
            }
            return soma;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n\t     Sumário do pedido\n\n");
            sb.Append($">Instante de compra do pedido: {InstantePedido.ToString("dd/MM/yyyy HH:mm:ss")}\n" +
                $">Status do Pedido: {Status}\n" +
                $">Nome do Cliente: {Cliente.Nome}\n" +
                $">Email do cliente: {Cliente.Email}\n" +
                $">Data de nascimento do Cliente: {Cliente.DataNascimento.ToString("dd/MM/yyyy")}\n" +
                $"-----------------------------------------------------------\n\n");
            
            sb.AppendLine(">Lista de Itens para o pedido\n");
            foreach (Item item in ListaItens)
            {
                sb.Append($"\t\tNome do item: {item.Nome}\n" +
                    $"\t\tQuantidade de Unidades: {item.QuantidadeUnidades}\n" +
                    $"\t\tPreço do item: R${item.SubTotal():F2}\n\n");
            }
            sb.AppendLine($"\n>Valor total do pedido: R${Total():F2}\n\n");
            return sb.ToString();
        }
    }
}
