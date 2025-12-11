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
            repEmprestimo = new RepositoryJSON<Emprestimo>("emprestimo.json");
        }

        public void SalvarEmprestimo(Emprestimo emprestimo)
        {
            repEmprestimo.SalvarDados(emprestimo);
        }

    }
}
