
using System;

namespace TREINO.Entities
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }


        public override string ToString()
        {
            return $">Id: {Id}\n" +
                   $">Nome: {Nome}\n" +
                   $">Preço: {Preco:F2}\n" +
                   $">Nome da categoria: {Categoria.Nome}\n" +
                   $">Categoria: {Categoria.Nivel}\n\n";
        }
    }
}
