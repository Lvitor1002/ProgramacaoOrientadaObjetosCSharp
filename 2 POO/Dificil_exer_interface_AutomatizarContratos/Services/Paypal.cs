

namespace TREINO.Services
{
    internal class Paypal : IPaypal
    {
        private const double JurosMensal = 0.01;
        private const double Taxa = 0.02;

        public double JurosSimples(double valor, int mes)
        {
            return valor * JurosMensal * mes;
        }

        public double TaxaPagamento(double valor)
        {
            return valor * Taxa;
        }
    }
}
