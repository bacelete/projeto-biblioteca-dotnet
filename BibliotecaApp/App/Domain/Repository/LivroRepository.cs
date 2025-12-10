using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Repository
{
    public class LivroRepository
    {
        public static Livro BuscarLivroPeloId(int id)
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

        public static List<Livro> BuscarTodosOsLivros()
        {
            return Biblioteca.LivroList;
        }

        public static void AdicionarLivro(Livro livro)
        {
            Biblioteca.LivroList.Add(livro); 
        }

        public static void DeletarLivro(Livro livro)
        {
            Biblioteca.LivroList.Remove(livro);
        }


    }
}
