﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Usuario;
using InfraMap.Dominio.Usuario.Queries;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public Usuario BuscarPorLogin(string login)
        {
            using (var db = new DataBaseContext())
            {
                return db.Usuario.Include("Permissoes").FirstOrDefault(p => p.Login == login);
            }
        }

        public IList<Usuario> BuscarListaPorNome(string nome)
        {
            return this.Buscar(new BuscarUsuariosPorNomeQuery(nome));
        }


        public Usuario BuscarPorNome(string nome)
        {
            return this.Buscar(new BuscarUsuariosPorNomeQuery(nome)).FirstOrDefault();
        }


        public IList<Usuario> BuscarUsuariosPorLogin(string login)
        {
            return this.Buscar(new BuscarUsuariosPorLoginQuery(login));
        }
    }
}
