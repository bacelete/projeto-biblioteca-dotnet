using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Biblioteca
    {
        public List<Livro> LivroList { get; set; } = new List<Livro>();
    }
}
