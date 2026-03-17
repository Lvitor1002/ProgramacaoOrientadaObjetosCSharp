using System;
using treino.Entities.Enuns;

namespace treino.Entities
{
    public class Retangulo : Figura
    {
        private double _largura{ get; set; }
        private double _altura{ get; set; }

        public Retangulo(ECorFigura corFigura, double largura, double altura) : base(corFigura)
        {
            _largura = largura;
            _altura = altura;
        }
        public override double RetornarAreaFigura()
            => _largura * _altura;

        public override string ToString()
            => $@"
{ETipoFigura.Retangulo}

Cor: {CorFigura}
Largura: {_largura}
Altura: {_altura}
Área da Figura: {RetornarAreaFigura():F2}
";
    }
}
