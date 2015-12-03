﻿using InfraMap.Dominio.ModuloUsuario;
using InfraMap.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public Usuario BuscarPorLogin(string login)
        {
            using (var db = new DataBaseContext())
            {
                return db.Usuario.Include("Permissoes").FirstOrDefault(p => p.Login == login);
            }
        }
    }
}