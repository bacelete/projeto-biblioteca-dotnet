using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class HistoricoEmprestimo
    {
        public static List<Emprestimo> emprestimos { get; set; }

        public static void AdicionarEmprestimo(Emprestimo emprestimo)
        {
            emprestimos.Add(emprestimo);
        }

    }
}
