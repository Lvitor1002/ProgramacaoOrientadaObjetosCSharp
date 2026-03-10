
using treino.Entities.Enuns;

namespace treino.Entities
{
    public class PessoaJuridica : Contribuinte
    {
        private int _quantidadeFuncionarios { get; set; }
        public PessoaJuridica(TipoContribuintes tipoContribuintes, string nome, decimal rendaMensal, int quantidadeFuncionarios) : base(tipoContribuintes, nome, rendaMensal)
            =>_quantidadeFuncionarios = quantidadeFuncionarios;

        public override decimal CalcularImposto()
            => _quantidadeFuncionarios > 10 ? RendaMensal * 0.14m : RendaMensal * 0.16m;

        public override string ToString()
            =>$@"
Tipo de Contribuinte: {TipoContribuintes.Juridica}
Nome: {Nome}
Renda Mensal: {RendaMensal:C2}
Quantidade de Funcionários: {_quantidadeFuncionarios}
Valor do imposto: {CalcularImposto():C2}
";

    }
}
