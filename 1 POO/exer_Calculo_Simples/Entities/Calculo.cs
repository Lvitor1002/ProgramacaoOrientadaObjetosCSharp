using System;


namespace TREINO.Entities
{
    internal class Calculo
    {
        private double Pi = 3.14;

        public double Volume(double raio)
        {
            return 4 /3 * Math.Pow(raio, 3);
        }

        public double Circunferencia(double raio)
        {
            return 2 * Pi * raio;
        }
    }
}
