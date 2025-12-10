using System;
using System.Text;
using System.Collections.Generic;


namespace App.Domain.Utils
{
    public interface IRepository<T>
    {
        void SalvarDados(T obj); 
        void SalvarTodos(IEnumerable<T> obj);
        T? Carregar(int id);
        List<T> CarregarTodos();
    }
}
