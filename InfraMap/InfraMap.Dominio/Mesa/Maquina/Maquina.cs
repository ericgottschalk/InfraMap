﻿using System;
using InfraMap.Dominio.Comum;

namespace InfraMap.Dominio.Mesa.Maquina
{
    public class Maquina : EntidadeBase
    {
        public string Nome { get; set; }

        public string Tipo { get; set; }
    }
}
