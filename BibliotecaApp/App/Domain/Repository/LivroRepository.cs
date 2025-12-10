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
        public static Livro BuscarLivroPeloId(int Id)
        {
            foreach (var livro in Biblioteca.LivroList)
            {
                if (livro.Id == Id)
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
            FileSave.SalvarDadosNoArquivo(Biblioteca.LivroList);
        }

        public static void DeletarLivro(Livro livro)
        {
            Biblioteca.LivroList.Remove(livro);
        }


    }
}
