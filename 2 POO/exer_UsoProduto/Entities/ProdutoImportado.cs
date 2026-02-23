
//Produtos importados possuem uma taxa de alfândega que deve ser acrescentada ao preço final do produto.

using System.Text;
using TREINO.Entities.Enums;

namespace TREINO.Entities
{
    class ProdutoImportado : Produto
    {

        public double TaxaAlfandega{ get; set; }

        public ProdutoImportado(double taxaAlfandega, string nome, Tipo tipo, double preco) :base(nome, tipo, preco)
        {
            TaxaAlfandega = taxaAlfandega/100;
        }


        //Usando os métodos nesta sub-classe pois é abstrato.
        public double PrecoFinal()
        {
            return Preco *  (1 + TaxaAlfandega);
        }

        public override string ToString()
        {
            return $">Produto {Tipo}\n" +
                          $">Nome do Produto: {Nome}:\n" +
                          $">Preço do Produto: {Preco:F2}\n" +
                          $"Taxa: {TaxaAlfandega}%\n" +
                          $">Preço Final do produto: {PrecoFinal():F2}\n" +
                          $"----------------------------------\n";
        }

    }
}
