/*
Uma empresa deseja automatizar o processamento de seus contratos. 

O processamento de um contrato consiste em gerar as parcelas a serem pagas para aquele contrato, 
com base no número de meses desejado.

A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas.

Os serviços de pagamento online tipicamente cobram um juro mensal, bem como uma taxa por pagamento. 

Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica;
                                                                    juros simples de 1% a cada parcela,
                                                                    taxa de pagamento de 2%.

Fazer um programa para ler os dados de um contrato; 
                                                    número do contrato(pode ser gerado aleatóriamente), 
                                                    data do contrato(datetime.now),
                                                    valor total do contrato. 

Em seguida, o programa deve ler; 
                                número de meses para parcelamento do contrato

e gerar os registros de parcelas a serem pagas (data e valor), 
sendo; 
        a primeira parcela a ser paga um mês após a data do contrato, 
        a segunda parcela dois meses após o contrato 
e assim por diante. 

Mostrar os dados das parcelas na tela ao final.
*/

using System;
using treino.Entities;
using treino.Services;
using treino.Services.Interfaces;

namespace TREINO
{
    class Program
    {
        static void Main()
            => ExibirInformacoes();

        private static void PopularContrato()
        {
            decimal valorTotalContrato;
            while (true)
            {
                Console.Write("Entre com o valor do contrato: R$ ");
                string entrada = Console.ReadLine().Trim();
                if(!decimal.TryParse(entrada, out valorTotalContrato) || valorTotalContrato <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um valor 'inteiro' maior que zero.");
                    continue;
                }
                break;
            }
            IPayPal payPal = new PayPal();
            var contrato = new Contrato(valorTotalContrato, payPal);

            var numeroMesesParcelamento = RetornarQuantidadeParcelas();
            contrato.ProcessarContrato(numeroMesesParcelamento);

            Console.Clear();
            Console.WriteLine(contrato.ToString());
        }
        private static int RetornarQuantidadeParcelas()
        {
            int numeroMesesParcelamento = 0;
            while (true)
            {
                Console.Write($"Em quantas vezes o valor do contrato será parcelado: ");
                string entrada = Console.ReadLine().Trim();
                if (!int.TryParse(entrada, out numeroMesesParcelamento) || numeroMesesParcelamento <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }
            return numeroMesesParcelamento;
        }
        private static void ExibirInformacoes()
            => PopularContrato();

    }
}

