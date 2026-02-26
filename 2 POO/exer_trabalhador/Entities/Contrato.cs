using System;

namespace treino.Entities
{
    public class Contrato
    {
        public DateTime DataContrato { get; set; }
        private decimal _valorPorHora { get; set; }
        private int _duracaoEmHorasContrato { get; set; }

        public Contrato(DateTime dataContrato, decimal valorPorHora, int duracaoEmHorasContrato)
        {
            DataContrato = dataContrato;
            _valorPorHora = valorPorHora;
            _duracaoEmHorasContrato = duracaoEmHorasContrato;
        }

        public decimal CalcularRendaContrato()
            => _valorPorHora * _duracaoEmHorasContrato;

        public override string ToString()
        {
            return $@"
Data Contrato: {DataContrato.ToString("dd/MM/yyyy")}
Valor Recebido Por Hora: {_valorPorHora:F2}
Duração em Horas do Contrato: {_duracaoEmHorasContrato} horas.

";
        }
    }
}