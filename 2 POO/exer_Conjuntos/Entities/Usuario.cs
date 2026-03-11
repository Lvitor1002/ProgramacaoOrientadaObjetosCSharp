using System;


namespace treino.Entities
{
    public class Usuario
    {
        public string Nome{ get; set; }
        public DateTime InstanteAcesso { get; set; }

        public Usuario(string nome, DateTime instanteAcesso )
        {
            Nome = nome;
            InstanteAcesso = instanteAcesso;
        }
        public override string ToString()
            => $@"
Nome: {Nome}
Instande de Acesso: {InstanteAcesso.ToString("dd/MM/yyyy HH:mm")}
";
    }
}
