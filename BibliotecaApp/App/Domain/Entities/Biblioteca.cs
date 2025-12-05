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
    }
}
