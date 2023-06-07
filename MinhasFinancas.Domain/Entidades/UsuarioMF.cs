using MinhasFinancas.Domain.Core.Shared;
using System;

namespace MinhasFinancas.Domain.Entidades
{
    public class UsuarioMF : Entidade
    {
        protected UsuarioMF(){}

        public UsuarioMF(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; } 

    

        public void Editar(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
