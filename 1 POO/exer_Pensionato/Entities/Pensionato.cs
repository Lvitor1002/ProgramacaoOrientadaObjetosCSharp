

namespace TREINO.Entities
{
    internal class Pensionato
    {
        public string Nome{ get; set; }
        public string Email{ get; set; }
        public int NumeroQuarto { get; set; }

        public Pensionato(string nome, string email, int numeroQuarto)
        {
            Nome = nome;
            Email = email;
            NumeroQuarto = numeroQuarto;
        }

        public override string ToString()
        {
            return($"Nome: {Nome}\n" +
                $"Email: {Email}\n" +
                $"Numero do Quarto: {NumeroQuarto}\n\n");
             
        }
    }
}
