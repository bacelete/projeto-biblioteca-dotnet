using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class HistoricoEmprestimo : ISalvavel
    {
        public string Id = Guid.NewGuid().ToString();
        public Guid IdEmprestimo;
        public int IdUsuario;

        public string ObterChave()
        {
            return Id;
        }

    }
}
