using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public int IdUsuario { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataDevolucao { get; set; }

    }
}
