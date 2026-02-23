using System;

using TREINO.Entities;

namespace TREINO.Services
{
    internal class LocadoraService 
    {
        public double ValorPorHora{ get; private set; }//Private: Posso apenas obter os valores, não posso modificalos de outra classe
        public double ValorPorDia{ get; private set; }

        //Obtendo acesso ao método da interface:
        private I_Imposto _Imposto;

        public LocadoraService(double valorPorHora, double valorPorDia,I_Imposto imposto)
        {
            ValorPorHora = valorPorHora;
            ValorPorDia = valorPorDia;
            _Imposto = imposto;
        }

        public void ValorCobrado(Locadora locadora)
        {
            if (locadora.InstanteFinal < locadora.InstanteInicial) { 
                throw new ArgumentException("Data final menor que inicial");
            }

            TimeSpan tempo = locadora.InstanteFinal - locadora.InstanteInicial;
            double horas = tempo.TotalHours;

            double valorLocacao = 0;

            if(horas <= 12)
            {
                valorLocacao = ValorPorHora * Math.Ceiling(horas);
            }
            else
            {
                double dias = Math.Ceiling(horas / 24);
                valorLocacao = ValorPorDia * dias;
            }

            double valorImposto = _Imposto.CalculoImposto(valorLocacao);

            locadora.Cobranca = new Cobranca(valorLocacao, valorImposto);
        }

    }
}
