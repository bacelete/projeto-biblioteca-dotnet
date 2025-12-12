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
        private readonly LivroService livroService = new LivroService();
        private readonly UsuarioService usuarioService = new UsuarioService();

        public EmprestimoService()
        {
            emprestimoRepository = new EmprestimoRepository();
        }

        public void CadastrarEmprestimo(string idLivro, string email)
        {
            Livro livro = livroService.BuscarLivroPeloId(idLivro);
            Usuario usuario = usuarioService.BuscarUsuarioPeloEmail(email);

            if (livro == null)
            {
                throw new NullReferenceException($"Livro de ID {idLivro} não está cadastrado no sistema"); 
            }
            if (usuario == null)
            {
                throw new NullReferenceException($"E-mail {email} não está cadastrado no sistema");
            }
            if (livro.Status != StatusLivro.Disponivel.ToString())
            {
                throw new ArgumentException($"Livro {livro.Titulo} não está disponível para emprestimo."); 
            }

            Emprestimo emprestimo = new Emprestimo(idLivro, usuario.Id, DateOnly.FromDateTime(DateTime.Now));
            usuarioService.RegistrarEmprestimo(usuario, emprestimo);
            emprestimoRepository.SalvarEmprestimo(emprestimo);
        }
    }
}
