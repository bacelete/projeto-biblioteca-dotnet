using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Services;

namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        LivroService service = new LivroService();


        service.AdicionarLivro(
            "1", "Engenharia de Software Moderna", "Marco Tulio Valente", "CSJ45B", "2025-12-10", CategoriaLivro.Ciencia);


    }
}
