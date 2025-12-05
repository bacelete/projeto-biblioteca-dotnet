using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public static class LivroService
    {
        public static void CriarLivro(Livro livro)
        {
            Biblioteca.AdicionarLivro(livro); 
        }

        public static void DeletarLivro(int id)
        {
            Livro livro = BuscarLivroPeloId(id);
            Biblioteca.DeletarLivro(livro); 
        }

        public static Livro BuscarLivroPeloId(int id)
        {
            Livro livro = Biblioteca.BuscarLivro(id);

            if (livro == null)
            {
                throw new NullReferenceException("Livro não encontrado!"); 
            }

            return livro; 
        }

        public static void AtualizarLivro(int id, Livro novo)
        {
            Livro livro = BuscarLivroPeloId(id);
            Biblioteca.AtualizarLivro(livro, novo);
        }


    }
}
