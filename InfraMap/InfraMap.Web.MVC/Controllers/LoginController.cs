﻿using InfraMap.Web.MVC.Helpers;
using InfraMap.Web.MVC.Models;
using InfraMap.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfraMap.Dominio.Autenticacao;
using InfraMap.Dominio.Usuario;

namespace InfraMap.Web.MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var servicoAutenticacao = Factory.CriarServicoAutenticacao();

                var usuarioAutenticado = servicoAutenticacao.BuscarPorAutenticacao(loginModel.Login, loginModel.Senha);

                if (usuarioAutenticado != null)
                {
                    ControleDeSessao.CriarSessaoDeUsuario(usuarioAutenticado);
                    return RedirectToAction("Index", "Sede");
                }
            }

            ViewBag.Erro = "Usuário ou senha inválidos.";
            ModelState.AddModelError("INVALID_LOGIN", "Usuário ou senha inválidos.");
            return View("Index", loginModel);
        }

        public ActionResult Sair()
        {
            ControleDeSessao.Encerrar();
            return RedirectToAction("Index", "Login");
        }
    }
}