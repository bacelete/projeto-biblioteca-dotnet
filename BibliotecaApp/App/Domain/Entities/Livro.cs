using App.Domain.Enums;
using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Livro : ISalvavel
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public DateOnly AnoPublicacao { get; set; }
        
        public string Categoria { get; set; }

        public string Status { get; set; }

        public Livro() { }
        public Livro(string id, string titulo, string autor, string isbn, string anoPublicacao, CategoriaLivro categoria)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = DateOnly.Parse(anoPublicacao); 
            Categoria = categoria.ToString();
            Status = StatusLivro.Disponivel.ToString(); // Status padrão
        }

        public Livro(string titulo, string autor, string isbn, string anoPublicacao, CategoriaLivro categoria)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = DateOnly.Parse(anoPublicacao);
            Categoria = categoria.ToString();
            Status = StatusLivro.Disponivel.ToString(); // Status padrão
        }

        public override string ToString()
        {
            return "ID: " + Id + "| Titulo: " + Titulo + "| Autor: " + Autor + "| ISBN: " + ISBN + "| Data: " + AnoPublicacao;
        }

        public string ObterChave()
        {
            return Id;
        }

    }
}
