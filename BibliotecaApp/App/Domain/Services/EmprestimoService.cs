using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        private Emprestimo BuscarEmprestimoPeloIdLivro(string idLivro)
        {
            List<Emprestimo> emprestimos = emprestimoRepository.BuscarTodos();
            Emprestimo emprestimo = new Emprestimo(); 

            emprestimos.ForEach(emp =>
            {
                if (emp.IdLivro == idLivro)
                {
                    emprestimo = emp;  
                }
            });

            return emprestimo;
        }

        public Emprestimo BuscarEmprestimo(string idEmprestimo)
        {
            Emprestimo emprestimo = emprestimoRepository.BuscarEmprestimo(idEmprestimo);
            if (emprestimo == null)
            {
                throw new NullReferenceException($"Emprestimo de ID {idEmprestimo} não encontrado."); 
            }
            return emprestimo; 
        }

        public void AtualizarEmprestimo(String idEmprestimo, Emprestimo novo)
        {
            emprestimoRepository.AtualizarEmprestimo(idEmprestimo, novo);
        }

        public void DevolverLivro(string idLivro)
        {
            Livro livro = livroService.BuscarLivroPeloId(idLivro); 

            if (livro == null)
            {
                throw new NullReferenceException($"Livro {livro.Titulo} não está cadastrado.");
            }

            Emprestimo emprestimo = BuscarEmprestimoPeloIdLivro(idLivro);

            if (emprestimo == null)
            {
                throw new NullReferenceException($"Não ha emprestimo associado ao livro {livro.Titulo}");
            }

            Usuario usuario = usuarioService.BuscarUsuarioPeloId(emprestimo.IdUsuario); 

            usuario.EmprestimosAtivos.Remove(emprestimo);
            emprestimo.DataDevolucao = DateOnly.FromDateTime(DateTime.UtcNow);

            livro.Status = StatusLivro.Disponivel.ToString();
            livroService.AtualizarLivro(livro.Id, livro);
        }
    }
    }

