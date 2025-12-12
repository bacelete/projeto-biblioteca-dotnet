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


        public List<T> Buscar(Func<T, bool> criterio)
        {
            var itens = BuscarTodos();
            List<T> encontrados = new List<T>();

            foreach (var item in itens)
            {
                if (criterio(item))
                {
                    encontrados.Add(item);
                }
            }
            return encontrados; 
        }

        public RepositoryJSON(string nomeArquivo)
        {
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var myDir = Path.Combine(docPath, "dados");
            Directory.CreateDirectory(myDir);

            _caminhoArquivo = Path.Combine(myDir, nomeArquivo);
            _opcoes = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
            };
        }

        public void SalvarDados(T obj)
        {
            var items = BuscarTodos();
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

        public T BuscarPelaChave(string id)
        {
            var itens = BuscarTodos(); 
            return itens.FirstOrDefault(item => item.ObterChave() == id);
        }

        public T AtualizarObjeto(string id, T novo) {
            var itens = BuscarTodos();
            int index = EncontrarIndiceObjetoNaLista(itens, id); 

            if (index != -1)
            {
                itens[index] = novo;
            }

            SalvarTodos(itens);
            return itens[index];
        }

        public bool IsObjAlreadyCreated(string id)
        {
            T obj = BuscarPelaChave(id);
            return obj != null; 
        }

        private int EncontrarIndiceObjetoNaLista(List<T> itens, string id)
        {
            return itens.FindIndex((i) => (i.ObterChave() == id)); 
        }

        public void Deletar(string id)
        {
            var itens = BuscarTodos();
            int index = EncontrarIndiceObjetoNaLista(itens, id); 

            if (index != -1)
            {
                itens.RemoveAt(index);
            }

            SalvarTodos(itens); 
        }

        public List<T> BuscarTodos()
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
