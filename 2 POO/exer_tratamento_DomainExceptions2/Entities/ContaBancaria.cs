
/*
Fazer um programa para ler os dados de uma conta bancária:
                                                          Número:
                                                          Titular 
e depois realizar um saque nesta conta bancária:
                                                Quantos $ deseja sacar?
Por fim, exiba o saldo atual. 

Um saque não pode ocorrer;
                          se o saldo da conta for menor que o saque, 
                                       ou 
                          se o valor do saque for superior ao limite de saque da conta. 

 */


using System;
using TREINO.Entities.Exceptions;


namespace TREINO.Entities
{
    class ContaBancaria
    {
        public int NumeroConta{ get; private set; }
        public string NomeTitular{ get; set; }
        public double Saldo { get; private set; }
        public double SaqueLimite { get; private set; }

        public ContaBancaria(int numeroConta, string nomeTitular)
        {
            if(NumeroConta.ToString().Length > 5) {
                throw new DomainExceptions(">O número da conta deve conter no máximo 5 dígitos.");
            }
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
        }
        public void Saque(double valor)
        {
            SaqueLimite = 5000.00;
            if(valor > Saldo)
            {
                throw new DomainExceptions($">Valor de saque excedeu o saldo de R${SaqueLimite} reais em conta!");
            }
            if(valor > SaqueLimite)
            {
                throw new DomainExceptions($">Valor de saque não pode ultrapassar R${SaqueLimite} reais no mesmo dia!\n>Tente um valor inferior.");
            }
            else
            {
                Saldo -= valor;
            }
        }
        public override string ToString()
        {
            return $">Numero da conta: {NumeroConta}\n" +
                   $">Nome do titular: {NomeTitular}\n" +
                   $">Saldo atual: R${Saldo:F2}\n";
        }
    }
}
