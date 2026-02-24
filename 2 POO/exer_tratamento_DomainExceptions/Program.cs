
/*
Fazer um programa para ler os dados de uma reserva de hotel;
                                                            número do quarto, 
                                                            data de entrada, 
                                                            data de saída.
por conseguinte, mostre os dados da reserva, inclusive sua duração em [dias]. 

Em seguida, ler novas; 
                     datas de entrada,
                     datas de entrada saída, 
atualizar a reserva, e mostrar novamente a reserva com os dados atualizados. 

O programa não deve aceitar dados inválidos para a reserva, conforme as seguintes regras:
                    - Alterações de reserva só podem ocorrer para datas futuras
                    - A data de saída deve ser maior que a data de entrada
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
            int numeroHotel;
            DateTime dataEntrada, dataSaida;

            while (true)
            {
                Console.Write("Digite o número do hotel: ");
                string entrada = Console.ReadLine().Trim();
                if(!int.TryParse(entrada, out numeroHotel) || numeroHotel <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Número do hotel inválido. Digite um número 'inteiro' e positivo.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Digite a data do checkin da reserva, ex: dd/mm/yyyy - ");
                string entrada = Console.ReadLine().Trim();
                if (!DateTime.TryParse(entrada, out dataEntrada))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com uma data válida.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("Digite a data do checkout da reserva, ex: dd/mm/yyyy - ");
                string entrada = Console.ReadLine().Trim();
                if (!DateTime.TryParse(entrada, out dataSaida))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com uma data válida.");
                    continue;
                }
                break;
            }

            try
            {
                ReservaHotel reservaHotel = new ReservaHotel(numeroHotel, dataEntrada, dataSaida);
                Console.Clear();

                Console.WriteLine("\t\tAtualizar dados da reserva\n\n");
                while (true)
                {
                    Console.Write("Digite a nova data do checkin da reserva, ex: dd/mm/yyyy - ");
                    string entrada = Console.ReadLine().Trim();
                    if (!DateTime.TryParse(entrada, out dataEntrada))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma data válida.");
                        continue;
                    }
                    break;
                }
                while (true)
                {
                    Console.Write("Digite a nova data do checkout da reserva, ex: dd/mm/yyyy - ");
                    string entrada = Console.ReadLine().Trim();
                    if (!DateTime.TryParse(entrada, out dataSaida))
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Entre com uma data válida.");
                        continue;
                    }
                    break;
                }

                Console.Clear();
                Console.WriteLine("Dados da reserva: ");
                Console.WriteLine(reservaHotel.ToString());

                AtualizarReserva(reservaHotel, dataEntrada, dataSaida);
            }
            catch(ExceptionPersonalizada ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private static void AtualizarReserva(ReservaHotel reservaHotel, DateTime dataEntrada, DateTime dataSaida)
        {
            reservaHotel.AtualizarDados(dataEntrada, dataSaida);
            Console.WriteLine("Dados da reserva atualizado: ");
            Console.WriteLine(reservaHotel.ToString());
        }
    }
}

