
//Fazer um programa para ler os dados de N contribuintes (N fornecido pelo usuário),
//os quais podem ser pessoa física ou pessoa jurídica,

//Os dados de pessoa física são: nome,
//                               renda anual,
//                               gastos com saúde. 
//Os dados de pessoa jurídica são: 
//                               nome,
//                               renda anual,
//                               número de funcionários. 

using TREINO.Enums;

namespace TREINO.Entities
{
    abstract class Colaborador : IColaborador
    {
        public string Nome{ get; set; }
        public double RendaMensal{ get; set; }
        public Tipo Tipo { get; set; }

        public Colaborador(string nome,double rendaMensal, Tipo tipo) 
        {
            Nome = nome;
            RendaMensal= rendaMensal;
            Tipo = tipo;
        }

        public abstract double Imposto();
    }

}
