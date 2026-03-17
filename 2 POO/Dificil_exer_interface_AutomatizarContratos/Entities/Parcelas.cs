using System;


namespace treino.Entities
{
    public class Parcelas
    {
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }

        public Parcelas(DateTime dataVencimento, decimal valorParcela)
        {
            DataVencimento = dataVencimento;
            ValorParcela = valorParcela;
        }
        public override string ToString()
            => $@"
>Data de Vencimento: {DataVencimento.ToString("dd/MM/yyy")}           
>Valor da parcela: {ValorParcela:F2}

";
    }
}
