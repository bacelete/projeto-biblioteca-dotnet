using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities;

namespace App.Domain.Services;

public class UsuarioService
{
    public static void CriarUsuario(Usuario usuario)
    {
        if (isUserAlreadyCreated(usuario.Email))
        {
            throw new ArgumentException("Já existe um usuário cadastrado com esse e-mail!"); 
        }
        Biblioteca.UsuarioList.Add(usuario); 
    }

    public static bool isUserAlreadyCreated(string email)
    {
        List<Usuario> usuarios = BuscarTodosOsUsuarios(); 

        foreach(Usuario usuario in usuarios)
        {
            if (usuario.Email == email)
            {
                return true; 
            }
        }
        return false;
    }

    public static List<Usuario> BuscarTodosOsUsuarios()
    {
        return Biblioteca.UsuarioList;
    }
}
