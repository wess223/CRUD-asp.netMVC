﻿using BDProjeto.aplicacao;
using BDProjeto.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApEF();
            var listaUsuario = appUsuario.ListarTodos();

            return View(listaUsuario);
        }
    }
}