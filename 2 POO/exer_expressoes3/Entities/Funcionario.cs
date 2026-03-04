
namespace treino.Entities
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal Salario{ get; set; }

        public Funcionario(string nome, string email, decimal salario)
        {
            Nome = nome;
            Email = email;
            Salario = salario;
        }
    }
}
