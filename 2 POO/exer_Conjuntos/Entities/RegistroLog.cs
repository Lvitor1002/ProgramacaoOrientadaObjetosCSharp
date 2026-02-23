
/*
 Um[registro] de log consiste no;
                                 nome de usuário,
                                 instante em que ousuário acessou o site no padrão ISO 8601, separados por espaço.
*/

using System;
using System.Security.Policy;
namespace TREINO.Entities
{
    class RegistroLog
    {
        public string Nome { get; set; }
        public DateTime Instante { get; set; }

        public RegistroLog()
        {
        }
        public RegistroLog(string nome, DateTime instante)
        {
            Nome = nome;
            Instante = instante;
        }

        //Dois objetos de RegistroLog diferentes (com horários diferentes) terão o mesmo código hash se tiverem o mesmo nome de usuário.
        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }

        // Quando que o [Usuario] será igual ao outro objeto?
        // Agora, se eu tentar digitar um outro usuário repetido, não será add e será barrado.
        public override bool Equals(object obj)
        {
            //Se não for um objeto desta classe, então os obj são diferentes=false, senão, são iguais.
            if (!(obj is RegistroLog))
            {
                return false;
            }
            else
            {
                RegistroLog outroNome = obj as RegistroLog; //DownCast
                return Nome.Equals(outroNome.Nome);         //iguais
            }
        }
    }
}
