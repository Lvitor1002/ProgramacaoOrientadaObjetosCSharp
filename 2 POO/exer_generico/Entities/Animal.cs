using System;
using Etapa1.Enum;

namespace Etapa1.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public Especies Especie { get; set; }
        public int Idade { get; set; }
        public string CaracteristicasFisicas { get; set; }
        public string Personalidade { get; set; }
        public string Apelido { get; set; }
        public DateTime? DataNascimento { get; set; }

        public Animal(int id, Especies especie, int idade, string caracteristicasFisicas, string personalidade, string apelido, DateTime dataNascimento)
        {
            Id = id;
            Especie = especie;
            Idade = idade;
            CaracteristicasFisicas = caracteristicasFisicas;
            Personalidade = personalidade;
            Apelido = apelido;
            DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return $@"
ID: {Id} 
Espécie: {Especie}
Idade: {Idade} 
Características: {CaracteristicasFisicas} 
Personalidade: {Personalidade} 
Apelido: {Apelido}

";
        }
    }
}