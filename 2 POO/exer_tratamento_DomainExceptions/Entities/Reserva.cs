


/*
Fazer um programa para ler os dados de uma reserva de hotel;
                                                            número do quarto, 
                                                            data de entrada, 
                                                            data de saída.
por conseguinte, mostre os dados da reserva, inclusive sua duração em [dias]. 

---------------------------------------

> Em seguida, ler novas; 
                     datas de entrada,
                     datas de entrada saída, 
atualizar a reserva, e mostrar novamente a reserva com os dados atualizados.
*/

using System;
using TREINO.Entities.Exceptions;


namespace TREINO.Entities
{
    class ReservaHotel
    {
        public int NumeroQuarto{ get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public ReservaHotel(int numeroQuarto, DateTime checkin, DateTime checkout)
        {
            if(checkout <= checkin)  //Tratando diretamente pelo Construtor
            {
                throw new DomainExceptions(">Data de saída(checkout) deve ser maior que a data de entrada(checkin)!");
            }

            NumeroQuarto = numeroQuarto;
            Checkin = checkin;
            Checkout = checkout;
        }

        public int DuracaoReserva()
        {
            TimeSpan duracaoReserva = Checkout.Subtract(Checkin); //Diferença dos dois (Checkout) e (Checkin)
            
            return (int)duracaoReserva.TotalDays;
        }

        public void AtualizarReserva(DateTime novoCheckin, DateTime novoCheckout)
        {
            DateTime hoje = DateTime.Today;

            if (novoCheckin.Date < hoje || novoCheckout.Date < hoje)
            {
                throw new DomainExceptions("As novas datas devem ser futuras!");
            }
            if (novoCheckout <= novoCheckin)
            {
                throw new DomainExceptions(">Data de saída (checkout) deve ser maior que a data de entrada (checkin)!");
            }

            Checkin = novoCheckin;
            Checkout = novoCheckout;
        }

        public override string ToString()
        {
            return $">Data de entrada: {Checkin.ToString("dd/MM/yyyy")}\n" +
                   $">Data de saída: {Checkout.ToString("dd/MM/yyyy")}\n" +
                   $">Quarto hospedado: Nº{NumeroQuarto}\n" +
                   $">Duração da estadia: {DuracaoReserva()} dias.";
        }
    }
}
