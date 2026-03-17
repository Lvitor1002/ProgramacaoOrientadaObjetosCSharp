

namespace treino.Services.Interfaces
{
    public interface IPayPal
    {
        decimal JurosSimples(decimal capital, int mes);
        decimal TaxaPagamento(decimal valor);
    }
}
