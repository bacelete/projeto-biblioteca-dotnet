using App.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public DateOnly AnoPublicacao { get; set; }
        
        public CategoriaLivro Categoria { get; set; }

        public StatusLivro Status { get; set; }

        public Livro(int id, string titulo, string autor, string isbn, DateOnly anoPublicacao, CategoriaLivro categoria)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;
            Categoria = categoria;
            Status = StatusLivro.Disponivel; // Status padrão
        } 

    }
}
