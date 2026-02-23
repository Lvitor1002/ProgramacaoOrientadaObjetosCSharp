
/*
Em um banco, para se cadastrar uma conta bancária, é necessário informar o 
número da conta, 
o nome do titular da conta, 
e o valor de depósito inicial que o titular depositou ao abrir a conta. 

Este valor de depósito inicial, entretanto, é opcional, ou seja: se o titular não tiver dinheiro a depositar no momento de abrir sua
conta, o depósito inicial não será feito e o saldo inicial da conta será, naturalmente, zero.

Importante: uma vez que uma conta bancária foi aberta, o número da conta nunca poderá ser alterado. Já
o nome do titular pode ser alterado (pois uma pessoa pode mudar de nome por ocasião de casamento, por exemplo).

Por fim, o saldo da conta não pode ser alterado livremente. É preciso haver um mecanismo para proteger isso. 
O saldo só aumenta por meio de depósitos, e só diminui por meio de saques. 

Para cada saque realizado, o banco cobra uma taxa de $ 5.00. 

Nota: a conta pode ficar com saldo negativo se o saldo não for suficiente para realizar o saque e/ou pagar a taxa.

Você deve fazer um programa que realize o cadastro de uma conta, dando opção para que seja ou não informado o valor de depósito inicial. 
Em seguida, realizar um depósito e depois um saque, sempre mostrando os dados da conta após cada operação. 
*/

using System;
using System.Globalization;
using System.Linq;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Leitura();
        }
        public static void Leitura()
        {
            int numeroConta; 
            string nome;
            double valorDeposito = 0, valorSaque = 0;

            numeroConta = new Random().Next(99, 1000);

            while (true)
            {
                Console.Write("Digite o nome do titular da conta: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um nome válido!");
                    continue;
                }
                nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                break;
            }
            ContaBancaria cb = new ContaBancaria(numeroConta, nome);

            Console.Clear();
            while (true)
            {
                Console.Write("Valor do depósito inicial (digite 0 se não houver): R$");
                string deposito = Console.ReadLine().Trim();
                if (!double.TryParse(deposito, out valorDeposito) || valorDeposito < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' maior ou igual a zero!");
                    continue;
                }
                break;
            }
            cb.Depositar(valorDeposito);

            Console.Clear();
            Console.WriteLine("\n\t\tStatus da conta bancária\n");
            Console.WriteLine(cb.ToString());

            while (true)
            {
                Console.Write("Valor do saque (taxa de R$5.00 por operação): R$");
                string saque = Console.ReadLine().Trim();
                if (!double.TryParse(saque, out valorSaque) || valorSaque < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um número 'inteiro' ou 'real' maior ou igual a zero!");
                    continue;
                }
                break;
            }
            cb.Sacar(valorSaque);
            Console.WriteLine("\n\t\tNovo status da conta bancária\n");
            Console.WriteLine(cb.ToString());
        }
    }
}

