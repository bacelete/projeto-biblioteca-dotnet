using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Biblioteca
    {
        public static List<Livro> LivroList { get; set; } = new List<Livro>();
        public static List<Emprestimo> EmprestimoList { get; set; }
        public static List<Usuario> UsuarioList { get; set; }= new List<Usuario>();

    }
}
