using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bruno___SENAC.Models;
using Microsoft.AspNetCore.Http;

namespace Bruno___SENAC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Tarefas()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
          public IActionResult Login(Usuario user)
        {   
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.Login(user); 
            
            if(usuario != null){

            HttpContext.Session.SetInt32("id", usuario.id);
            HttpContext.Session.SetString("login", usuario.login);
            HttpContext.Session.SetString("senha", usuario.senha);

            ViewBag.Sucesso = "Login realizado com sucesso!";

            }

            else{
                ViewBag.Sucesso = "Falha no acesso";
            }

            return View();
        }

       

    }
}
