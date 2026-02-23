

using System;
using System.Collections.Generic;


namespace TREINO.Entities
{
    internal class Funcionario
    {
        public int Id{ get; private set; }
        public string Nome {get;set;}
        public double Salario { get; private set; }

        public Funcionario(int id, string nome, double salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }

        public double Aumento(double porcentagem)
        {
            double fator = 1 + (porcentagem / 100);
            
            return Salario *= fator;
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Salário: {Salario:F2}\n\n";
        }
    }
}
