using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Controllers
{
    public class ProfessoresDisciplinasController : Controller
    {
        private readonly MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: ProfessoresDisciplinas
        public ActionResult Index()
        {
            ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
            ViewBag.id_professor = new MultiSelectList(db.Professor, "id_professor", "CPF", "nome_professor");

            if (Session["tipo"] != null)
            {
                var professorDisciplina = db.ProfessorDisciplina.Include(p => p.Disciplina).Include(p => p.Professor);
                return View(professorDisciplina.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: ID da disciplina não encontrado.";
                    return RedirectToAction("Index", "Professores");
                }
                ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
                if (professorDisciplina == null)
                {
                    Session["errodb.Msg"] = "Erro: Disciplina não encontrada.";
                    return RedirectToAction("Index", "Professores");
                }
                return View(professorDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");
                ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {

                    var condicao = db.ProfessorDisciplina.Where(u => u.id_disciplina == professorDisciplina.id_disciplina && u.id_professor == professorDisciplina.id_professor).FirstOrDefault();
                    if (condicao != null)
                    {
                        //variavel do erro de cadastro duplicado
                        Session["errodb.Msg"] = "Erro: Cadastro com itens duplicados";
                        return RedirectToAction("Disciplinas", new { id = professorDisciplina.id_professor });
                    }
                    else
                    {
                        try
                        {
                            db.ProfessorDisciplina.Add(professorDisciplina);
                            db.SaveChanges();
                            Session["susdb.Msg"] = "Sucesso: Cadastro efetuado";
                            return RedirectToAction("Disciplinas", new { id = professorDisciplina.id_professor });
                        }
                        catch (Exception e)
                        {
                            Session["errodb.Msg"] = e.Message;
                            return RedirectToAction("Index", "Professores");
                        }
                    }
                }

                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
                ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
                return View(professorDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
                if (professorDisciplina == null)
                {
                    return HttpNotFound();
                }
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
                ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
                return View(professorDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_professor_disciplina,id_professor,id_disciplina")] ProfessorDisciplina professorDisciplina)
        {
            if (Session["tipo"] != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        db.Entry(professorDisciplina).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["susdb.Msg"] = "Sucesso: Edição efetuada";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        Session["errodb.Msg"] = e.Message;
                        Console.WriteLine(e);
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina", professorDisciplina.id_disciplina);
                ViewBag.id_professor = new SelectList(db.Professor, "id_professor", "nome_professor", professorDisciplina.id_professor);
                return View(professorDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Disciplinas/5
        public ActionResult Disciplinas(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: Professor/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Professores");
                }
                Professor professor = db.Professor.Find(id);
                if (professor == null)
                {
                    Session["errodb.Msg"] = "Erro: Professor/Disciplinas não encontrados";
                    return RedirectToAction("Index", "Professores");
                }
                IEnumerable<Disciplina> disciplinas = professor.ProfessorDisciplina.Select(pd => pd.Disciplina);
                ViewBag.disciplinas = disciplinas;
                ViewBag.professor = professor;

                ViewBag.id_professor = new MultiSelectList(db.Professor, "id_professor", "nome_professor", "CPF");
                ViewBag.id_disciplina = new SelectList(db.Disciplina, "id_disciplina", "nome_disciplina");

                return View(disciplinas);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProfessoresDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                if (id == null)
                {
                    Session["errodb.Msg"] = "Erro: ID da disciplina não encontrado.";
                    return RedirectToAction("Index", "Professores");
                }
                ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
                if (professorDisciplina == null)
                {
                    Session["errodb.Msg"] = "Erro: Disciplina não encontrada.";
                    return RedirectToAction("Index", "Professores");
                }
                return View(professorDisciplina);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: ProfessoresDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Find(id);
                db.ProfessorDisciplina.Remove(professorDisciplina);
                db.SaveChanges();
                Session["susdb.Msg"] = "Sucesso: item excluido";
                return RedirectToAction("Disciplinas", new { id = professorDisciplina.id_professor });
            }
            catch (Exception e)
            {
                Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                Console.WriteLine(e);
                return RedirectToAction("Disciplinas", new { id = id });
            }
        }

        // POST: ProfessorDisciplinas/DeleteSemId/5
        [HttpPost, ActionName("DeleteSemId")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSemId(int id_professor, int id_disciplina)
        {
            if (Session["tipo"] != null)
            {
                try
                {
                    ProfessorDisciplina professorDisciplina = db.ProfessorDisciplina.Where(pd => pd.id_professor == id_professor && pd.id_disciplina == id_disciplina).FirstOrDefault();
                    db.ProfessorDisciplina.Remove(professorDisciplina);
                    db.SaveChanges();
                    Session["susdb.Msg"] = "Sucesso: item excluido";
                    return RedirectToAction("Disciplinas", new { id = professorDisciplina.id_professor });
                }
                catch (Exception e)
                {
                    Session["errodb.Msg"] = "Erro: Item com referências não pode ser deletado";
                    Console.WriteLine(e);
                    return RedirectToAction("Disciplinas", new { id = id_professor });
                }
            }
            return RedirectToAction("Index", "Home");
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
