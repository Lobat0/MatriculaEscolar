using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class CursosController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Cursos
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                return View(db.Curso.ToList());

            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {

            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Curso curso = db.Curso.Find(id);
                if (curso == null)
                {
                    return HttpNotFound();
                }
            return View(curso);
            }
            return RedirectToAction("Index", "Home");

        }

        // GET: Cursos/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: Cursos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso,nome_curso,duracao,turno")] Curso curso)
        {
            if (ModelState.IsValid)
            {

                var condicao = db.Curso.Where(u => u.nome_curso == curso.nome_curso && u.turno == curso.turno).FirstOrDefault();
                if (condicao != null)
                {
                    //variavel do erro de cadastro duplicado
                    Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                    return RedirectToAction("Index");
                }
                else
                {
                    try
                    {
                        db.Curso.Add(curso);
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Cadastro efetuado";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = e.Message;
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_curso,nome_curso,duracao,turno")] Curso curso)
        {
            if (ModelState.IsValid)
            {

                var condicao = db.Curso.Where(u => u.nome_curso == curso.nome_curso && u.turno == curso.turno).FirstOrDefault();
                if (condicao != null)
                {
                    //variavel do erro de cadastro duplicado
                    Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                    return RedirectToAction("Index");
                }
                else
                {
                    try
                    {
                        db.Entry(curso).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Cadastro efetuado";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = e.Message;
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Curso.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Curso curso = db.Curso.Find(id);
                db.Curso.Remove(curso);
                db.SaveChanges();
                Session["susdb.Msg"] = "Sucesso: item excluido";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                Console.WriteLine(e);
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
