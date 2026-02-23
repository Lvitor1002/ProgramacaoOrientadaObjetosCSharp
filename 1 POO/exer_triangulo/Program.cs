

/*
Faça um programa para ler as medidas dos lados de dois triângulos X e Y (suponha medidas válidas).
Em seguida, mostrar o valor das áreas dos dois triângulos e dizer qual dos dois triângulos possui a maior área.

A formula para caluclar a área de um triângulo a partir das medidas de seus lados será raiz(p(p-a)(p-b)(p-c)
*/

using System;
using TREINO.Entities;



namespace TREINO
{
    class Program
    {
        static void Main()
        {
            Exibir();
        }
        public static Triangulos[] Leitura()
        {
            var arrayTriangulos = new Triangulos[2];

            for (int t = 0; t < arrayTriangulos.Length; t++)
            {
                var lados = new double[3];

                Console.Clear();
                Console.Write($"\t\t{t + 1}ª Triângulo\n\n");
                while (true)
                {
                    for (int i = 0; i < lados.Length; i++)
                    {
                        
                        Console.Write($"\t  {i + 1}ª Lado do Triângulo\n");
                        while (true)
                        {
                            Console.Write(">  ");
                            string l = Console.ReadLine().Trim();
                            if (!double.TryParse(l, out double lado) || lado <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Entrada inválida. Digite um número 'inteiro' ou 'real' válido maior que zero!");
                                continue;
                            }
                            lados[i] = lado;
                            break;
                        }
                    }

                    if (lados[0] < lados[1] + lados[2] && 
                        lados[1] < lados[0] + lados[2] &&
                        lados[2] < lados[0] + lados[1])
                    {
                        Triangulos triangulo = new Triangulos(lados);
                        arrayTriangulos[t] = triangulo;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Não é um triângulo. Tente novamente!");
                    }
                }
            }
            return arrayTriangulos;
        }
        public static void Exibir()
        {
            var triangulos = Leitura();
            Console.Clear();

            Console.WriteLine("\t\t   Dados dos triângulos\n\n");

            for (int i = 0; i < triangulos.Length; i++)
            {
                Console.WriteLine($"Triângulo {i + 1}:");
                Console.WriteLine(triangulos[i].ToString());
            }

            double areaX = triangulos[0].Area();
            double areaY = triangulos[1].Area();

            if (areaX > areaY)
            {
                Console.WriteLine($"Maior área: {areaX:F2} - Primeiro Triângulo\n\n");
            }
            else if (areaX < areaY)
            {

                Console.WriteLine($"Maior área: {areaY:F2} - Segundo Triângulo\n\n");
            }
            else
            {
                Console.WriteLine("Áreas iguais\n\n");
            }
        }
    }
}

