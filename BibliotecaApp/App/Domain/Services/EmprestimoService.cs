using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class EmprestimoService
    {
        public void EmprestarLivro(Livro livro, Usuario usuario)
        {
            Emprestimo emprestimo = new Emprestimo(Guid.NewGuid(), livro.Id, usuario.Id, DateOnly.Parse("2025-12-05"));
            usuario.EmprestimosAtivos.Add(emprestimo);    
        }

    }
}
