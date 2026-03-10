/*
Na contagem de votos de uma eleição, 
são gerados vários registros de votação contendo; 
                                                o nome do candidato,
                                                quantidade de votos(formato .csv) 
que ele obteve em uma urna de votação. 

Você deve fazer um programa para ler os registros de votação a partir de um arquivo, 
e daí gerar um relatório consolidado com os totais de cada candidato.

 */

using System;
using System.Collections.Generic;
using System.IO;

namespace TREINO
{
    class Program
    {

        static void Main()
            => ExibirInformacoes();


        private static Dictionary<string, int> RetornarListaCandidatos()
        {
            var dicionarioCandidatos = new Dictionary<string, int>();
            string nome, arquivo = "";
            int quantidadeVotos;

            while (true)
            {
                Console.Write("Entre com o caminho do arquivo: ");
                arquivo = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(arquivo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Digite um arquivo válido!");
                    continue;
                }
                break;
            }
            try
            {
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream) 
                    {
                        string[] dados = sr.ReadLine().Split(',');
                        nome = dados[0];

                        if (!int.TryParse(dados[1], out quantidadeVotos))
                            continue;

                        if (!dicionarioCandidatos.ContainsKey(nome))
                            dicionarioCandidatos[nome] = 0;

                        dicionarioCandidatos[nome] += quantidadeVotos; 
                    }
                }
            }
            catch (IOException ex) 
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            return dicionarioCandidatos;
        }

        private static void ExibirInformacoes()
        {
            var dicionarioCandidatos = RetornarListaCandidatos();

            Console.Clear();
            Console.WriteLine("Lista de Candidatos\n");
            foreach(var candidatos in dicionarioCandidatos)
                Console.WriteLine($"{candidatos.Key}: {candidatos.Value}");
        }
    }
}

