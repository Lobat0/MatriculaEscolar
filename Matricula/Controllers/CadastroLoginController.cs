using System.Web.Mvc;
using Matricula.Models;

namespace Matricula.Controllers
{
    public class CadastroLoginController : Controller
    {

        private MatriculaEntities db = new MatriculaEntities();

        // GET: Página de Cadastro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Página de Cadastro com sucesso
        public ActionResult SucessoCadastro()
        {
            return View();
        }

        // GET: Página de Cadastro com erro
        public ActionResult ErroCadastro()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nome, string senha)
        {
            if (ModelState.IsValid)
            {
                Usuario newUsuario = new Usuario
                {
                    id_pessoa = 1,
                    nome = nome,
                    senha = senha,
                    permissoes = "sei la cara"
                };

                db.Usuario.Add(newUsuario);
                db.SaveChanges();
                return RedirectToAction("SucessoCadastro");
            }

            return RedirectToAction("ErroCadastro");
        }
    }
}
