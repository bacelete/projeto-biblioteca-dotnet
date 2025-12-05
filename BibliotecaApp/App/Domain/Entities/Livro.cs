using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Livro
    {
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public String ISBN { get; set; }
        public DateOnly AnoPublicacao { get; set; }
        public enum Categoria
        {
            Ficcao,
            Romance,
            Exatas,
            Historia,
            Biografia,
            Tecnologia
        }
        public enum Status
        {
            Disponivel,
            Emprestado,
            Reservado
        }

    }
}
