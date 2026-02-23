
using System.Linq;
using System.Text;
using TREINO.Enums;

namespace TREINO.Entities
{
    internal class Aluno
    {
        public string Nome{ get; set; }
        public Status Status{ get; set; }
        public Trimestre[] Notas { get; private set; } = new Trimestre[3];
        public Aluno(string nome, Trimestre[] notas)
        {
            Nome = nome;
            Notas = notas;
        }

        //Nota final do aluno
        public double NotaFinal()
        {
            return Notas.Sum(x => x.Nota);
        }

        public override string ToString()
        {
            double notaF = NotaFinal();

            StringBuilder sb = new StringBuilder();
            sb.Append($"\n>Nome do aluno: {Nome}\n\n");

            sb.Append($">Notas do aluno:\n");
            for(int i = 0;i < Notas.Length; i++) {

                sb.Append($"\t\t{i+1}ª - Trimestre: {Notas[i].Nota}\n");
            }
            sb.Append(notaF >= 60 ? $"\n>{Nome} foi {Status.Aprovado}!\n\n" 
                    : $"\n>{Nome} foi {Status.Reprovado}. Faltam {60 - notaF:F0} pontos para aprovação!\n\n");
            
            return sb.ToString();
        }
    }
}
