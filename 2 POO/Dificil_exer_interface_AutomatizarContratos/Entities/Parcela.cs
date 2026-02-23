using System;


namespace TREINO.Entities
{
    internal class Parcela
    {
        public DateTime DataVencimento{ get; set; }
        public double ValorParcela{ get; set; }

        public Parcela(DateTime dataVencimento, double valorParcela)
        {
            DataVencimento = dataVencimento;
            ValorParcela = valorParcela;
        }

        public override string ToString()
        {
            return $">Data de Vencimento: {DataVencimento.ToString("dd/MM/yyy")}\n" +
                $">Valor da parcela: {ValorParcela:F2}\n\n";
        }
    }
}
