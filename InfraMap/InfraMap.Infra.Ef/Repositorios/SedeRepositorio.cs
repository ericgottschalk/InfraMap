﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Comum;
using InfraMap.Dominio.Sede;

namespace InfraMap.Infraestrutura.Ef.Repositorios
{
    public class SedeRepositorio : RepositorioBase<Sede>, ISedeRepositorio
    {
        public List<Sede> BuscarTodasAsSedes()
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.ToList();
            }
        }

        public List<Sede> BuscarSedesComAndares()
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.Include("Andares.Mesas").ToList();
            }
        }

        public Sede BuscarSedePorNome(string nome)
        {
            using (var db = new DataBaseContext())
            {
                return db.Sede.Include("Andares.Mesas.Colaborador")
                    .Include("Andares.Mesas.Maquina")
                    .Include("Andares.Mesas.Ramal")
                    .FirstOrDefault(t => t.Nome.Equals(nome));
            }
        }
    }
}
