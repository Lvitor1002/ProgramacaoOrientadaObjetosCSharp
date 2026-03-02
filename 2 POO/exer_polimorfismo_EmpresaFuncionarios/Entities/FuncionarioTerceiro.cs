
using treino.Entities.Enuns;

namespace treino.Entities
{
    public class FuncionarioTerceiro : Funcionario
    {
        private decimal _despesaAdicional{ get; set; }
        public FuncionarioTerceiro(decimal despesaAdicional, string nome, int horasTrabalhadas, decimal valorPorHora, TipoFuncionario tipoFuncionario) 
            :base(nome, horasTrabalhadas, valorPorHora, tipoFuncionario) 
            => _despesaAdicional = despesaAdicional;

        public override decimal ProcessarPagamento()
            => base.ProcessarPagamento() + _despesaAdicional * 1.1m;

        public override string ToString()
        {
            return $@"
Funcionário {TipoFuncionario.Terceiro}
Nome: {Nome}
Horas Trabalhadas: {HorasTrabalhadas} 
Despesa Adicional: R${_despesaAdicional:F2}
Valor Recebido por Hora: R${ValorPorHora:F2}
Pagamento: R${ProcessarPagamento():F2}

";
        }
    }
}
