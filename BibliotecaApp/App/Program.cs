using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Services;

namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        LivroService service = new LivroService();
        service.CadastrarLivro("1", "Engenharia de Software Modera", "Marco Tulio Valente", "CSJ4BN", "2023-12-10", CategoriaLivro.Ciencia);
        Livro novo = new Livro("1", "oi", "oi", "oi", "2025-12-11", CategoriaLivro.Ciencia);
        service.AtualizarLivro("1", novo); 
    }
}
