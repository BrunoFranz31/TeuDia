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





                /*TAREFAS*/
            public IActionResult Tarefas(){  
            
            UsuarioRepository ur = new UsuarioRepository();
            List<Tarefas> compromisso = ur.Listar_Tarefas();
            return View(compromisso);}

        /*LISTAGEM DE TAREFAS*/
         public IActionResult Listar_Tarefas(){
          
          UsuarioRepository ur = new UsuarioRepository();
          
          List<Tarefas> listagem = ur.Listar_Tarefas();
          
          return View(listagem);}


        /*EXCLUSÃO DE PACOTES*/
        [HttpGet]
        public IActionResult Excluir_Tarefas(int id_tarefa){

            UsuarioRepository ur = new UsuarioRepository();

            ur.Excluir_T(id_tarefa);
            
            return RedirectToAction("Agendando");
        }

        [HttpGet]
        public IActionResult Excluir_Compromisso(int id_tarefa){

            UsuarioRepository ur = new UsuarioRepository();

            ur.Excluir_T(id_tarefa);
            
            return RedirectToAction("Listar_Tarefas");
        }

    // LOGIN

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
          public IActionResult Login(Usuario user){   
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.Login(user); 
            
            if(usuario != null){

            HttpContext.Session.SetInt32("id", usuario.id);
            HttpContext.Session.SetString("login", usuario.login);
            HttpContext.Session.SetString("senha", usuario.senha);

            ViewBag.Sucesso = "Login realizado com sucesso!";
            
            return View("Views/Home/Agendando.cshtml");}

            else{
                ViewBag.Sucesso = "Falha no acesso";}

            return View();}



        [HttpPost]  
         public IActionResult Agendando(Tarefas compromisso){   
            UsuarioRepository ur = new UsuarioRepository();
            ur.Insert_Tarefas(compromisso);
            ViewBag.Cadastro = "Compromisso agendado com sucesso!";

            return View();}



    }
}
