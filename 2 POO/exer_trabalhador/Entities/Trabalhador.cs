
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using treino.Entities.Enuns;
namespace treino.Entities
{
    public class Trabalhador
    {
        private string _nome { get; set; }
        private string _departamento { get; set; }
        private Nivel _nivelExperiencia { get; set; }
        private decimal _salarioBase { get; set; }
        private List<Contrato> _listaContratos { get; set; } = new List<Contrato> ();
        private decimal _rendaTotal { get; set; }

        public Trabalhador()
        {
        }

        public Trabalhador(string nome, string departamento, Nivel nivelExperiencia, decimal salarioBase)
        {
            _nome = nome;
            _departamento = departamento;
            _nivelExperiencia = nivelExperiencia;
            _salarioBase = salarioBase;
        }
        

        public void AdicionarContrato(Contrato contrato)
            =>_listaContratos.Add(contrato);

        public decimal RetornarRendaTotalTrabalhador(int mes, int ano)
        {
            _rendaTotal = _salarioBase += _listaContratos.Where(c => c.DataContrato.Month == mes && c.DataContrato.Year == ano).Sum(c => c.CalcularRendaContrato());
            return _rendaTotal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($@"
Nome: {_nome}
Departamento: {_departamento}
Salário Base: {_salarioBase:F2}
Nível de Experiência: {_nivelExperiencia}
Renda Total: {_rendaTotal:F2}

");
            if (!_listaContratos.Any())
                return sb.ToString();

            for (int i = 0; i < _listaContratos.Count; i++)
                sb.AppendLine($"{i + 1}ª Contrato\n{_listaContratos[i].ToString()}");

            return sb.ToString();
        }
    }
}
