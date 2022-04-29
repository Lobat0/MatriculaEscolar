using Matricula.Models;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Matricula.Controllers
{
    public class LoginController : Controller
    {
        private readonly MatriculaEntities db = new MatriculaEntities();

        // GET Login
        public ActionResult Index()
        {
            ViewBag.Message = "ahh";

            return View();
        }
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Index(string nome, string senha)
        {
            try
            {
                var usuario = db.Usuario.Where(u => u.nome == nome).FirstOrDefault();

                if (usuario != null)
                {
                    if (usuario.senha == senha)
                    {
                        Session["nome"] = usuario.nome;
                        Session["perfil"] = usuario.permissoes;
                        return "sucesso duzentos e tantos: logado";
                    }
                }
            }
            catch (Exception e)
            {
                return "erro quinhentos e alguma coisa: banido";
            }

            return "erro quatrocentos e tals: banido";
        }
    }
}