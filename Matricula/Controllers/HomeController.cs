using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Matricula.Models;

namespace Matricula.Controllers
{
    public class HomeController : Controller
    {
        private MatriculaEntities db = new MatriculaEntities();

        public ActionResult Index()
        {
            return View();
        }

        // GET Home/Login
        public ActionResult Login()
        {
            ViewBag.Message = "Colé";

            return View();
        }
        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Login(string nome, string senha)
        {
            var usuario = db.Usuario
                    .Where(u => u.nome == nome)
                    .FirstOrDefault();

            if (usuario.senha == senha)
            {
                return "logado";
            }

            return "banido";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}