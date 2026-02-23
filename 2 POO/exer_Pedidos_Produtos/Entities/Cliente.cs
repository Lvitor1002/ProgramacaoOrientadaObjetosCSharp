

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TREINO.Entities
{
    internal class Cliente
    {
        public string Nome{ get; set; }
        public string Email{ get; set; }
        public DateTime DataNascimento { get; set; }

        public Cliente(string nome, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }
    }
}
