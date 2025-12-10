using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Emprestimo> EmprestimosAtivos { get; set; }

        public Usuario(string nome, string email)
        {
            Id = Guid.NewGuid(); 
            Nome = nome;
            Email = email;
        }

    }
}
