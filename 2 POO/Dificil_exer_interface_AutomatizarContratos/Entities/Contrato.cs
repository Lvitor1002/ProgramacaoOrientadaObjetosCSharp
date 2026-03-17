using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using treino.Services.Interfaces;

namespace treino.Entities
{
    public class Contrato
    {
        public int NumeroContrato{ get; set; }
        public DateTime DataContrato{ get; set; }
        public decimal ValorTotalContrato{ get; set; }
        public List<Parcelas> ListaParcelas { get; set; } = new List<Parcelas>();

        private readonly IPayPal _paypal;

        public Contrato(decimal valorTotalContrato, IPayPal payPal)
        {
            NumeroContrato = new Random().Next(100);
            DataContrato = DateTime.Now;
            ValorTotalContrato = valorTotalContrato;
            _paypal = payPal; //<- Injeção de dependência
        }

        public void AdicionarParcelas(Parcelas parcelas)
            => ListaParcelas.Add(parcelas);


        public void ProcessarContrato(int qtdMeses)
        {
            decimal valorBase = ValorTotalContrato/ qtdMeses;

            for(int mes = 0; mes < qtdMeses; mes++)
            {
                DateTime dataVencimento = DataContrato.AddMonths(mes);

                // Aplica juros simples (1% ao mês multiplicado pelo número do mês)
                decimal valorComJuros = valorBase + _paypal.JurosSimples(valorBase, mes);

                // Adiciona taxa de pagamento (2% sobre o valor atualizado)
                decimal valorTotal = valorComJuros * _paypal.TaxaPagamento(valorComJuros);

                AdicionarParcelas(new Parcelas(dataVencimento, valorTotal));
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int soma = 0;

            sb.Append($@"
Número do Contrato: {NumeroContrato}
Data do Contrato: {DataContrato.ToString("dd/MM/yyyy HH:mm")}
Valor do Contrato: {ValorTotalContrato:C2}

");
            if(!ListaParcelas.Any())
                return sb.ToString();

            sb.AppendLine("Parcelas\n");
            foreach (var p in ListaParcelas)
                sb.Append($"{soma += 1}ª {p}");

            return sb.ToString();
        }
    }
}
