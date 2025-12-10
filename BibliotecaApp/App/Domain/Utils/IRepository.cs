using System;
using System.Text;
using System.Collections.Generic;


namespace App.Domain.Utils
{
    public interface IRepository<T> where T : ISalvavel
    {
        void SalvarDados(T obj); 
        void SalvarTodos(List<T> obj);

        void Deletar(T obj); 
        T? Carregar(string id);
        List<T> CarregarTodos();

        bool IsObjAlreadyCreated(string id);
    }
}
