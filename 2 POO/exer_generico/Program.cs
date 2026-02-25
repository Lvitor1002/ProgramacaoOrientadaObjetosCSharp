
/*
Aplicativo que ajuda a colocar animais de estimação em novos lares. 

As especificações para a sua aplicação são:
                    Crie uma aplicação de console C#.
                    Armazene dados de aplicativos em uma matriz de cadeia de caracteres multidimensional chamada NossosAnimais.

A matriz NossosAnimais inclui as seguintes "características de animais de estimação" para cada animal:
                    ID do animal de estimação #.
                    Espécies de animais de companhia (gato ou cão).
                    Idade do animal de estimação (anos).
                    Descrição da condição/características físicas do animal de estimação.
                    Uma descrição da personalidade do animal de estimação.
                    O apelido do animal de estimação.

Implemente um conjunto de dados de exemplo que represente cães e gatos atualmente sob seus cuidados.
Exibir opções do menu para acessar os principais recursos do aplicativo.

O código exibe as seguintes opções do menu principal para a seleção do usuário:
                            Liste todas as nossas informações atuais sobre animais de estimação.
                            Atribua valores aos campos da matriz ourAnimals.
                            Editar a idade de um animal.
                            Edite a descrição da personalidade de um animal.
                            Exiba todos os gatos com uma característica especificada.
                            Exiba todos os cães com uma característica especificada.
                            Entre na seleção de itens de menu ou digite "Sair" para sair do program

As principais características permitem as seguintes tarefas:
                    Liste as informações dos animais de estimação na lista NossosAnimais.
                    Adicione novos animais à matriz NossosAnimais. 

Aplicam-se as seguintes condições:
                    As espécies de animais de companhia (cão ou gato) devem ser inseridas quando um novo animal é adicionado 
                    à matriz NossosAnimais.
                    
                    Um ID de animal de estimação deve ser gerado programaticamente quando um novo animal é adicionado à 
                    matriz NossosAnimais.
                    
                    Algumas características físicas de um animal de estimação podem ser desconhecidas até o exame 
                    de um veterinário. Por exemplo: idade, raça e estado de esterilização.
                    
                    O apelido e a personalidade de um animal podem ser desconhecidos quando um animal de estimação 
                    chega pela primeira vez.

Certifique-se de que as idades dos animais e as descrições físicas estão completas. 
Isto pode ser necessário após o exame de um veterinário.

Certifique-se de que os apelidos dos animais e as descrições de personalidade estão completos 
(esta ação pode ocorrer depois que a equipe conhece um animal de estimação).

Edite a idade de um animal 
(se a data de nascimento de um animal for conhecida e o animal tiver um aniversário enquanto estiver ao nosso cuidado).

Edite a descrição da personalidade de um animal 
(um animal de estimação pode comportar-se de forma diferente depois de passar mais tempo ao nosso cuidado).

Exiba todos os gatos que atendem às características físicas especificadas pelo usuário.

Exiba todos os cães que atendem às características físicas especificadas pelo usuário.
*/
using System;
using Etapa1.Entities;
using Etapa1.Enum;


namespace Etapa1
{
    public class Program
    {
        public static void Main(string[] args)
            => Menu();

        private static void Menu()
        {
            int opcao;
            NossosAnimais animal = new NossosAnimais();

            while (true)
            {
                
                while (true)
                {
                    ExibirMenu();
                    Console.Write("Escolha uma opção do menu digitando um número: ");
                    string entrada = Console.ReadLine().Trim();
                    if (!int.TryParse(entrada, out opcao) || opcao <= 0 || opcao > 7)
                    {
                        Console.Clear();
                        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                        continue;
                    }
                    break;
                }
                switch (opcao)
                {
                    case 1:
                        ListarInformacoesAnimais(animal);
                        break;
                    case 2:
                        InsirirNovoAnimal(animal);
                        break;
                    case 3:
                        EditarPersonalidadeAnimal(animal);
                        break;
                    case 4:
                        EditarIdadeAnimal(animal);
                        break;
                    case 5:
                        ExibirGatosPorCaracteristicas(animal);
                        break;
                    case 6:
                        ExibirCaesPorCaracteristicas(animal);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Sair");
                        return;
                }
            }
        }

        private static void ExibirMenu()
        {
            Console.WriteLine("\n=== MENU PRINCIPAL ===");
            Console.WriteLine("1. Lista de todas as nossas informações atuais sobre animais de estimação.");
            Console.WriteLine("2. Atribua valores aos campos da matriz NossosAnimais(Novos animais)");
            Console.WriteLine("3. Editar a descrição da personalidade de um animal");
            Console.WriteLine("4. Editar a idade de um animal.");
            Console.WriteLine("5. Exibir todos os gatos com uma característica especificada");
            Console.WriteLine("6. Exibir todos os cães com uma característica especificada");
            Console.WriteLine("7. Sair");
        }

        private static void ExibirCaesPorCaracteristicas(NossosAnimais animal)
        {
            if (animal.Animais.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há animais cadastrados.");
                return;
            }
            Console.Clear();
            animal.FiltrarPorEspecieECaracteristica(Especies.Cachorro,"Pele Escura");
        }

        private static void ExibirGatosPorCaracteristicas(NossosAnimais animal)
        {
            if (animal.Animais.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há animais cadastrados.");
                return;
            }
            Console.Clear();
            animal.FiltrarPorEspecieECaracteristica(Especies.Gato, "Pele parda");
        }

        private static void EditarIdadeAnimal(NossosAnimais animal)
        {
            if (animal.Animais.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há animais cadastrados.");
                return;
            }
            animal.EditarIdade(3, 1);
            Console.Clear();
            Console.WriteLine($"Idade do animal editado com sucesso!");
        }

        private static void EditarPersonalidadeAnimal(NossosAnimais animal)
        {
            if (animal.Animais.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há animais cadastrados.");
                return;
            }
            animal.EditarPersonalidade(2,"Brincalhão");
            Console.Clear();
            Console.WriteLine($"Personalidade do animal editado com sucesso!");
        }

        private static void InsirirNovoAnimal(NossosAnimais animal)
        {
            animal.AdicionarNovoAnimal(new Animal(1, Especies.Gato, 2, "Pele parda", "Agressivo", "Severino", Convert.ToDateTime("24/02/2024")));
            animal.AdicionarNovoAnimal(new Animal(2, Especies.Cachorro, 25, "Pele Escura", "Bomzinho", "Cleiotn", Convert.ToDateTime("11/05/2000")));
            Console.Clear();
            Console.WriteLine($"{animal.Animais.Count} animal(s) cadastrados com sucesso!");
        }

        private static void ListarInformacoesAnimais(NossosAnimais animal)
        {
            if (animal.Animais.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há animais cadastrados.");
                return;
            }
            Console.Clear();
            animal.ListarTodos();
        }
    }
}

