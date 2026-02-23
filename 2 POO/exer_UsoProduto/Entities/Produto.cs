
/*
 Todo produto possui; 
                nome,
                preço.
 */
using System.Collections.Generic;
using System.Text;
using TREINO.Entities.Enums;


namespace TREINO.Entities
{
    class Produto
    {
        public string  Nome{ get; set; }
        public Tipo Tipo{ get; set; }
        public double Preco{ get; set; }
    


        public Produto(string nome, Tipo tipo,double preco)
        {
            Nome = nome;
            Tipo = tipo;
            Preco = preco;
        }

        public override string ToString()
        {
            return $">Produto {Tipo}:\n" +
                        $">Nome do Produto: {Nome}\n" +
                        $">Preço do Produto: {Preco:F2}\n" +
                        $"-----------------------------\n";
        }
    }
}
