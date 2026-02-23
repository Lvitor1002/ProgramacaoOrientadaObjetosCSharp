

using System;
using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Locadora
    {
        public Modelo Modelo { get; set; }
        public DateTime InstanteInicial { get; set; } = DateTime.UtcNow;
        public DateTime InstanteFinal { get; set; }
        public Cobranca Cobranca { get; set; }
        public Locadora(Modelo modelo, DateTime instanteFinal)
        {
            Modelo = modelo;
            InstanteFinal = instanteFinal;
            Cobranca = null; //Começa como vazia
        }
        public override string ToString()
        {
            return $"\n>Carro {Modelo}\n" +
                $">Ato do contrato: {InstanteInicial.ToString("dd/MM/yyy HH:mm:ss")}\n" +
                $">Valor da locação: R${Cobranca.ValorLocacao:F2}\n" +
                $">Valor do Imposto: R${Cobranca.ValorImposto:F2}\n" +
                $">Valor total do pagamento: R${Cobranca.CalculoCobranca():F2}\n\n";
        }
    }
}
