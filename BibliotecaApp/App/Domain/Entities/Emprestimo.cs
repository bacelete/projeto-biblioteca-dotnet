using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Emprestimo
    {
        public Guid Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }

        public Emprestimo(Guid id, int idLivro, int idUsuario, DateOnly dataEmprestimo, DateOnly dataDevolucao)
        {
            Id = id;
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public Emprestimo(Guid id, int idLivro, int idUsuario, DateOnly dataEmprestimo)
        {
            Id = id;
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo; 
        }
    }
}
