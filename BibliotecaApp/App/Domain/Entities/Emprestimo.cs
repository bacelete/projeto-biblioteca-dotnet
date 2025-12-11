using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Emprestimo : ISalvavel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdLivro { get; set; }
        public string IdUsuario { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }

        public Emprestimo(string idLivro, string idUsuario, DateOnly dataEmprestimo)
        {
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataEmprestimo.AddDays(7); 
        }

        public string ObterChave()
        {
            return Id;
        }
    }
}
