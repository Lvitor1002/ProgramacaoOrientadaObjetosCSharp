


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TREINO.Entities
{
    internal class ContaBancaria
    {
        public int NumeroConta { get; private set; }
        public string Nome { get; set; } 
        public double Saldo { get; private set; } = 0;

        public ContaBancaria(int numeroConta, string nome)
        {
            NumeroConta = numeroConta;
            Nome = nome;
        }
        
        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
        }
        public void Sacar(double valorSaque)
        {
            double taxa = 5.0;
            Saldo -= (valorSaque + taxa);
        }

        public override string ToString()
        {
            return ($">Numero conta: {NumeroConta}\n" +
                $">Nome do titular: {Nome}\n" +
                $">Saldo da conta: R${Saldo:F2}\n\n");
        }
    }
}
