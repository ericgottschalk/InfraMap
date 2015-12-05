﻿using InfraMap.Dominio.ModuloMaquina;
using InfraMap.Web.MVC.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfraMap.Web.MVC.Controllers
{
    public class MapaController : Controller
    {
        public void AdicionarColaborador(int idMesa, string loginColaborador)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var usuarioRepositorio = FabricaDeModulos.CriarUsuarioRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Colaborador = usuarioRepositorio.BuscarPorLogin(loginColaborador);
            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarMaquina(int idMesa, int idMaquina)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var maquinaRepositorio = FabricaDeModulos.CriarMaquinaRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Maquina = maquinaRepositorio.BuscarPorId(idMaquina);
            mesaRepositorio.Atualizar(mesa);
        }

        public void AdicionarRamal(int idMesa, int idRamal)
        {
            var mesaRepositorio = FabricaDeModulos.CriarMesaRepositorio();
            var ramalRepositorio = FabricaDeModulos.CriarRamalRepositorio();

            var mesa = mesaRepositorio.BuscarPorId(idMesa);
            mesa.Ramal = ramalRepositorio.BuscarPorId(idRamal);
            mesaRepositorio.Atualizar(mesa);
        }

        private IList<Maquina> BuscarMaquinaPeloFiltro(String term)
        {
            IMaquinaRepositorio maquina = FabricaDeModulos.CriarMaquinaRepositorio();
            if (String.IsNullOrEmpty(term))
            {
                return maquina.Buscar();
            }
            else
            {
                return maquina.BuscarPorNome(term);
            }
        }

        public JsonResult MaquinaAutoComplete(string term)
        {
            IList<Maquina> maquinaEncontrada = BuscarMaquinaPeloFiltro(term);
            var json = maquinaEncontrada.Select(maquinas => new { label = maquinas.Nome });
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}