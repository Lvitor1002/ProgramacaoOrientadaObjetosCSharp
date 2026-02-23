

namespace TREINO.Services
{
    internal interface I_Imposto
    {
        //Necessário, se não ficará inviável chamar esse método em outras classes diferentes
        double CalculoImposto(double valor);
    }
}
