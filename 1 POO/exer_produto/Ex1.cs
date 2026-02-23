

/*
Fazer um programa para ler os dados de um produto em estoque (nome, preço e quantidade no estoque). Em seguida; 
Mostrar os dados do produto (nome, preço, quantidade no estoque, valor total no estoque)

Realizar uma entrada no estoque e mostrar novamente os dados do produto

Realizar uma saída no estoque e mostrar novamente os dados do produto

Para resolver este problema, você deve criar
uma CLASSE conforme a imagem

 */

using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

class Produto
{
    private string _nome;
    public double Preco {get; private set; }
    public int Estoque {get; private set; }

    // [Construtor] para garantir que o Produto sempre tenha valores válidos
    public Produto(string nome, double preco, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    /*Foi usado somente uma [Propriedade] para nome, pois [_nome] está utilizando uma lógica de condicional personalizado, 
    diferente de Preco e Estoque, os mesmos não usam lógica, mas, se porém usassem, aí sim haveria necessidade da mais duas [Propriedade]*/
    /// 
    /// 
    /// 

    // [Propriedade] para acessar e modificar o nome do produto de forma controlada
    public string Nome
    {
        get { return _nome; }

        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                _nome = value;
            }
            else
            {
                throw new ArgumentException(">Nome do produto não pode ser vazio!");
            }
        }
    }


    // [Método] para calcular o valor total do estoque
    public double ValorTotalEstoque()
    {
        return Preco * Estoque;
    } 


    // [Método] para adicionar produtos ao estoque
    public void AdicionarProdutos(int quantidade)
    {
        if(quantidade > 0)
        {
             Estoque += quantidade;
        }
        else
        {
            throw new ArgumentException(">A quantidade deve ser maior que zero!");
        }
    }

    // [Método] para remover produtos do estoque
    public void RemoverProdutos(int quantidade)
    {
        if (quantidade > 0 && quantidade <= Estoque)
        {
            Estoque -= quantidade;
        }
        else
        {
            throw new ArgumentException(">Quantidade inválida para remoção!");
        }
    }
}

class Treino
{
    static void Main()
    {
        var pessoa = Leitura();
        Exibir(pessoa);
    }
    static Produto Leitura()
    {
        Produto p = new Produto(); // Instanciação do Produto

        string nome;
        double preco;
        int estoque;

        Console.Write(">Digite o nome do produto: ");
        while (true)
        {
            nome = Console.ReadLine().Trim().ToLower();
            if(!string.IsNullOrWhiteSpace(nome) && nome.All(c=>char.IsLetter(c) || c == ' '))
            {
                p.Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite um nome válido!");
            }
        }

        Console.Clear();
        Console.Write($">Digite o preço do produto [{p.Nome}], R$:");
        while (true)
        {
            string pre = Console.ReadLine().Trim();
            if (double.TryParse(pre,out preco) && preco > 0)
            {
                p.Preco = preco;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite um preço válido maior que zero!");
            }
        }

        Console.Clear();
        Console.Write($">Digite a quantidade em estoque do produto [{p.Nome}]: ");
        while (true)
        {
            string esto = Console.ReadLine().Trim();
            if (int.TryParse(esto, out estoque) && estoque >= 0)
            {
                p.Estoque = estoque;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite um valor 'inteiro' válido!");
            }
        }
        return p;
    }
    static void Descricao(Produto p)
    {
        Console.Clear();
        Console.WriteLine($">Descrição do Produto:\n\n" +
                          $">Nome: {p.Nome}\n" +
                          $">Preço: {p.Preco:F2}");
        Console.WriteLine(p.Estoque > 0 ? $">Estoque atual: {p.Estoque} unidades" : ">Estoque Vazio!");
        Console.WriteLine($">Valor total no estoque: {p.ValorTotalEstoque()} reais\n" +
                          $"----------------------------------------------------\n");
    }
    static void Exibir(Produto p)
    {
        int quantidade = 0;

        Descricao(p);

        //Realizar uma entrada no estoque e mostrar novamente os dados do produto
        Console.Write(">Digite a quantidade que deseja adicionar ao estoque: ");
        while (true)
        {
            string qtd = Console.ReadLine().Trim();
            if(int.TryParse(qtd, out quantidade) && quantidade > 0)
            {
                p.AdicionarProdutos(quantidade);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite uma quantidade válida, maior que zero!");
            }
        }

        Console.Clear();
        Console.WriteLine("-=-=-=-=-=-=-=-=- Atualização -=-=-=-=-=-=-=-\n");
        Descricao(p);


        //Realizar uma saída no estoque e mostrar novamente os dados do produto
        Console.Write(">Digite a quantidade que deseja remover do estoque: ");
        while (true)
        {
            string qtd = Console.ReadLine().Trim();
            if (int.TryParse(qtd, out quantidade) && quantidade > 0 && quantidade <= p.Estoque)
            {
                p.RemoverProdutos(quantidade);
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(">Entrada inválida. Digite uma quantidade válida, maior que zero!");
            }
        }

        Console.Clear();
        Console.WriteLine("-=-=-=-=-=-=-=-=- Nova Atualização -=-=-=-=-=-=-=-\n");
        Descricao(p);

    }
}




