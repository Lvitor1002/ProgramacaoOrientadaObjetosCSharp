

using TREINO.Enums;


namespace TREINO.Entities
{
    internal class FuncionarioTerceiro : Funcionario
    {
        public double DespesaAdicional { get; set; }
        
        public FuncionarioTerceiro(double despesaAdicional, string nome, int horasTrabalhadas, Tipo tipo, double valorPorHora) : base(nome, horasTrabalhadas, tipo, valorPorHora)
        {
            DespesaAdicional = despesaAdicional;
        }

        public sealed override double Pagamento()
        {
            ValorPorDia = HorasTrabalhadas * ValorPorHora;
            double despesa = DespesaAdicional * 1.1;
            return base.Pagamento() + despesa;
        }
        public override string ToString()
        {
            double pagamentoMensal = Pagamento();
            return ($"\n'{Tipo}'\n\n" +
                $">Nome: {Nome}\n" +
                $">Horas trabalhadas: {HorasTrabalhadas}\n" +
                $">Despesa Adicional: R${DespesaAdicional:F2}\n" +
                $">Valor por dia recebido: R${ValorPorDia:F2}\n" +
                $">Pagamento mensal: R${pagamentoMensal:F2}\n\n");
        }
    }
}
