using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace App.Domain.Utils
{
    public class FileSave
    {
        public const string path = "dados.json"; 
        public static void SalvarDadosNoArquivo(object obj)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, json);
            Console.WriteLine("Salvo com sucesso!"); 
        }

        public static void CarregarDados()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Biblioteca.LivroList = JsonSerializer.Deserialize<List<Livro>>(json);
            }
            else
            {
                Biblioteca.LivroList = new List<Livro>();
            }
        }
    }
}
