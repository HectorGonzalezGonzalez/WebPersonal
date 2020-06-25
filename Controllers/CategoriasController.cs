using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bussines;
using DATA;
using Microsoft.AspNet.Identity;
using Models;

namespace WebPersonal.Controllers
{
    public class CategoriasController : Controller
    {        
        BusCategoria busTC;
        public CategoriasController()
        {
            busTC = new BusCategoria();            
        }

        // GET: Categorias
        public ActionResult Index()
        {
            if (Session["_error"]==null)
            {
                Session["_error"] = "";
            }
            if (Session["_toast"] == null)
            {
                Session["_toast"] = "";
            }
            ViewData["titulo_modal"] = "Administración de categorías";
            return View(busTC.Listar());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria Categoria = busTC.ListaById(id);
            if (Categoria == null)
            {
                return HttpNotFound();
            }
            return View(Categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            //Session["error"] ="";
            return View();
        }

        // POST: Categorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria Categoria)
        {
            if (ModelState.IsValid)
            {
                Categoria.UsrCreoId = User.Identity.GetUserId();
                busTC.save(Categoria);
                if (string.IsNullOrEmpty(busTC.Error))
                {
                    Session["_toast"] = "Datos Guardados correctamente";                    
                }
                Session["_error"] = busTC.Error;                
            }
            return RedirectToAction("Index");
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria Categoria = busTC.ListaById(id);
            if (Categoria == null)
            {
                return HttpNotFound();
            }
            return View(Categoria);
        }

        // POST: Categorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,Nombre,Fecha_creo,Usr_creo")] Categoria Categoria)
        {
            if (ModelState.IsValid)
            {
                busTC.update(Categoria);
                Session["_toast"] = "Datos actualizados correctamente";
                return RedirectToAction("Index");
            }
            return View(Categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria Categoria = busTC.ListaById(id);
            if (Categoria == null)
            {
                return HttpNotFound();
            }
            return View(Categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            busTC.Delete(id);
            Session["_toast"] = "Datos eliminados correctamente";
            return RedirectToAction("Index");
        }
    }
}
