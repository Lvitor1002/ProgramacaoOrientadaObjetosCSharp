using System;
using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Circulo : Figura
    {

        public double Raio{ get; set; }

        public Circulo(double raio, Cor cor, Modelo modelo):base(cor, modelo)
        {
            Raio = raio;
        }

        public override double Area()
        {
            return Math.PI * (Math.Pow(Raio, 2));
        }

        public override string ToString()
        {
            return ($"\n\t  {Modelo}\n\n" +
                $"Cor: {Cor}\n" +
                $"Raio do círculo: {Raio}\n" +
                $"Área do círculo: {Area():F2} m²\n\n");
        }
    }
}
