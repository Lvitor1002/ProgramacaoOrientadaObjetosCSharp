
using System;
using treino.Exception;

namespace treino.Entities
{
    public class ContaBancaria
    {
        private int _numeroConta{ get; set; }
        private string _titularConta{ get; set; }
        private decimal _saldoConta{ get; set; }
        private decimal SaqueLimiteConta{ get; set; } = 10000.00m;

        public ContaBancaria(int numeroConta, string titularConta)
        {
            _numeroConta = numeroConta;
            _titularConta = titularConta;
        }

        public void Depositar(decimal valorDeposito)
            => _saldoConta += valorDeposito;

        public void Sacar(decimal valorSaque)
        {
            if (_saldoConta < valorSaque)
                throw new ExceptionPersonalizada($"Saldo da conta insulficiente. Saldo: R${_saldoConta:F2}");

            if(valorSaque > SaqueLimiteConta)
                throw new ExceptionPersonalizada($"Valor do saque superior ao limite de saque de R${SaqueLimiteConta:F2} para a conta");

            _saldoConta -= valorSaque;
        }
        public override string ToString()
        {
            return $">Numero da conta: {_numeroConta}\n" +
                   $">Nome do titular: {_titularConta}\n" +
                   $">Saldo atual: R${_saldoConta:F2}\n";
        }
    }
}
