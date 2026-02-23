
/*
Uma locadora brasileira de carros cobra um valor por hora para locações de até 12 horas. 
Porém, se a duração da locação ultrapassar 12 horas, a locação será cobrada com base em um valor diário. 

Além do valor da locação, é acrescido no preço o valor do imposto conforme regras do país que, 
no caso do Brasil, é; 
                     20% para valores até 100.00, 
                                    ou
                     15% para valores acima de 100.00. 

Fazer um programa que lê os dados da locação;
                                             modelo do carro, 
                                             instante inicial da locação,
                                             instante final da locação, 
                                             valor por hora,
                                             valor diário de locação. 

O programa deve então informar os dados da nota de pagamento na tela, contendo; 
                                                                               valor da locação, 
                                                                               valor do imposto,
                                                                               valor total do pagamento.
 */

using System;
using System.Linq;
using System.Globalization;



namespace exer_interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Leitura();
        }
        static void Leitura()
        {
            string modelo;
            DateTime instanteInicial, instanteFinal;
            double valorPorHora = 0, valorPorDia = 0;

            try
            {
                Console.Clear();
                while (true)
                {
                    Console.Write(">Digite o modelo do carro: ");
                    modelo = Console.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrWhiteSpace(modelo) && modelo.All(c => char.IsLetter(c) || c == ' '))
                    {
                        modelo = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(modelo.ToLower());
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite um nome válido!");
                    }
                }
                while (true)
                {
                    Console.Write(">Digite o instante inicial da locação do carro: (dd/mm/yyyy hh:mm) ");
                    string inicial = Console.ReadLine().Trim();


                    if (DateTime.TryParseExact(inicial, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out instanteInicial))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite valores válidos no formato: (dd/mm/yyyy hh:mm) ");
                    }
                }
                while (true)
                {
                    Console.Write(">Digite o instante final da locação do carro: (dd/mm/yyyy hh:mm) ");
                    string final = Console.ReadLine().Trim();
                    if (DateTime.TryParseExact(final, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out instanteFinal))
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite valores válidos no formato: (dd/mm/yyyy hh:mm) ");
                    }

                }


                LocacaoCarro ac = new LocacaoCarro(instanteInicial, instanteFinal, new Carro(modelo));


                while (true)
                {
                    Console.Write(">Digite o valor por hora para locação do carro: ");
                    string vHora = Console.ReadLine().Trim();
                    if (double.TryParse(vHora, out valorPorHora) && valorPorHora > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite valores 'inteiros' ou 'reais' positivos!");
                    }
                }
                while (true)
                {
                    Console.Write(">Digite o valor por dia para locação do carro: ");
                    string vDia = Console.ReadLine().Trim();
                    if (double.TryParse(vDia, out valorPorDia) && valorPorDia > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite valores 'inteiros' ou 'reais' positivos!");
                    }
                }
                LocacaoCarro LocacaoCarro = new LocacaoCarro(instanteInicial, instanteFinal, new Carro(modelo));
                LocacaoCarroService LocacaoCarroService = new LocacaoCarroService(valorPorHora, valorPorDia, new ImpostoBrasil());

                LocacaoCarroService.GerarCobranca(LocacaoCarro);

                Console.Clear();
                Console.WriteLine("\tFatura\n\n" +
                                 $"{LocacaoCarro.Fatura}\n\n");
            }
            catch (LocadoraExceptions l)
            {
                Console.Clear();
                Console.WriteLine($"\n>Atenção: {l.Message}\n");
            }
        }
    }
}
