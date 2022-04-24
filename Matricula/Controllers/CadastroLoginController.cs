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
    public class CadastroLoginController : Controller
    {

        private MatriculaEntities db = new MatriculaEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: CadastroLogin

        // GET: CadastroLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "nome,senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pessoa = new SelectList(db.Pessoa, "id_pessoa", "nome", usuario.id_pessoa);
            return View(usuario);
        }

        // POST: CadastroLogin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CadastroLogin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastroLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CadastroLogin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
