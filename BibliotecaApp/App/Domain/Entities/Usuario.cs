using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Emprestimo> EmprestimosAtivos { get; set; }

        public Usuario(int id, string nome, string email)
        {
            Id = id; 
            Nome = nome;
            Email = email;
        }

    }
}
