using System;
using System.Collections.Generic;
using TREINO.Services;

namespace TREINO.Entities
{
    internal class Contrato
    {
        public int IdContrato{ get; set; }
        public DateTime DataContrato { get; set; } = DateTime.UtcNow;
        public double ValorContrato { get; set; }
        public List<Parcela> TodasParcelas { get; set; } = new List<Parcela>();

        private readonly IPaypal _servicoPagamento;

        public Contrato(int idContrato, DateTime dataContrato, double valorContrato, IPaypal servicoPagamento)
        {
            IdContrato = idContrato;
            DataContrato = dataContrato;
            ValorContrato = valorContrato;
            _servicoPagamento  = servicoPagamento; //<- Injeção de dependência
        }

        public void AddParcela(Parcela parcela)
        {
            TodasParcelas.Add(parcela);
        }

        public void ProcessamentoContrato(int qtdMeses)
        {
            double valorBase = ValorContrato/ qtdMeses;

            for(int mes = 1; mes <= qtdMeses; mes++)
            {
                DateTime dataVencimento = DataContrato.AddMonths(mes);

                // Aplica juros simples (1% ao mês multiplicado pelo número do mês)
                double valorComJuros = valorBase + _servicoPagamento.JurosSimples(valorBase, mes);

                // Adiciona taxa de pagamento (2% sobre o valor atualizado)
                double valorTotal = valorComJuros * _servicoPagamento.TaxaPagamento(valorComJuros);

                AddParcela(new Parcela(dataVencimento, valorTotal));
            }
        }
    }
}
