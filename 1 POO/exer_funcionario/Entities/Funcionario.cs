

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TREINO.Entities
{
    internal class Funcionario
    {
        public string Nome{ get; set; }
        public double SalarioBruto{ get; private set; }
        public double Imposto{ get; set; }

        public Funcionario(string nome, double salarioBruto, double imposto)
        {
            Nome = nome;
            SalarioBruto = salarioBruto;
            Imposto = imposto;
        }

        public double SalarioLiquido()
        {
            return SalarioBruto - Imposto;
        }
        public void AumentoSalarial(double porcentagem)
        {
            SalarioBruto += SalarioBruto * (porcentagem/100);
        }

        public override string ToString()
        {
            return $"Nome: {Nome}\n" +
                $"Salário Líquido: {SalarioLiquido():F2}\n";
        }

    }
}
