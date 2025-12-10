using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Services;

namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        LivroService.AdicionarLivro(
            1, "Engenharia de Software Moderna", "Marco Túlio Valente", "CSJ45B", DateOnly.Parse("2025-12-05"), CategoriaLivro.Ciencia);
    }
}
