
using TREINO.Enums;

namespace TREINO.Entities
{
    abstract class Figura : IFigura
    {
        public Cor Cor{ get; set; }
        public Modelo Modelo{ get; set; }


        public Figura(Cor cor, Modelo modelo)
        {
            Cor = cor;
            Modelo = modelo;
        }

        public abstract double Area();
    }
}
