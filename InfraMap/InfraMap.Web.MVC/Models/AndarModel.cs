﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraMap.Web.MVC.Models
{
    public class AndarModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public List<MesaModel> Mesas { get; set; }
    }
}
