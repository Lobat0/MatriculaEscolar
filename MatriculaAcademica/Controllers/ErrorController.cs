using System.Web.Mvc;

namespace MatriculaAcademica.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult NotFound()
        {
            Response.StatusCode = 404;
            return View("NotFound");
        }
    }
}