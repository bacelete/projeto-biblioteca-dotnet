using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace App.Domain.Utils
{
    public class RepositoryJSON<T> : IRepository<T> where T : ISalvavel
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

            var items = CarregarTodos();
            items.Add(obj);

            SalvarTodos(items);
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

        public T Carregar(string id)
        {
            var itens = CarregarTodos(); 
            return itens.FirstOrDefault(item => item.ObterChave() == id);
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
                Console.WriteLine($"Erro ao carregar os dados do arquivo {_caminhoArquivo}: {e.Message}"); 
                return new List<T>(); 
            }
        }
       
    }
}
