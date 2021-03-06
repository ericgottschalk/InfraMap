﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraMap.Dominio.Mesa.Maquina;

namespace InfraMap.Infraestrutura.Ef.Mapeamento
{
    public class MapeamentoMaquina : MapeamentoEntidade<Maquina>
    {
        public MapeamentoMaquina()
        {
            Property(t => t.Nome).IsRequired().HasMaxLength(50);
            Property(t => t.Tipo).IsRequired().HasMaxLength(50);
        }
    }
}
