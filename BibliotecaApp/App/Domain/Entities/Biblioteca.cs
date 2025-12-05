using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public static class Biblioteca
    {
        private static List<Livro> LivroList { get; set; } = new List<Livro>();

        public static void AdicionarLivro(Livro livro)
        {
            LivroList.Add(livro);
        }

        public static Livro BuscarLivro(int id)
        {
            foreach (var livro in LivroList)
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
            LivroList.Remove(livro); 
        }

        public static void AtualizarLivro(Livro livro, Livro novo)
        {
            LivroList.Remove(livro);
            LivroList.Add(novo);
        }

        public static List<Livro> BuscarTodosOsLivros()
        {
            if (LivroList.Equals(null)) { 
                throw new NullReferenceException("Não há livros cadastrados!");
            }
            return LivroList;
        }

        public static void ExibirInformacoesLivro(Livro livro)
        {
            if (!LivroList.Contains(livro))
            {
                throw new EntryPointNotFoundException("Livro não encontrado no acervo"); 
            }

            Console.WriteLine($"Nome: {livro.Titulo} | Autor: {livro.Autor} |" +
                $" Ano de Publicação: {livro.AnoPublicacao} | Categoria: {livro.Categoria} | ISBN: {livro.ISBN}");
        }
    }
}
