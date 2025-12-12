using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities;
using App.Domain.Repository;

namespace App.Domain.Services;

public class UsuarioService
{
    private readonly UsuarioRepository usuarioRepository;

    public UsuarioService()
    {
        usuarioRepository = new UsuarioRepository(); 
    }

    public void CadastrarUsuario(Usuario usuario)
    {
        usuarioRepository.CadastrarUsuario(usuario);
    }

    public Usuario BuscarUsuarioPeloEmail(string email)
    {
        Usuario usuario = usuarioRepository.BuscarUsuario(email);
        if (usuario == null)
        {
            throw new NullReferenceException($"Usuario {email} não está cadastrado no sistema."); 
        }
        return usuario; 
    }

    public void RegistrarEmprestimo(Usuario usuario, Emprestimo emprestimo)
    {
        usuario.EmprestimosAtivos.Add(emprestimo);
    }
}
