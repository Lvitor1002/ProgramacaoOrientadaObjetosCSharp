using System;


namespace TREINO.Entities
{
    internal class Retangulo
    {
        public double Largura { get; set; }
        public double Altura{ get; set; }

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        public double Area()
        {
            return Largura * Altura/2;
        }
        public double Perimetro()
        {
            return Altura + Largura;
        }
        public double Diagonal()
        {
            var elevadoA = Math.Pow(Altura,2);
            var elevadoL = Math.Pow(Altura, 2);

            return Math.Sqrt(elevadoA + elevadoL);
        }

        public override string ToString()
        {
            return $"Largura do triângulo: {Largura:F0}\n" +
                $"Altura do triângulo: {Altura:F0}\n" +
                $"Área do triângulo: {Area():F2}\n" +
                $"Perímetro do triângulo: {Perimetro():F2}\n" +
                $"Diagonal do triângulo: {Diagonal():F2}\n\n";
        }
    }
}
