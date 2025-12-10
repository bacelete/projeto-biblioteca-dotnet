using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace App.Domain.Utils
{
    public class RepositoryJSON<T> : IRepository<T>
    {
        private readonly string _caminhoArquivo;
        private readonly JsonSerializerOptions _opcoes; 

        public RepositoryJSON(string caminhoArquivo, JsonSerializerOptions opcoes)
        {
            _caminhoArquivo = caminhoArquivo;
            _opcoes = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }

        public void SalvarDados(T obj)
        {
            if (obj == null)
            {
                throw new Exception("Objeto nulo."); 
            }
            var list = obj as List<T>;
            SalvarTodos(list);
        }

        public void SalvarTodos(List<T> obj)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj, _opcoes);
                File.WriteAllText(_caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message}");
            }
        }

        public T Carregar(int id)
        {
            
        }

        public List<T> CarregarTodos()
        {
            try
            {
                string json = File.ReadAllText(_caminhoArquivo);
                return JsonSerializer.Deserialize<List<T>>(json, _opcoes) ?? new List<T>();
            }
            catch (Exception e)
            {
                return new List<T>(); 
            }
        }
       
    }
}
