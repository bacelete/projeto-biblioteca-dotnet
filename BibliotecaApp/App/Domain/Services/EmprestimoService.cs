using App.Domain.Entities;
using App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class EmprestimoService
    {
        private readonly EmprestimoRepository emprestimoRepository;
        private readonly LivroService livroService; 

        public EmprestimoService()
        {
            emprestimoRepository = new EmprestimoRepository();
        }

        public static void CadastrarEmprestimo(string idLivro, string idUsuario)
        {
            
        }
    }
}
