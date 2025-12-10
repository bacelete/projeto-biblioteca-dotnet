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

        public void AdicionarLivro(
            string id, string titulo, string autor, string isbn, DateOnly anoPublicacao, CategoriaLivro categoria)
        {

            if (id.IsWhiteSpace())
                throw new ArgumentException("Id deve ser maior que zero.", nameof(id));

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.", nameof(titulo));

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor não pode ser vazio.", nameof(autor));

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN não pode ser vazio.", nameof(isbn));

            Livro livro = new Livro(id, titulo, autor, isbn, anoPublicacao, categoria);
            livroRepository.AdicionarLivro(livro);

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
