
using treino.Services.Interfaces;

namespace treino.Services
{
    public class PayPal : IPayPal
    {
        private const decimal JUROS_SIMPLES = 0.01m;
        private const decimal TAXA = 0.02m;
        
        public decimal JurosSimples(decimal capital, int mes)
        => capital * JUROS_SIMPLES * mes;

        public decimal TaxaPagamento(decimal valor)
            => valor * TAXA;
    }
}
