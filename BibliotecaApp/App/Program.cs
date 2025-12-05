using App.Domain.Entities;
using App.Domain.Enums;

namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        Livro livro = new Livro
            (1, "Engenharia de Software Moderna", "Marco Túlio Valente", "CSJ45B", DateOnly.Parse("2025-12-05"), CategoriaLivro.Ciencia);

        Biblioteca.AdicionarLivro(livro);
        Biblioteca.ExibirInformacoesLivro(livro);
    }
}
