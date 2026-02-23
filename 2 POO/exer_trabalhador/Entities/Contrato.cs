

//em cada N contrato é solicitado;
//data do contrato(DD/MM/YYYY),
//valor por hora
//duração em horas.
//Calcule a renda para contrato.



using System;
using TREINO.Entities.Enums;


namespace TREINO.Entities
{
    class Contratos
    {
        public DateTime DataContrato{ get; set; }
        public double ValorPorHora { get; set; }
        public int DuracaoHoras { get; set; }

        public Contratos()
        {
        }
        public Contratos(DateTime dataContrato, double valorPorHora, int duracaoHoras)
        {
            DataContrato = dataContrato;
            ValorPorHora = valorPorHora;
            DuracaoHoras = duracaoHoras;
        }

        public double RendaSimples()
        {
            return ValorPorHora * DuracaoHoras;
        }
        
    }
}
