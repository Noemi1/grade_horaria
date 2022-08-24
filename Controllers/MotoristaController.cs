using GradeHoraria_.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradeHoraria_.Controllers
{
    [Authorize]
    public class MotoristaController : Controller
    {
        private ModelDB db = new ModelDB();
        // GET: Motorista
        public ActionResult List()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(db.Motorista.OrderBy(x=>x.Nome).AsEnumerable());
        }

        public ActionResult Create()
        {
            Motorista motorista = new Motorista();
            return View(motorista);
        }

        // POST: Motorista/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Motorista model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var camposErros = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors}).ToList();
                    foreach(var campo in camposErros)
                    {
                        foreach(var erro in campo.Errors)
                        {
                            ModelState.AddModelError(campo.Key, erro.ErrorMessage);
                        }

                    }
                }
                var exists = db.Motorista.FirstOrDefault(x => x.CPF == model.CPF);
                if (exists != null)
                {

                    ModelState.AddModelError("CPF", "Esse CPF já está cadastrado");
                }

                exists = db.Motorista.FirstOrDefault(x => x.Email == model.Email);
                if (exists != null)
                {
                    ModelState.AddModelError("Email", "Esse E-mail já está cadastrado");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                db.Motorista.Add(model);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Registro cadastrado com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message.ToString());
                return View(model);
            }
        }

        // GET: Motorista/Edit/5
        public ActionResult Edit(int id)
        {
            var motorista = db.Motorista.Find(id);
            if (motorista == null)
            {
                return HttpNotFound();
            }
            return View(motorista);
        }

        // POST: Motorista/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Motorista model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var camposErros = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToList();
                    foreach (var campo in camposErros)
                    {
                        foreach (var erro in campo.Errors)
                        {
                            ModelState.AddModelError(campo.Key, erro.ErrorMessage);
                        }

                    }
                }

                var motorista = db.Motorista.FirstOrDefault(x => x.Id == id);
                if (motorista == null)
                {
                    ModelState.AddModelError("", "Registro não encontrado!!");
                }

                var exists = db.Motorista.FirstOrDefault(x => x.CPF == model.CPF && x.Id != model.Id);
                if (exists != null)
                {

                    ModelState.AddModelError("CPF", "Esse CPF já está cadastrado para outro motorista!!");
                }

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Registro atualizado com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message.ToString());
                return View(model);
            }
        }

        // GET: Motorista/Delete/5
        public ActionResult Delete(int id)
        {
            var motorista = db.Motorista.Find(id);
            return View(motorista);
        }

        // POST: Motorista/Delete/5
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var motorista = db.Motorista.FirstOrDefault(x => x.Id == id);
                if (motorista == null)
                {
                    ModelState.AddModelError("", "Registro não encontrado!!");
                }

                if (!ModelState.IsValid)
                {
                    return View(motorista);
                }

                db.Motorista.Remove(motorista);
                db.SaveChanges();


                TempData["SuccessMessage"] = "Registro excluido com sucesso!";
                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message.ToString());
                return View(new Motorista { Id = 0, Nome = "", CPF = 0, Email = "", Telefone = 0 });
            }
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {   
                ModelState.AddModelError("", error);
            }
        }
    }
}
