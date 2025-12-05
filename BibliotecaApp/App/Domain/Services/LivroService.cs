using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class LivroService
    {
        public void CriarLivro(Livro livro)
        {
            Biblioteca.AdicionarLivro(livro); 
        }

        public void DeletarLivro(int id)
        {
            Livro livro = BuscarLivroPeloId(id);
            Biblioteca.DeletarLivro(livro); 
        }

        public Livro BuscarLivroPeloId(int id)
        {
            Livro livro = Biblioteca.BuscarLivro(id);

            if (livro == null)
            {
                throw new NullReferenceException("Livro não encontrado!"); 
            }

            return livro; 
        }

        public void AtualizarLivro(int id, Livro novo)
        {
            Livro livro = BuscarLivroPeloId(id);
            Biblioteca.AtualizarLivro(livro, novo);
        }


    }
}
