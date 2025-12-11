using App.Domain.Entities;
using App.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Repository
{
    public class UsuarioRepository
    {
        private readonly RepositoryJSON<Usuario> repUsuario; 

        public UsuarioRepository()
        {
            repUsuario = new RepositoryJSON<Usuario>("usuarios.json"); 
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            repUsuario.SalvarDados(usuario);
        }

        public Usuario BuscarUsuario(string id)
        {
            return repUsuario.Carregar(id);
        }

    }
}
