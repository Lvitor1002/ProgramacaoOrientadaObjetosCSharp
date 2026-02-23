
//produtos usados possuem data de fabricação;

using System;
using System.Text;
using TREINO.Entities.Enums;


namespace TREINO.Entities
{
    class ProdutoUsado : Produto
    {
        public DateTime DataFabricacao{ get; set; }

        public ProdutoUsado(DateTime dataFabricacao, string nome, Tipo tipo, double preco) :base(nome, tipo, preco)
        {
            DataFabricacao = dataFabricacao;
        }


        public override string ToString()
        {
            return $">Produto {Tipo}\n" +
                          $">Nome do Produto: {Nome}:\n" +
                          $">Preço do Produto: {Preco:F2}\n" +
                          $">Data de Fabricação: {DataFabricacao.ToString("dd/MM/yyyy")}\n" +
                          $"------------------------------------\n";
        }
    }
}
