
/*
Na contagem de votos de uma eleição, são gerados vários registros de votação contendo; 
                                                                                     o nome do candidato,
                                                                                     quantidade de votos(formato .csv) 
que ele obteve em uma urna de votação. 

Você deve fazer um programa para ler os registros de votação a partir de um arquivo, 
e daí gerar um relatório consolidado com os totais de cada candidato.

 */
using System;
using System.Collections.Generic;
using System.IO;

namespace exer_Conjuntos_Dicionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static Dictionary<string, int> Leitura()
        {
            var dici = new Dictionary<string, int>();

            Console.Write(">Entre com o arquivo: ");  //  C:\Users\Luiz\Desktop\c#\14 POO Avançado\exer_Conjuntos_Dicionario\in.txt
            string arquivo = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    

                    while (!(sr.EndOfStream))
                    {
                        string[] registroVotos = sr.ReadLine().Split(',');

                        string candidato = registroVotos[0];
                        int votos = int.Parse(registroVotos[1]);

                        //agrupar votos por nome
                        if (dici.ContainsKey(candidato))
                        {
                            // Chave do dici
                            dici[candidato] += votos;
                        }
                        else
                        {
                            dici[candidato] = votos;

                        }
                    }
                }

            }catch(IOException e)
            {
                Console.WriteLine(">Erro inesperado!");
                Console.WriteLine(e.Message);
            }
            
            return dici;
        }

        static void Exibir()
        {
            var dici = Leitura();

            Console.Clear();
            foreach (var i in dici)
            {
                Console.WriteLine(i.Key + ": " + i.Value);
            }
        }
    }
}
