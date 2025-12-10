using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Repository;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public static class LivroService
    {
        public static void AdicionarLivro(
            int id, string titulo, string autor, string isbn, DateOnly anoPublicacao, CategoriaLivro categoria)
        {

            if (id <= 0)
                throw new ArgumentException("Id deve ser maior que zero.", nameof(id));

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("Título não pode ser vazio.", nameof(titulo));

            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("Autor não pode ser vazio.", nameof(autor));

            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("ISBN não pode ser vazio.", nameof(isbn));

            Livro livro = new Livro(id, titulo, autor, isbn, anoPublicacao, categoria); 
            LivroRepository.AdicionarLivro(livro);

        }


        public static void DeletarLivro(int Id)
        {
            Livro livroEncontrado = BuscarLivroPeloId(Id);
            LivroRepository.DeletarLivro(livroEncontrado);

            Console.WriteLine("Livro deletado com sucesso!");
        }

        public static void AtualizarLivro(int id, Livro novo)
        {
            Livro livroExistente = BuscarLivroPeloId(id);

            livroExistente.Titulo = novo.Titulo;
            livroExistente.Autor = novo.Autor;
            livroExistente.AnoPublicacao = novo.AnoPublicacao;
            livroExistente.Categoria = novo.Categoria;

            Console.WriteLine("Livro atualizado com sucesso!");
        }

        public static void ExibirInformacoesLivro(int Id)
        {
            Livro livroEncontrado = BuscarLivroPeloId(Id);

            Console.WriteLine($"Nome: {livroEncontrado.Titulo} | Autor: {livroEncontrado.Autor} |" +
                $" Ano de Publicação: {livroEncontrado.AnoPublicacao} | Categoria: {livroEncontrado.Categoria} | ISBN: {livroEncontrado.ISBN}");
        }

        public static Livro BuscarLivroPeloId(int id)
        {
            Livro livro = LivroRepository.BuscarLivroPeloId(id); 

            if (livro == null)
            {
                throw new NullReferenceException("Livro não encontrado no acervo."); 
            }

            return livro;
        }
       
        public static List<Livro> BuscarTodosOsLivros()
        {
            return LivroRepository.BuscarTodosOsLivros();
        }

    }
}
