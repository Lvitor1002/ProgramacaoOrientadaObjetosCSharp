/*
Um site de internet registra um log de acessos dos usuários. 
Um [registro] de log consiste no; 
                                nome de usuário,
                                instante em que ousuário acessou o site no padrão ISO 8601, separados por espaço.

Fazer um programa que leia o log de acessos apartir de um arquivo, e daí informe quantos usuários do arquivo que são distintos acessaram o site.
 
Arquivo: C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_Conjuntos\in.txt
 */

using System;
using System.Collections.Generic;
using TREINO.Entities;
using System.IO;


namespace TREINO
{
    class Program
    {
        static void Main(string[] args)
        {
            Exibir();
        }
        static HashSet<RegistroLog> Leitura()
        {
            //Como a ordem do arquivo não importa, então usarei o hashSet:
            HashSet<RegistroLog> hash = new HashSet<RegistroLog>();


            Console.Write(">Entre com o arquivo: ");
            string arquivo = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream)
                    {
                        //Lendo o [nome] e [instante] do arquivo a partir de uma entrada só:
                        string[] dividido = sr.ReadLine().Split(' ');

                        string nome = dividido[0];
                        DateTime instante = DateTime.Parse(dividido[1]);

                        hash.Add(new RegistroLog(nome, instante));
                    }
                }
            }
            catch(IOException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            return hash;
        }
        static void Exibir()
        {
            var hash = Leitura();
            
            Console.Clear();
            Console.WriteLine($">Quantidade de usuários: {hash.Count}\n");
        }
    }
}
