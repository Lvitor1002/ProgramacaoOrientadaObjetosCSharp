

using treino.Entities.Enuns;

namespace treino.Entities
{
    public class Funcionario
    {
        public string Nome{ get; set; }
        public int HorasTrabalhadas{ get; set; }
        public decimal ValorPorHora{ get; set; }
        public TipoFuncionario TipoFuncionario { get; set; }

        public Funcionario(string nome, int horasTrabalhadas, decimal valorPorHora, TipoFuncionario tipoFuncionario)
        {
            Nome = nome;
            HorasTrabalhadas = horasTrabalhadas;
            ValorPorHora = valorPorHora;
            TipoFuncionario = tipoFuncionario;
        }

        public virtual decimal ProcessarPagamento()
            => HorasTrabalhadas * ValorPorHora * 30;

        public override string ToString()
            =>$@"
Funcionário {TipoFuncionario.Padrao}
Nome: {Nome}
Horas Trabalhadas: {HorasTrabalhadas} 
Valor Recebido por Hora: R${ValorPorHora:F2}
Pagamento: R${ProcessarPagamento():F2}

";
    }
}
