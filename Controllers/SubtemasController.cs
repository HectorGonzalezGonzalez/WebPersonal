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
    public class SubtemasController : Controller
    {

        BusSubtema bus;
        BusTema busTema;
        public SubtemasController()
        {
            bus = new BusSubtema();
        }
        // GET: Subtemas
        public ActionResult Index(int idTema)
        {            
            busTema = new BusTema();
            ViewData["NombreTema"] = busTema.nombreDelTema(idTema);
            ViewData["titulo_modal"] = "Administración de Subtema";
            ViewData["idTema"] = idTema;            
            return View(bus.LstSubtemas(idTema));
        }
        public PartialViewResult recargarArbolPrincipal(int temaId)
        {
            List<Subtema> LstArbol = bus.LstSubtemas(temaId);
            return PartialView("_LstArbol", LstArbol);
        }

            // GET: Subtemas/Create
            public PartialViewResult Create(int idTema)
        {           
            //busTema = new BusTema();
            //ViewData["NombreTema"]=busTema.nombreDelTema(idTema);

            Subtema subtema = new Subtema() { 
            TemaId=idTema
            };            
            return PartialView("_Create",subtema);
        }

        // POST: Subtemas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(Subtema subtema)
        {
            string msj = "";
            if (ModelState.IsValid)
            {
                subtema.UsrCreoId = User.Identity.GetUserId();
                subtema.Status = true;
                subtema = bus.save(subtema);
                if (string.IsNullOrEmpty(bus.Error) == false)
                {                    
                    msj = bus.Error;
                }
                else
                {
                    msj = "OK";
                }              
            }
            return Json(msj);          
        }


        // GET: Subtemas/Edit/5
        public PartialViewResult Edit(int? id)
        {            
            Subtema subtema = bus.ListaById(id);            
            //busTema = new BusTema();
            //ViewData["NombreTema"] = busTema.nombreDelTema(subtema.TemaId);
            return PartialView("_Edit",subtema);
        }

        // POST: Subtemas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(Subtema subtema)
        {
            string msj = "";
            if (ModelState.IsValid)
            {
                bus.update(subtema);
                if (string.IsNullOrEmpty(bus.Error))
                {
                    msj="OK";
                }
                else
                {
                    msj = "";
                }
            }            
            return Json(msj);
        }

        // GET: Subtemas/Delete/5
        public PartialViewResult Delete(int? id)
        {            
            Subtema subtema = bus.ListaById(id);
            
            //busTema = new BusTema();
            //ViewData["NombreTema"] = busTema.nombreDelTema(subtema.TemaId);
            return PartialView("_Delete",subtema);
        }

        // POST: Subtemas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public PartialViewResult DeleteConfirmed(int id)
        {
            Subtema subtema = bus.ListaById(id);
            bus.Delete(id);
            List<Subtema> LstArbol = bus.LstSubtemas(subtema.TemaId);
            return PartialView("_LstArbol", LstArbol);
        }
     
    }
}
