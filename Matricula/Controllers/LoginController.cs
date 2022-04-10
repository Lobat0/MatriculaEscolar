using Matricula.Models;
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
            ViewBag.Message = "Colé";

            return View();
        }
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Index(string nome, string senha)
        {
            var usuario = db.Usuario
                    .Where(u => u.nome == nome)
                    .FirstOrDefault();

            if (usuario != null)
            {
                if (usuario.senha == senha)
                {
                    return "logado";
                }
            }

            return "banido";
        }
    }
}