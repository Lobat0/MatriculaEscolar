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
    public class UsuariosController : Controller
    {
        private MatriculaAcademicadbEntities1 db = new MatriculaAcademicadbEntities1();

        // GET: Usuarios
        public ActionResult Index()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    return View(db.Usuario.ToList());
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Usuario usuario = db.Usuario.Find(id);
                    if (usuario == null)
                    {
                        return HttpNotFound();
                    }
                    return View(usuario);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_usuario,login,email,senha,tipo")] Usuario usuario)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (ModelState.IsValid)
                    {
                        db.Usuario.Add(usuario);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(usuario);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Usuario usuario = db.Usuario.Find(id);
                    if (usuario == null)
                    {
                        return HttpNotFound();
                    }
                    return View(usuario);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_usuario,login,email,senha,tipo")] Usuario usuario)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (ModelState.IsValid)
                    {
                        db.Entry(usuario).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    return View(usuario);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Usuario usuario = db.Usuario.Find(id);
                    if (usuario == null)
                    {
                        return HttpNotFound();
                    }
                    return View(usuario);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["tipo"] != null)
            {
                string permissao = (Session["tipo"] as string).Trim();
                if (string.Equals(permissao, "admin"))
                {
                    Usuario usuario = db.Usuario.Find(id);
                    db.Usuario.Remove(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
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
