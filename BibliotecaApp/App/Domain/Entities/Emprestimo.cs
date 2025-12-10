using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Emprestimo : ISalvavel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }

        public Emprestimo(int idLivro, int idUsuario, DateOnly dataEmprestimo, DateOnly dataDevolucao)
        {
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public Emprestimo(int idLivro, int idUsuario, DateOnly dataEmprestimo)
        {
            IdLivro = idLivro;
            IdUsuario = idUsuario;
            DataEmprestimo = dataEmprestimo; 
        }

        public string ObterChave()
        {
            return Id;
        }
    }
}
