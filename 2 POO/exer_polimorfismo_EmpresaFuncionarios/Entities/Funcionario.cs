


using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Funcionario 
    {
        public string Nome{ get; set; }
        public int HorasTrabalhadas{ get; set; }
        public double ValorPorDia{ get; set; } //<-- Será calculado manualmente a partir das HorasTrabalhadas
        public Tipo Tipo{ get; set; }
        public double ValorPorHora { get; set; }

        public Funcionario(string nome, int horasTrabalhadas, Tipo tipo, double valorPorHora)
        {
            Nome = nome;
            HorasTrabalhadas = horasTrabalhadas;
            Tipo = tipo;
            ValorPorHora = valorPorHora;
        }

        public virtual double Pagamento() {
            ValorPorDia = HorasTrabalhadas * ValorPorHora;
            return ValorPorDia * 30;
        }

        public override string ToString()
        {
            double pagamentoMensal = Pagamento();
            return ($"\n'{Tipo}'\n" +
                $">Nome: {Nome}\n" +
                $">Horas trabalhadas: {HorasTrabalhadas}\n" +
                $">Valor por dia recebido: R${ValorPorDia:F2}\n" +
                $">Pagamento mensal: R${pagamentoMensal:F2}\n\n");
        }
    }
}
