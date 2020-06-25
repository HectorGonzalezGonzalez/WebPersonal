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
    public class EjemploDetallesController : Controller
    {
        BusEjemploDetalle busED;        
        public EjemploDetallesController()
        {
            busED = new BusEjemploDetalle();            
        }

        public PartialViewResult LstEjemploDetalleArbol(int EjemploId)
        {
            List<EjemploDetalle> Lst = new BusEjemploDetalle().Listar(EjemploId);
            return PartialView("_ArbolEjemploDetalle",Lst);
        }
        // GET: EjemploDetalles
        public PartialViewResult ListaEjemploDetalle(int idEjemplo,int id)
        {
            ViewData["Ejemplo_id"] = idEjemplo;
            ViewData["id"] = id;/*para saber que ejemplo detalle fue seleccionado*/
            Ejemplo ejemplo = new BusEjemplo().ListaById(idEjemplo);
            Subtema subtema = new BusSubtema().ListaById(ejemplo.SubtemaId);
            ViewData["NombreTema"] = new BusTema().nombreDelTema(subtema.TemaId);
            ViewData["nombreSubtema"] = new BusSubtema().NombreSubtema(ejemplo.SubtemaId);
            List<EjemploDetalle> Lst = busED.Listar(idEjemplo);
            return PartialView("_LstEjemploDetalle", Lst);
        }       

        // GET: EjemploDetalles/Create
        public PartialViewResult Create(int idEjemplo)
        {
            EjemploDetalle ejemploDetalle = new EjemploDetalle() {
                EjemploId = idEjemplo
            };
            
            return PartialView("_Create", ejemploDetalle);
        }

        [HttpPost]
        public JsonResult Create(EjemploDetalle ejemploDetalle)
        {
            string msj = "";
            if (ModelState.IsValid)
            {
                ejemploDetalle.UsrCreoId = User.Identity.GetUserId();
                ejemploDetalle = busED.save(ejemploDetalle);
                if (string.IsNullOrEmpty(busED.Error))
                {
                    msj = "OK";
                }
                else {
                    msj =busED.Error;
                }                
            }
            //List<EjemploDetalle> LstEjemploDet = new BusEjemploDetalle().Listar(ejemploDetalle.EjemploId);
            //ViewData["Ejemplo_id"] = ejemploDetalle.EjemploId;
            //ViewData["id"] = ejemploDetalle.Id;/*para saber que ejemplo detalle fue seleccionado*/
            //Ejemplo ejemplo = new BusEjemplo().ListaById(ejemploDetalle.EjemploId);
            //Subtema subtema = new BusSubtema().ListaById(ejemplo.SubtemaId);
            //ViewData["NombreTema"] = new BusTema().nombreDelTema(subtema.TemaId);
            //ViewData["nombreSubtema"] = new BusSubtema().NombreSubtema(ejemplo.SubtemaId);
            //return PartialView("_LstEjemploDetalle", LstEjemploDet);
            return Json(msj);
        }

        // GET: EjemploDetalles/Edit/5
        public PartialViewResult Editar(int? id)
        {            
            EjemploDetalle ejemploDetalle = busED.ListaById(id);                        
            return PartialView("_Edit",ejemploDetalle);
        }

        // POST: EjemploDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(EjemploDetalle ejemploDetalle)
        {
            string msj = "";
            if (ModelState.IsValid)
            {
                busED.update(ejemploDetalle);
                if (string.IsNullOrEmpty(busED.Error))
                {
                    msj = "OK";
                }
                else
                {
                    msj =busED.Error;
                }
            }
            //List<EjemploDetalle> LstEjemploDet = new BusEjemploDetalle().Listar(ejemploDetalle.EjemploId);
            //ViewData["Ejemplo_id"] = ejemploDetalle.EjemploId;
            //ViewData["id"] = ejemploDetalle.Id;/*para saber que ejemplo detalle fue seleccionado*/
            //Ejemplo ejemplo = new BusEjemplo().ListaById(ejemploDetalle.EjemploId);
            //Subtema subtema = new BusSubtema().ListaById(ejemplo.SubtemaId);
            //ViewData["NombreTema"] = new BusTema().nombreDelTema(subtema.TemaId);
            //ViewData["nombreSubtema"] = new BusSubtema().NombreSubtema(ejemplo.SubtemaId);
            //return PartialView("_LstEjemploDetalle", LstEjemploDet);
            return Json(msj);
        }

        // GET: EjemploDetalles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EjemploDetalle ejemploDetalle = busED.ListaById(id);
        //    if (ejemploDetalle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ejemploDetalle);
        //}

        // POST: EjemploDetalles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public PartialViewResult Delete(int id)
        {
            EjemploDetalle ejemploDetalle = busED.ListaById(id);
            busED.Delete(id);

            List<EjemploDetalle> LstEjemploDet = new BusEjemploDetalle().Listar(ejemploDetalle.EjemploId);
            ViewData["Ejemplo_id"] = ejemploDetalle.EjemploId;
            ViewData["id"] ="-1";/*para saber que ejemplo detalle fue seleccionado*/
            Ejemplo ejemplo = new BusEjemplo().ListaById(ejemploDetalle.EjemploId);
            Subtema subtema = new BusSubtema().ListaById(ejemplo.SubtemaId);
            ViewData["NombreTema"] = new BusTema().nombreDelTema(subtema.TemaId);
            ViewData["nombreSubtema"] = new BusSubtema().NombreSubtema(ejemplo.SubtemaId);
            return PartialView("_LstEjemploDetalle", LstEjemploDet);
        }

        protected override void Dispose(bool disposing)
        {            
            base.Dispose(disposing);
        }
    }
}
