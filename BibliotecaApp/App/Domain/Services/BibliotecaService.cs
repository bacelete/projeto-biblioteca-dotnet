using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class BibliotecaService
    {
        public static void AdicionarLivro(Livro livro)
        {
            Biblioteca.LivroList.Add(livro);
        }

        public static Livro BuscarLivro(int id)
        {
            foreach (var livro in Biblioteca.LivroList)
            {
                if (livro.Id == id)
                {
                    return livro;
                }
            }
            return null;
        }

        public static void DeletarLivro(Livro livro)
        {
            Biblioteca.LivroList.Remove(livro);
        }

        public static void AtualizarLivro(Livro livro, Livro novo)
        {
            Biblioteca.LivroList.Remove(livro);
            Biblioteca.LivroList.Add(novo);
        }

        public static List<Livro> BuscarTodosOsLivros()
        {
            if (Biblioteca.LivroList.Equals(null))
            {
                throw new NullReferenceException("Não há livros cadastrados!");
            }
            return Biblioteca.LivroList;
        }

        public static void ExibirInformacoesLivro(Livro livro)
        {
            if (!Biblioteca.LivroList.Contains(livro))
            {
                throw new EntryPointNotFoundException("Livro não encontrado no acervo");
            }

            Console.WriteLine($"Nome: {livro.Titulo} | Autor: {livro.Autor} |" +
                $" Ano de Publicação: {livro.AnoPublicacao} | Categoria: {livro.Categoria} | ISBN: {livro.ISBN}");
        }
    }
}
