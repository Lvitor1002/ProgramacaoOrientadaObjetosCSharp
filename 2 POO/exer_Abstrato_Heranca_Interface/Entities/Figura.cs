

namespace treino.Entities
{
    public abstract class Figura : IFigura
    {
        public ECorFigura CorFigura{ get; set; }

        public Figura(ECorFigura corFigura )
            =>CorFigura = corFigura;

        public abstract double RetornarAreaFigura();
    }
}
