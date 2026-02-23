


namespace TREINO.Services
{
    internal class Imposto : I_Imposto
    {
        private const double taxaVinte = 0.20;
        private const double taxaQuinze = 0.15;

        public double CalculoImposto(double valorLocacao)
        {
            return valorLocacao <= 100 ? valorLocacao * taxaVinte : valorLocacao * taxaQuinze;
        }
    }
}
