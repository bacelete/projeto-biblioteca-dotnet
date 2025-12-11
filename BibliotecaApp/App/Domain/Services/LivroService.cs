using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Repository;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class LivroService
    {
        private readonly LivroRepository livroRepository;
        public LivroService()
        {
            livroRepository = new LivroRepository();
        }

        public void DeletarLivroPeloId(string id)
        {
            Livro livro = BuscarLivroPeloId(id); 

            if (livro == null)
            {
                throw new NullReferenceException("Livro não encontrado no acervo."); 
            }

            livroRepository.DeletarLivro(id);
        }

        public Livro AtualizarLivro(string id, Livro novo)
        {
            return livroRepository.AtualizarLivro(id, novo);
        }

        public Livro CadastrarLivro(
            string id, string titulo, string autor, string isbn, string data, CategoriaLivro categoria)
        {

            if (id.IsWhiteSpace())
                throw new ArgumentException("Id deve ser maior que zero.", nameof(id));

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.", nameof(titulo));

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor não pode ser vazio.", nameof(autor));

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN não pode ser vazio.", nameof(isbn));

            Livro livro = new Livro(id, titulo, autor, isbn, data, categoria);

            if (IsLivroAlreadyCreated(id))
            {
                throw new Exception($"Livro de ID {id} já foi cadastrado no acervo");
            }

            livroRepository.SalvarLivro(livro);
            return livro; 
        }

        private bool IsLivroAlreadyCreated(string id)
        {
            return livroRepository.isLivroAlreadyCreated(id);
        }

        public Livro BuscarLivroPeloId(string id)
        {
            Livro livroEncontrado = livroRepository.BuscarLivroPeloId(id); 

            if (livroEncontrado == null)
            {
                throw new NullReferenceException("Livro não encontrado no acervo");
            }

            return livroEncontrado;
        }

    }
}
