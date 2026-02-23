

namespace TREINO.Entities
{
    internal class Cobranca
    {
        public double ValorLocacao{ get; set; }
        public double ValorImposto{ get; set; }

        public Cobranca(double valorLocacao, double valorImposto)
        {
            ValorLocacao = valorLocacao;
            ValorImposto = valorImposto;
        }
        public double CalculoCobranca()
        {
            return ValorLocacao + ValorImposto;
        }
    }
}
