using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Repository;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        public Livro CadastrarLivro(Livro livro)
        {
            if (IsLivroAlreadyCreated(livro.Id))
            {
                throw new Exception($"Livro de ID {livro.Id} já foi cadastrado no acervo");
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

        public IEnumerable<Livro> BuscarLivrosDisponiveis()
        {
            List<Livro> livros = livroRepository.BuscarTodos();

            var livrosDisponiveis = livros.
                Where(l => l.Status.Equals(StatusLivro.Disponivel.ToString()))
                .OrderBy(l => l.Titulo);

            return livrosDisponiveis;
        }

        public IEnumerable<Livro> BuscarLivroPorTitulo(string titulo)
        {
            List<Livro> livros = livroRepository.BuscarTodos();

            var livrosEncontrados = livros
                .Where(l => l.Titulo == titulo);

            return livrosEncontrados; 
        }

        public IEnumerable<Livro> BuscarLivroPorAutor(string autor)
        {
            List<Livro> livros = livroRepository.BuscarTodos(); 

            var livrosEncontrados = livros
                .Where(l => l.Autor == autor);

            return livrosEncontrados;
        }

    }
}
