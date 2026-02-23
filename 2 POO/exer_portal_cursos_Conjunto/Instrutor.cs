

//Cada instrutor do portal pode ter vários cursos

//O instrutor Alex possui quatro cursos exatas e humanas e deseja saber seu número total de alunos.


namespace TREINO.Entities
{
    class Instrutor
    {
        public string Nome { get; set; }

        public Instrutor(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return $">Nome do instrutor responsável: {Nome}\n";
        }
    }
}
