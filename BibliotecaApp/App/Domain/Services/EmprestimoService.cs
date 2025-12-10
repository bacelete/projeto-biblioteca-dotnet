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
            if (IsEmprestimoAtivo(livro))
            {
                throw new ArgumentException("Já existe um emprestimo ativo com esse livro."); 
            }

            Emprestimo emprestimo = new Emprestimo(Guid.NewGuid(), livro.Id, usuario.Id, DateOnly.Parse("2025-12-05"));

            usuario.EmprestimosAtivos.Add(emprestimo);    
            HistoricoEmprestimo.AdicionarEmprestimo(emprestimo);
        }

        private bool IsEmprestimoAtivo(Livro livro)
        {
            List<Emprestimo> emprestimos = HistoricoEmprestimo.emprestimos;

            foreach (Emprestimo emp in emprestimos)
            {
                Livro livroEncontrado = LivroService.BuscarLivroPeloId(emp.IdLivro);
                if (livroEncontrado.Equals(livro))
                {
                    return true;
                }

            }
            return false;
        }
    }
}
