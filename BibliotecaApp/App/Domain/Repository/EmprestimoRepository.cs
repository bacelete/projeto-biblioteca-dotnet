using App.Domain.Entities;
using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Repository
{
    public class EmprestimoRepository
    {
        private readonly RepositoryJSON<Emprestimo> repEmprestimo;
        public EmprestimoRepository() {
            repEmprestimo = new RepositoryJSON<Emprestimo>("emprestimos.json");
        }

        public void SalvarEmprestimo(Emprestimo emprestimo)
        {
            repEmprestimo.SalvarDados(emprestimo);
        }

        public List<Emprestimo> BuscarTodos()
        {
            return repEmprestimo.BuscarTodos();
        }

        public List<Emprestimo> BuscarEmprestimoPeloIdLivro(Func<Emprestimo, bool> criterio)
        {
            return repEmprestimo.Buscar(criterio); 
        }

        public Emprestimo BuscarEmprestimo(string idEmprestimo)
        {
            return repEmprestimo.BuscarPelaChave(idEmprestimo);
        }

        public Emprestimo AtualizarEmprestimo(string idEmprestimo, Emprestimo novo)
        {
            return repEmprestimo.AtualizarObjeto(idEmprestimo, novo);
        }


    }
}
