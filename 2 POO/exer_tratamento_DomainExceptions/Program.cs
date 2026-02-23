
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
        static (int numeroQuarto, DateTime checkin, DateTime checkout) Leitura(){
            int numeroQuarto; 
            DateTime checkin, checkout;

            while (true)
            {
                Console.Write(">Entre com o número do quarto: Nº");
                string nquarto = Console.ReadLine().Trim();
                if(int.TryParse(nquarto, out numeroQuarto) && numeroQuarto >= 0)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite um número 'inteiro' positivo!");
                }
            }
            while (true)
            {
                Console.Write(">Entre com a data de entrada no hotel; dd/mm/yyyy - ");
                string dtentrada = Console.ReadLine().Trim();
                if (DateTime.TryParse(dtentrada, out checkin))
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite uma data válida -> dd/mm/yyyy");
                }
            }
            while (true)
            {
                Console.Write(">Entre com a data de saída no hotel; dd/mm/yyyy - ");
                string dtsaida = Console.ReadLine().Trim();
                if (DateTime.TryParse(dtsaida, out checkout))
                {
                    if (checkout > checkin)
                    {
                        break; // Saída válida
                    }
                    else
                    {
                        Console.WriteLine("Data de saída deve ser após a data de entrada.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(">Entrada inválida. Digite uma data válida -> dd/mm/yyyy");
                }
            }
            return (numeroQuarto, checkin ,checkout);
        }
        static void Exibir()
        {
            var (numeroQuarto, checkin, checkout) = Leitura();

            ReservaHotel rh = new ReservaHotel(numeroQuarto, checkin, checkout);

            try
            {
                Console.Clear();
                Console.WriteLine("\t\tDados da reserva\n");
                Console.WriteLine(rh);

                while (true)
                {
                    Console.Write("\n\n>Nova data de entrada no hotel; dd/mm/yyyy - ");
                    string dtentrada = Console.ReadLine().Trim();
                    if (DateTime.TryParse(dtentrada, out checkin) && checkin.Date >= DateTime.Today)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite uma data válida -> dd/mm/yyyy");
                    }
                }
                while (true)
                {
                    Console.Write(">Nova data de saída no hotel; dd/mm/yyyy - ");
                    string dtsaida = Console.ReadLine().Trim();
                    if (DateTime.TryParse(dtsaida, out checkout) && checkout.Date > checkin.Date)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(">Entrada inválida. Digite uma data válida -> dd/mm/yyyy");
                    }
                }

                Console.Clear();
                Console.WriteLine("\t\tDados da reserva atualizado\n");
                rh.AtualizarReserva(checkin, checkout);
                Console.WriteLine(rh);
            }
            catch (DomainExceptions e)
            {
                Console.Clear();
                Console.WriteLine($"Erro na reserva: {e.Message}\n");
            }
        }
    }
}

