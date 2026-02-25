using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Etapa1.Enum;


namespace Etapa1.Entities
{
    public class NossosAnimais
    {
        
        private List<Animal> _listaAnimais { get; set; } = new List<Animal>();
        private int _proximoId = 1;

        public IReadOnlyList<Animal> Animais => _listaAnimais.AsReadOnly(); //Para acessar os dados da classe NossosAnimais, mas sem permitir alterações diretas na lista externa.

        public void AdicionarNovoAnimal(Animal novoAnimal)
        {
            novoAnimal.Id = _proximoId++;
            _listaAnimais.Add(novoAnimal);
        }

        public Animal BuscarPorId(int id)
            => _listaAnimais.FirstOrDefault(a => a.Id == id);


        public void EditarIdade(int id, int novaIdade)
        {
            var animal = BuscarPorId(id);
            if (animal != null)
                animal.Idade = novaIdade;
            else
                Console.WriteLine("Animal não encontrado.");
        }

        public void EditarPersonalidade(int id, string novaPersonalidade)
        {
            var animal = BuscarPorId(id);
            if (animal != null)
                animal.Personalidade = novaPersonalidade;
            else
                Console.WriteLine("Animal não encontrado.");
        }

        public void FiltrarPorEspecieECaracteristica(Especies especie, string caracteristica)
        {
            var listaFiltrada = _listaAnimais.Where(a =>
                a.Especie.Equals(especie) &&
                a.CaracteristicasFisicas.Contains(caracteristica))
                .ToList();

            foreach(var animal in listaFiltrada)
                Console.WriteLine(animal);
        }

        public void ListarTodos()
        {
            if (_listaAnimais.Count == 0)
                Console.WriteLine("Nenhum animal cadastrado.");

            foreach (var a in _listaAnimais)
                Console.WriteLine(a.ToString());
        }
    }
}
