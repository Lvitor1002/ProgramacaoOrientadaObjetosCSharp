using treino.Entities.Enuns;

namespace treino.Entities
{
    public class Alunos
    {
        private int _id;
        private string _nome { get; set; }
        private Curso _curso{ get; set; }

        public Alunos(int id, string nome, Curso curso ) 
        {
            _id = id;
            _nome = nome;
            _curso = curso;
        }

        public override bool Equals(object idAluno)
        {
            // Verifica se o objeto passado como parâmetro é do tipo Alunos
            if (idAluno is Alunos outroId)
                return _id == outroId._id;

            return false;
        }

        public override int GetHashCode()
            => _id.GetHashCode();

        public override string ToString()
        =>$@"
Nome do aluno: {_nome}
Curso do aluno: {_curso}
";
    }
}
