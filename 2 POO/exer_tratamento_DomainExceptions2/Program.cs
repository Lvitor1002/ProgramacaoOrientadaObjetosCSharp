
/*
Fazer um programa para ler os dados de uma conta bancária:
                                                          Número:
                                                          Titular, 
                                                          Saldo, 
                                                          Saque Limite.
e depois realizar um saque nesta conta bancária:
                                                Quantos $ deseja sacar?
Por fim, exiba o saldo atual. 

Um saque não pode ocorrer;
                          se o saldo da conta for menor que o saque, 
                                       ou 
                          se o valor do saque for superior ao limite de saque da conta. 

 */

using System;
using System.Globalization;
using System.Linq;
using treino.Entities;
using treino.Exception;

namespace TREINO
{
    class Program
    {
        static void Main()
            => PopularConta();
        
        private static void PopularConta()
        {
            string titular;
            int numeroConta;
            decimal valorSaque, valorDeposito;

            while (true)
            {
                Console.Write("Digite o número da conta: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numeroConta) || numeroConta <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Número de conta inválido. Digite um número 'inteiro' e positivo.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Digite o nome do titular da conta: ");
                titular = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(titular) && titular.All(c=>char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um nome válido");
                    continue;
                }
                titular = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(titular.ToLower());
                break;
            }
            ContaBancaria conta = new ContaBancaria(numeroConta, titular);
            
            while (true)
            {
                Console.Write("Digite um valor para deposito na conta: R$");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out valorDeposito) || valorDeposito <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor de deposito inválido. Digite um número 'inteiro' ou 'decimal' e positivo.");
                    continue;
                }
                conta.Depositar(valorDeposito);
                break;
            }
            while (true)
            {
                Console.Write("Digite um valor para saque na conta: R$");
                string entrada = Console.ReadLine().Trim();
                if (!decimal.TryParse(entrada, out valorSaque) || valorSaque <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Valor de saque inválido. Digite um número 'inteiro' ou 'decimal' e positivo.");
                    continue;
                }
                try
                {
                    conta.Sacar(valorSaque);
                    break;
                }
                catch (ExceptionPersonalizada ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine(conta.ToString());
        }
    }
}

