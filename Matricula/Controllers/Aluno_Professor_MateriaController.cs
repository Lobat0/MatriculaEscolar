using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Matricula.Models;

namespace Matricula.Controllers
{
    public class Aluno_Professor_MateriaController : Controller
    {
        private MatriculaEntities db = new MatriculaEntities();

        // GET: Aluno_Professor_Materia
        public ActionResult Index()
        {
            var aluno_Professor_Materia = db.Aluno_Professor_Materia.Include(a => a.Aluno).Include(a => a.Professor_Materia);
            return View(aluno_Professor_Materia.ToList());
        }

        // GET: Aluno_Professor_Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Professor_Materia aluno_Professor_Materia = db.Aluno_Professor_Materia.Find(id);
            if (aluno_Professor_Materia == null)
            {
                return HttpNotFound();
            }
            return View(aluno_Professor_Materia);
        }

        // GET: Aluno_Professor_Materia/Create
        public ActionResult Create()
        {
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "situacao");
            ViewBag.id_professor_materia = new SelectList(db.Professor_Materia, "id_professor_materia", "id_professor_materia");
            return View();
        }

        // POST: Aluno_Professor_Materia/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_aluno_prof_mat,id_aluno,id_professor_materia,nota,data_matricula,frequencia,atestado")] Aluno_Professor_Materia aluno_Professor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Aluno_Professor_Materia.Add(aluno_Professor_Materia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "situacao", aluno_Professor_Materia.id_aluno);
            ViewBag.id_professor_materia = new SelectList(db.Professor_Materia, "id_professor_materia", "id_professor_materia", aluno_Professor_Materia.id_professor_materia);
            return View(aluno_Professor_Materia);
        }

        // GET: Aluno_Professor_Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Professor_Materia aluno_Professor_Materia = db.Aluno_Professor_Materia.Find(id);
            if (aluno_Professor_Materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "situacao", aluno_Professor_Materia.id_aluno);
            ViewBag.id_professor_materia = new SelectList(db.Professor_Materia, "id_professor_materia", "id_professor_materia", aluno_Professor_Materia.id_professor_materia);
            return View(aluno_Professor_Materia);
        }

        // POST: Aluno_Professor_Materia/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_aluno_prof_mat,id_aluno,id_professor_materia,nota,data_matricula,frequencia,atestado")] Aluno_Professor_Materia aluno_Professor_Materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno_Professor_Materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_aluno = new SelectList(db.Aluno, "id_aluno", "situacao", aluno_Professor_Materia.id_aluno);
            ViewBag.id_professor_materia = new SelectList(db.Professor_Materia, "id_professor_materia", "id_professor_materia", aluno_Professor_Materia.id_professor_materia);
            return View(aluno_Professor_Materia);
        }

        // GET: Aluno_Professor_Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno_Professor_Materia aluno_Professor_Materia = db.Aluno_Professor_Materia.Find(id);
            if (aluno_Professor_Materia == null)
            {
                return HttpNotFound();
            }
            return View(aluno_Professor_Materia);
        }

        // POST: Aluno_Professor_Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno_Professor_Materia aluno_Professor_Materia = db.Aluno_Professor_Materia.Find(id);
            db.Aluno_Professor_Materia.Remove(aluno_Professor_Materia);
            db.SaveChanges();
            return RedirectToAction("Index");
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
