//Pessoa jurídica: 
//                pessoas jurídicas pagam 16% de imposto. 
//                Porém, se a empresa possuir mais de 10 funcionários, ela paga 14% de imposto.
//Exemplo: uma empresa cuja renda foi 400000.00 e possui 25 funcionários, o imposto fica: 400000 * 14 % = 56000.00


using TREINO.Enums;

namespace TREINO.Entities
{
    internal class PessoaJuridica : Colaborador
    {
        public int NumeroFuncionarios{ get; set; }

        public PessoaJuridica(int numeroFuncionarios, string nome, double rendaMensal, Tipo tipo) :base(nome, rendaMensal, tipo)
        {
            NumeroFuncionarios = numeroFuncionarios;
        }

        public override double Imposto()
        {
            if(NumeroFuncionarios > 10)
            {
                return RendaMensal * 0.14;
            }
            return RendaMensal * 0.16;
        }
        public override string ToString()
        {
            return $"\nPessoa {Tipo.Juridica}\n\n" +
                $"\tNome: {Nome}\n" +
                $"\tRenda anual: R${RendaMensal:F2}\n" +
                $"\tNúmero de funcionários: {NumeroFuncionarios}\n" +
                $"\tImposto a pagar: R${Imposto()}\n" +
                $"--------------------------------------------------\n";
        }
    }
}
