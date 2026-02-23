using System;
using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Retangulo : Figura
    {
        public double Largura{ get; set; }
        public double Altura{ get; set; }

        public Retangulo(double largura, double altura, Cor cor, Modelo modelo) : base(cor, modelo)
        {
            Largura = largura;
            Altura = altura;
        }

        public override double Area()
        {
            return Math.Pow(Altura, 2);
        }

        public override string ToString()
        {
            return ($"\n\t  {Modelo}\n\n" +
                $"Cor: {Cor}\n" +
                $"Largura: {Largura} m²\n" +
                $"Altura: {Altura} m²\n" +
                $"Área do retângulo: {Area():F2} m²\n\n");
        }
    }
}
