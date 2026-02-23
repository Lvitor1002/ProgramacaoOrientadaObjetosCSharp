
/*
Uma empresa deseja automatizar o processamento de seus contratos. 

O processamento de um contrato consiste em gerar as parcelas a serem pagas para aquele contrato, com base no número de meses desejado.

A empresa utiliza um serviço de pagamento online para realizar o pagamento das parcelas.

Os serviços de pagamento online tipicamente cobram um juro mensal, bem como uma taxa por pagamento. 

Por enquanto, o serviço contratado pela empresa é o do Paypal, que aplica;
                                                                    juros simples de 1% a cada parcela,
                                                                    taxa de pagamento de 2%.

Fazer um programa para ler os dados de um contrato; 
                                                    número do contrato, 
                                                    data do contrato,
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
using System.Collections.Generic;
using TREINO.Entities;
using TREINO.Services;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        public static Contrato Leitura()
        {
            int idContrato, vezesParcelamento;
            DateTime dataContrato = DateTime.UtcNow;
            double valorContrato;
            

            while (true)
            {
                Console.Write(">Digite o numero do contrato: ");
                string nContrato = Console.ReadLine().Trim();
                if(!int.TryParse(nContrato, out idContrato) || idContrato <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write(">Digite o valor do contrato: R$");
                string vContrato = Console.ReadLine().Trim();
                if (!double.TryParse(vContrato, out valorContrato) || valorContrato <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' maior que zero!");
                    continue;
                }
                break;
            }

            IPaypal servicoPagamento = new Paypal();
            
            Contrato contrato = new Contrato(idContrato,dataContrato,valorContrato,servicoPagamento);

            Console.Clear();
            while (true)
            {
                Console.Write($">Em quantas vezes o valor do contrato foi parcelado? ");
                string xVezes= Console.ReadLine().Trim();
                if (!int.TryParse(xVezes, out vezesParcelamento) || vezesParcelamento <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um número 'inteiro' maior que zero!");
                    continue;
                }
                break;
            }

            contrato.ProcessamentoContrato(vezesParcelamento);
            return contrato;
        }

        public static void Exibir()
        {
            var contrato = Leitura();
            Console.Clear();

            Console.WriteLine($"\n\t Dados da Parcela\n");
            foreach (var c in contrato.TodasParcelas)
            {
                Console.Write(c.ToString());
            }
        }
    }
}

