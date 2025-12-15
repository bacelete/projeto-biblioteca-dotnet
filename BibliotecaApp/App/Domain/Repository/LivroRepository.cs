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

        public void SalvarLivro(Livro livro)
        {
            repLivro.SalvarDados(livro);
        }

        public Livro AtualizarLivro(string id, Livro novo)
        {
            return repLivro.AtualizarObjeto(id, novo);
        }

        public Livro BuscarLivroPeloId(string id)
        {
           return repLivro.BuscarPelaChave(id);
        }

        public bool isLivroAlreadyCreated(string id)
        {
            return repLivro.IsObjAlreadyCreated(id);
        }

        public void DeletarLivro(string id)
        {
            repLivro.Deletar(id);
        }

        public List<Livro> BuscarTodos()
        {
            return repLivro.BuscarTodos(); 
        }

    }
}
