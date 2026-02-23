
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
using System.Linq;
using System.Globalization;

using TREINO.Entities;
using TREINO.Entities.Exceptions;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static ContaBancaria Leitura()
        {
            string nome;
            int numeroConta;
            double valor;

            while (true)
            {
                Console.Write(">Digite o número da conta: ");
                string nconta = Console.ReadLine().Trim();
                if(int.TryParse(nconta, out numeroConta))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Certifique-se de que o número da conta esteja válido!");
                }
            }
            while (true)
            {
                Console.Write(">Digite o nome do titular da conta: ");
                nome = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(nome) && nome.All(c=>char.IsLetter(c)|| c== ' '))
                {
                    nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                }
            }
            ContaBancaria cb = new ContaBancaria(numeroConta, nome);

            Console.Clear();
            while (true)
            {
                Console.Write($">{nome}, deseja depositar um valor à sua conta? [Sim/Não]: ");
                string op = Console.ReadLine().Trim().ToLower();
                if(op == "sim")
                {
                    while (true)
                    {
                        Console.Write(">Digite o valor que deseja depositar na conta: ");
                        string v = Console.ReadLine().Trim();
                        if (double.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) && valor >= 0)
                        {
                            cb.Deposito(valor);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(">Entrada inválida. Certifique-se de que o valor de deposito seja maior que zero!");
                        }
                    }
                    break;
                }
                if(op == "não")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite apenas 'sim' ou 'não'!");
                }
            }

            Console.Clear();
            while (true)
            {
                Console.Write($">{nome}, deseja relizar um saque? [Sim/Não]: ");
                string op = Console.ReadLine().Trim().ToLower();
                if (op == "sim")
                {
                    try
                    {
                        while (true)
                        {
                            Console.Write(">Digite o valor que deseja sacar da conta: ");
                            string v = Console.ReadLine().Trim();
                            valor = 0;
                            if (double.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) && valor >= 0)
                            {
                                cb.Saque(valor);
                                break;
                            }
                        }
                        break;
                    }
                    catch (DomainExceptions e)
                    {
                        Console.Clear();
                        Console.WriteLine($"\n>Atenção: {e.Message}\n\n");
                    }
                } 
                if(op == "não")
                {
                    break;
                }
            }
            return cb;
        }
        static void Exibir()
        {
            var cb = Leitura();

            Console.Clear();
            Console.WriteLine("\t\tDados da conta\n");
            Console.WriteLine(cb);
        }
    }
}

