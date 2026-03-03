using System;

namespace treino.Entities
{
    public class Cliente
    {
        private string _nome { get; set; }
        private string _email { get; set; }
        private DateTime _dataNascimento { get; set; }

        public Cliente(string nome, string email, DateTime dataNascimento)
        {
            _nome = nome;
            _email = email;
            _dataNascimento = dataNascimento;
        }

        public override string ToString()
            =>$@"
Nome do Cliente: {_nome}
Email do Cliente: {_email}
Data de Nasciment do Cliente: {_dataNascimento.ToString("dd/MM/yyyy")}
";
    }
}