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

    public Usuario BuscarUsuarioPeloId(string id)
    {
        Usuario usuario = usuarioRepository.BuscarUsuario(id);
        if (usuario == null)
        {
            throw new NullReferenceException($"Usuario {id} não está cadastrado no sistema."); 
        }
        return usuario; 
    }

    public void RegistrarEmprestimo(string id, Emprestimo emprestimo)
    {
        Usuario usuario = BuscarUsuarioPeloId(id); 
        usuario.EmprestimosAtivos.Add(emprestimo);
    }
}
