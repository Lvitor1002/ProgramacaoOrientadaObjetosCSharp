using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace treino.Entities
{
    public class Instrutor
    {
        private string _nome{ get; set; }
        private HashSet<Alunos> _listaAlunos { get; set; } = new HashSet<Alunos>(); //HasSet não se repete

        public Instrutor(string nome)
            =>_nome = nome;

        public void AdicionarAluno(Alunos aluno)
            =>_listaAlunos.Add(aluno);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($@"
Nome do instrutor: {_nome}
");
            if(!_listaAlunos.Any())
                return sb.ToString();

            sb.AppendLine($"Lista de alunos do instrutor {_nome}:");
            foreach(var aluno in _listaAlunos)
                sb.AppendLine(aluno.ToString());

            sb.AppendLine($"Total de {_listaAlunos.Count} aluno(s)");

            return sb.ToString();
        }
    }
}
