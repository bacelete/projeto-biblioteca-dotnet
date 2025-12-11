using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Entities;

namespace App.Domain.Services;

public class UsuarioService
{
    private readonly UsuarioRepository usuarioRepository;

    public UsuarioService()
    {
        usuarioRepository = new UsuarioRepository(); 
    }
}
