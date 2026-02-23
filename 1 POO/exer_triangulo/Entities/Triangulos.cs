using System;

namespace TREINO.Entities
{
    internal class Triangulos
    {
        public double[] Lados { get; set; } = new double[3];

        public Triangulos(double[] lados)
        {
            Lados=lados;
        }

        public double Area()
        {
            double p = (Lados[0] + Lados[1] + Lados[2])/2;

            return Math.Sqrt(p * (p - Lados[0])* (p - Lados[1])* (p - Lados[2]));
        }

        public override string ToString()
        {
            return $"Lado 1 do triângulo: {Lados[0]:F0}\n" +
                $"Lado 2 do triângulo: {Lados[1]:F0}\n" +
                $"Lado 3 do triângulo: {Lados[2]:F0}\n" +
                $"Área do triângulo: {Area():F2}\n\n";
        }
    }
}
