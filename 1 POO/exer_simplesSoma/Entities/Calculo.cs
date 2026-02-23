using System;
using System.Linq;
using System.Text;


namespace TREINO.Entities
{
    internal class Calculo
    {
        public int[] Valores { get; set; } = new int[2];

        public Calculo(int[] valores)
        {
            Valores = valores;
        }
        public double Soma()
        {
            return Valores.Sum();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;

            sb.AppendLine("\t\t Valores\n\n");
            foreach (var v in Valores)
            {
                i += 1;
                sb.Append($"{i}ª Valor: {v:F0}\n");
            }

            sb.AppendLine($"Soma dos valores: {Soma():F2}\n");

            return sb.ToString();
        }
    }
}
