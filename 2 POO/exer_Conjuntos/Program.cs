/*
Um site de internet registra um log de acessos dos usuários. 
Um [registro] de log consiste no; 
                                nome de usuário,
                                instante em que ousuário acessou o site no padrão ISO 8601, 
                                separados por espaço.

Fazer um programa que leia o log de acessos apartir de um arquivo, 
e daí informe quantos usuários do arquivo que são distintos acessaram o site.
 
Arquivo: C:\Users\Luiz\Desktop\c#\13 POO\14 POO Avançado\exer_Conjuntos\in.txt
 */

using System;
using System.Collections.Generic;
using System.IO;
using treino.Entities;

namespace TREINO
{
    class Program
    {

        static void Main()
            => ExibirInformacoes();

       

        private static HashSet<Usuario> RetornarHashUsuarios()
        {
            string nome, arquivo = "";
            DateTime instanteAcesso;

            //Como a ordem do arquivo não importa, então usarei o hashSet:
            var registroUsuarios = new HashSet<Usuario>();

            while (true)
            {
                Console.Write("Entre com o caminho do arquivo: ");
                arquivo = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(arquivo))
                {
                    Console.Clear();
                    Console.WriteLine("Entrada inválida. Entre com um caminho válido.");
                    continue;
                }
                break;
            }

            try
            {
                using(StreamReader sr = File.OpenText(arquivo))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] dados = sr.ReadLine().Split(' '); 
                        nome = dados[0];

                        if (!DateTime.TryParse(dados[1], out instanteAcesso))
                            continue;

                        registroUsuarios.Add(new Usuario(nome, instanteAcesso));
                    }
                }
            }
            catch(IOException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.ToString());
            }
            return registroUsuarios;
        }
        private static void ExibirInformacoes()
        {
            var registroUsuarios = RetornarHashUsuarios();
            Console.Clear();
            Console.WriteLine("Registros de logs dos usuários:");
            foreach(var registro in registroUsuarios)
                Console.WriteLine(registro.ToString());
        }
    }
}

