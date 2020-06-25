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
using WebPersonal.METODOS;

namespace WebPersonal.Controllers
{
    public class TemasController : Controller
    {
        BusTema bus;
        BusCategoria busCat;
        public TemasController()
        {
            bus = new BusTema();
        }

        // GET: Temas
        public ActionResult Index()
        {
            if (Session["_error"] == null)
            {
                Session["_error"] = "";
            }
            if (Session["_toast"] == null)
            {
                Session["_toast"] = "";
            }
            ViewData["titulo_modal"] = "Administración de Temas";
            return View(bus.LstTemas());
        }

        // GET: Temas/Details/5
        

        // GET: Temas/Create
        public ActionResult Create()
        {
            busCat = new BusCategoria();
            
            ViewBag.CategoriaId = new SelectList(busCat.Listar(), "Id", "Nombre");
            return View();
        }

        // POST: Temas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,CategoriaId,Nombre")] Tema tema)
        {
            /*Se hace antes de la validacion para que no lo vuelva a pedir si ya se selecciono la imagen*/
            //tema.ImgFile = ImgFile;
            if (ModelState.IsValid)
            {
                tema.UsrCreoId= User.Identity.GetUserId();
                tema.Status =true;
                tema=bus.save(tema);                
                if (string.IsNullOrEmpty(bus.Error))
                {
                    Session["_toast"] = "Datos Guardados correctamente";
                }
                Session["_error"] = bus.Error;
                return RedirectToAction("Index");
            }
            busCat = new BusCategoria();
            ViewBag.CategoriaId = new SelectList(busCat.Listar(), "Id", "Nombre", tema.CategoriaId);
            return View(tema);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = bus.ListaById(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            busCat = new BusCategoria();
            ViewBag.CategoriaId = new SelectList(busCat.Listar(), "Id", "Nombre", tema.CategoriaId);
            return View(tema);
        }

        // POST: Temas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,CategoriaId,Nombre,Fecha_creo,UsrCreoId")] Tema tema)
        {
            if (ModelState.IsValid)
            {             
                tema.UsrCreoId = User.Identity.GetUserId();
                bus.update(tema);
                Session["_toast"] = "Datos actualizados correctamente";
                return RedirectToAction("Index");
            }
            busCat = new BusCategoria();
            ViewBag.CategoriaId = new SelectList(busCat.Listar(), "Id", "Nombre", tema.CategoriaId);
            return View(tema);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = bus.ListaById(id);
           
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bus.Delete(id);
            Session["_toast"] = "Datos eliminados correctamente";
            return RedirectToAction("Index");
        }

       
    }
}
