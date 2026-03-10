
using treino.Entities.Enuns;

namespace treino.Entities
{
    public abstract class Contribuinte : IContribuintes
    {
        public TipoContribuintes TipoContribuintes { get; set; }
        public string Nome {  get; set; }
        public decimal RendaMensal {  get; set; }

        public Contribuinte(TipoContribuintes tipoContribuintes, string nome, decimal rendaMensal)
        { 
            TipoContribuintes = tipoContribuintes;
            Nome = nome;
            RendaMensal = rendaMensal;
        }

        public abstract decimal CalcularImposto();
    }
}
