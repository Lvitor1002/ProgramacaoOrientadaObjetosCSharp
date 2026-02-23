

namespace TREINO.Entities
{
    internal class ConversorDeMoeda
    {
        public double ValorDolar { get; set; }

        private double CotacaoDolar = 5.54;
        public ConversorDeMoeda(double valorDolar)
        {
            ValorDolar = valorDolar;
        }

        public double Converte()
        {
            double iof =  ValorDolar * 0.06 * CotacaoDolar;

            double valorReaisPagar = ValorDolar * CotacaoDolar;

            return valorReaisPagar + iof; //Para comprar 10 dolares, é preciso 55 reais
        }

        public override string ToString()
        {
            return $">Compra de ${ValorDolar:F2} Dolares\n" +
                $">Valor a pagar em reais: R${Converte():F2} reais.\n\n";
        }
    }
}
