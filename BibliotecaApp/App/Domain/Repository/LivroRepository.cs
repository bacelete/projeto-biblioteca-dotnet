using App.Domain.Entities;
using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace App.Domain.Repository
{
    public class LivroRepository
    {
        private readonly RepositoryJSON<Livro> repLivro; 

        public LivroRepository()
        {
            repLivro = new RepositoryJSON<Livro>("livros.json"); 
        }

        public void AdicionarLivro(Livro livro)
        {
            repLivro.SalvarDados(livro);
        }

    }
}
