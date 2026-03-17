using System;

using treino.Entities.Enuns;

namespace treino.Entities
{
    public class Circulo : Figura
    {
        private double _raio{ get; set; }
        public Circulo(ECorFigura corFigura, double raio):base(corFigura)
            => _raio = raio;

        public override double RetornarAreaFigura()
            => Math.PI * Math.Pow(_raio,2);

        public override string ToString()
    => $@"
{ETipoFigura.Circulo}

Cor: {CorFigura}
Raio: {_raio}
Área da Figura: {RetornarAreaFigura():F2}
";
    }
}
