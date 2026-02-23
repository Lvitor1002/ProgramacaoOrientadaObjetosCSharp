using System;
using System.ComponentModel;


namespace TREINO.Entities
{
    internal class Trimestre
    {
        public int TrimestreAtual { get; set; }
        public double Nota { get; set; }

        public Trimestre(int trimestreAtual, double nota)
        {
            TrimestreAtual = trimestreAtual;

            //(primeiro trimestre vale 30 e o segundo e terceiro valem 35 cada)
            double validacao = trimestreAtual == 0 ? 30 : 35;
            if(nota < 0 || nota > validacao)
            {
                throw new Exception($"Nota para {trimestreAtual + 1}º trimestre deve ser entre 0 e {validacao}!");
            }
            Nota = nota;
        }

    }
}
