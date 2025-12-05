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
            if (livro.Titulo.IsWhiteSpace())
            {
                throw new ArgumentException("Titulo não pode ser vazio");
            }
            if (livro.Autor.IsWhiteSpace())
            {
                throw new ArgumentException("O livro deve conter um autor."); 
            }
            if (livro.AnoPublicacao == null)
            {
                throw new ArgumentException("O livro deve possuir um ano de publicação."); 
            }

            Biblioteca.AdicionarLivro(livro); 
        }


    }
}
