using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Services;

namespace App;
public class Program
{
    public static void Main(string[] args)
    {
        LivroService livroService = new LivroService();
        UsuarioService usuarioService = new UsuarioService();
        EmprestimoService emprestimoService = new EmprestimoService();

        Livro livro = new Livro("1", "Codigo Limpo", "Robert J. Bowler", "CSJ4BN", "2023-12-10", CategoriaLivro.Ciencia);
        Usuario usuario = new Usuario("1", "Admin", "admin@gmail.com");

        usuarioService.CadastrarUsuario(usuario);
        livroService.CadastrarLivro(livro); 
        emprestimoService.CadastrarEmprestimo("1", "admin@gmail.com");

    }
}
