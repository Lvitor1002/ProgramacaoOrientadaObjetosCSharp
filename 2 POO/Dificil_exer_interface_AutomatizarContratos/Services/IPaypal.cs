

namespace TREINO.Services
{
    internal interface IPaypal
    {
        double JurosSimples(double valor, int mes);
        double TaxaPagamento(double valor);
    }
}
