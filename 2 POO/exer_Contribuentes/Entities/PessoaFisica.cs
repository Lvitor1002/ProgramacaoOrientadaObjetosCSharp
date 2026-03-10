
using treino.Entities.Enuns;

namespace treino.Entities
{
    public class PessoaFisica : Contribuinte
    {
        private decimal _gastoComSaude{ get; set; }
        public PessoaFisica(TipoContribuintes tipoContribuintes, string nome, decimal rendaMensal, decimal gastoComSaude) :base(tipoContribuintes, nome,rendaMensal)
            =>_gastoComSaude = gastoComSaude;

        public override decimal CalcularImposto()
        {
            decimal imposto = 0;
            if (_gastoComSaude > 0)
                imposto = (RendaMensal < 20000 ? RendaMensal * 0.15m : RendaMensal * 0.25m) - (_gastoComSaude * 0.5m);
            
            return imposto;
        }
        public override string ToString()
        {
            string gasto = _gastoComSaude > 0 ? $"Gasto com Saúde: {_gastoComSaude:C2}" : "";

            return $@"
Tipo de Contribuinte: {TipoContribuintes.Fisica}
Nome: {Nome}
Renda Mensal: {RendaMensal:C2}
Valor do imposto: {CalcularImposto():C2}
{gasto}
";
        }

    }
}
