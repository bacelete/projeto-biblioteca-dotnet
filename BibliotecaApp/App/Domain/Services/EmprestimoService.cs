using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Services
{
    public class EmprestimoService
    {
        private readonly EmprestimoRepository emprestimoRepository;
        private readonly LivroService livroService;
        private readonly UsuarioService usuarioService;

        public EmprestimoService()
        {
            emprestimoRepository = new EmprestimoRepository();
            livroService = new LivroService();
            usuarioService = new UsuarioService(); 
        }

        public void CadastrarEmprestimo(string idLivro, string idUsuario)
        {
            Livro livro = livroService.BuscarLivroPeloId(idLivro);
            Usuario usuario = usuarioService.BuscarUsuarioPeloId(idUsuario); 
            if (livro == null)
            {
                throw new NullReferenceException($"Livro de ID {idLivro} não está cadastrado no sistema"); 
            }
            if (usuario == null)
            {
                throw new NullReferenceException($"Usuario de ID {idUsuario} não está cadastrado no sistema");
            }
            if (livro.Status != StatusLivro.Disponivel.ToString())
            {
                throw new ArgumentException($"Livro {livro.Titulo} não está disponível para emprestimo."); 
            }

            Emprestimo emprestimo = new Emprestimo(idLivro, idUsuario, DateOnly.FromDateTime(DateTime.Now));
            usuarioService.RegistrarEmprestimo(idUsuario, emprestimo);
            emprestimoRepository.SalvarEmprestimo(emprestimo);
        }
    }
}
