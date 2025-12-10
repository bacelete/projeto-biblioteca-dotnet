using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Services;

namespace App.Domain.Services
{
    public static class LivroService
    {
        public static void CriarLivro(Livro livro)
        {
            BibliotecaService.AdicionarLivro(livro); 
        }

        public static void DeletarLivro(int id)
        {
            Livro livro = BuscarLivroPeloId(id);
            BibliotecaService.DeletarLivro(livro); 
        }

        public static Livro BuscarLivroPeloId(int id)
        {
            Livro livro = BibliotecaService.BuscarLivro(id);

            if (livro == null)
            {
                throw new NullReferenceException("Livro não encontrado!"); 
            }

            return livro; 
        }

        public static void AtualizarLivro(int id, Livro novo)
        {
            Livro livro = BuscarLivroPeloId(id);
            BibliotecaService.AtualizarLivro(livro, novo);
        }

        public static List<Livro> BuscarTodosOsLivros()
        {
            return BibliotecaService.BuscarTodosOsLivros(); 
        }

        public static void ExibirInformacoesLivro(Livro livro)
        {
            BibliotecaService.ExibirInformacoesLivro(livro);
        }


    }
}
