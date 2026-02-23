//Pessoa física: 
//             pessoas cuja renda foi abaixo de 20000.00 pagam 15% de imposto. 
//             Pessoas com renda de 20000.00 em diante pagam 25% de imposto. 
//             Se a pessoa teve gastos com saúde, 50% destes gastos são abatidos no imposto.
//Exemplo: uma pessoa cuja renda foi 50000.00 e teve 2000.00 em gastos com saúde, o imposto fica: (50000 * 25 %) - (2000 * 50 %) = 11500.00
    

using TREINO.Enums;

namespace TREINO.Entities
{
    internal class PessoaFisica : Colaborador
    {
        public double GastoSaude { get; set; }

        public PessoaFisica(double gastoSaude, string nome, double rendaMensal, Tipo tipo) : base(nome, rendaMensal, tipo)
        {
            GastoSaude = gastoSaude;
        }

        public override double Imposto()
        {
            if (GastoSaude > 0)
            {
                if (RendaMensal < 20000)
                {
                    return (RendaMensal * 0.15) - (GastoSaude * 0.50);
                }
                return (RendaMensal * 0.25) - (GastoSaude * 0.50) ;
            }
            if (RendaMensal < 20000)
            {
                return RendaMensal * 0.15;
            }
            return RendaMensal * 0.25;
        }

        public override string ToString()
        {
            return $"\nPessoa {Tipo.Fisica}\n\n" +
                $"\tNome: {Nome}\n" +
                $"\tRenda anual: R${RendaMensal:F2}\n" +
                $"\tGasto com saúde: R${GastoSaude}\n" +
                $"\tImposto a pagar: R${Imposto()}\n" +
                $"--------------------------------------------------\n";
        }
    }
}