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
            livro.Status = StatusLivro.Emprestado.ToString();

            livroService.AtualizarLivro(idLivro, livro);
            usuarioService.RegistrarEmprestimo(usuario, emprestimo);
            emprestimoRepository.SalvarEmprestimo(emprestimo);
        }

        public List<Emprestimo> BuscarEmprestimosDoUsuario(Usuario usuario)
        {
            Usuario UsuarioEncontrado = usuarioService.BuscarUsuarioPeloEmail(usuario.Email);

            if (UsuarioEncontrado == null)
            {
                throw new NullReferenceException($"Usuário {usuario.Email} não esta acadastrado");
            }

            List<Emprestimo> EmprestimosUsuario = usuario.EmprestimosAtivos;

            if (EmprestimosUsuario == null)
            {
                throw new NullReferenceException("Usuario não possui emprestimos ativos");
            }
            return EmprestimosUsuario;
        }
    }
    }

