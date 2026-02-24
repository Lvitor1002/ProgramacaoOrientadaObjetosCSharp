using System;
using treino.Exception;


namespace treino.Entities
{
    public class ReservaHotel
    {
        private int _numeroHotel { get; set; }
        private DateTime _dataCheckin { get; set; }
        private DateTime _dataCheckout { get; set; }

        public ReservaHotel(int numeroHotel, DateTime dataEntrada, DateTime dataSaida)
        {
            if(dataSaida <= dataEntrada)
                throw new ExceptionPersonalizada("A data de saída deve ser maior que a data de entrada");

            _numeroHotel = numeroHotel;
            _dataCheckin = dataEntrada;
            _dataCheckout = dataSaida;
        }
        public void AtualizarDados(DateTime dataEntrada, DateTime dataSaida)
        {
            //-Alterações de reserva só podem ocorrer para datas futuras
            if(dataEntrada.Date < DateTime.Now || dataSaida.Date < DateTime.Now)
                throw new ExceptionPersonalizada($"Alterações de reserva só podem ocorrer para datas futuras, a partir de {DateTime.Now.ToString("dd/MM/yyyy")}");
            
            //-A data de saída deve ser maior que a data de entrada
            if(dataSaida <= dataEntrada)
                throw new ExceptionPersonalizada("A data de saída deve ser maior que a data de entrada");

            _dataCheckin = dataEntrada;
            _dataCheckout = dataSaida;
        }

        private int RetornarDuracaoDias()
        {
            TimeSpan duracao = _dataCheckout.Subtract(_dataCheckin);
            return (int)duracao.TotalDays;
        }
        public override string ToString()
        {
            return $@"
            Número do quarto: {_numeroHotel}
            Data chekin: {_dataCheckin.ToString("dd/MM/yyyy")}
            Data chekout: {_dataCheckout.ToString("dd/MM/yyyy")}
            Duração da estadia: {RetornarDuracaoDias()} dias 
            ";
        }
    }
}
