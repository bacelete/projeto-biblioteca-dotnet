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
            "1", "Engenharia de Software Moderna", "Marco Tulio Valente", "CSJ45B", DateOnly.Parse("2025-12-05"), CategoriaLivro.Ciencia);

        service.AdicionarLivro("1", "teste", "teste", "CSJ55B", DateOnly.Parse("2025-12-05"), CategoriaLivro.Acao);

    }
}
