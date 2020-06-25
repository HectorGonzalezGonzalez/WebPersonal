using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class EjemploesController : Controller
    {
        BusEjemplo busEjemplo;
        BusSubtema busSubtema;
        BusTema busTema;
        //BusEjemploDetalle busEjemDet;
        public EjemploesController()
        {
            busEjemplo = new BusEjemplo();
            busSubtema = new BusSubtema();
            busTema = new BusTema();
        }
        [HttpGet]
        public PartialViewResult ArbolEjemplo(int subtemaId)
        {
            List<Ejemplo>Lst=busEjemplo.LstEjemploJoinDetalle(subtemaId);
            ViewData["subtemaId"] = subtemaId;
            return PartialView("_ArbolEjemplo", Lst);
        }
        public PartialViewResult Create(int idSubtema)
        {
            Subtema subtema = busSubtema.ListaById(idSubtema);
            //ViewData["NombreTema"] = busTema.nombreDelTema(subtema.TemaId);

            ViewData["nombreSubtema"] = busSubtema.NombreSubtema(idSubtema);
            Ejemplo ejemplo = new Ejemplo()
            {
                SubtemaId = idSubtema
            };

            ViewData["idTema"] = subtema.TemaId;
            return PartialView("_CreateExample", ejemplo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ejemplo ejemplo)
        {
            string msj = "";            
            if (ModelState.IsValid)
            {
                ejemplo.UsrCreoId = User.Identity.GetUserId();
                ejemplo = busEjemplo.saveAutomatic(ejemplo);
                if (string.IsNullOrEmpty(busEjemplo.Error))
                {
                    msj = "OK";
                }
                else
                {
                    msj = busEjemplo.Error;
                }

            }
            return Json(msj);
        }



        // GET: Ejemploes/Edit/5
        public PartialViewResult Edit(int? id)
        {            
            Ejemplo ejemplo = busEjemplo.ListaById(id);            
            Subtema subtema = busSubtema.ListaById(ejemplo.SubtemaId);            
            //ViewData["NombreTema"] = busTema.nombreDelTema(subtema.TemaId);
            ViewData["nombreSubtema"] = busSubtema.NombreSubtema(ejemplo.SubtemaId);
            return PartialView("_Edit", ejemplo);
        }

        // POST: Ejemploes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(Ejemplo ejemplo)
        {
            string msj = "";
            if (ModelState.IsValid)
            {                               
                busEjemplo.update(ejemplo);
                if (string.IsNullOrEmpty(busEjemplo.Error))
                {
                    msj = "OK";
                }
                else
                {
                    msj = busEjemplo.Error;
                }
            }
            //List<Ejemplo> Lst = busEjemplo.LstEjemploJoinDetalle(ejemplo.SubtemaId);
            //ViewData["subtemaId"] = ejemplo.SubtemaId;
            //return PartialView("_ArbolEjemplo", Lst);
            return Json(msj);
        }
          
        public PartialViewResult Delete(int ejemploId)
        {
            Ejemplo ejemplo = busEjemplo.ListaById(ejemploId);
            busEjemplo.Delete(ejemploId);

            List<Ejemplo> Lst = busEjemplo.LstEjemploJoinDetalle(ejemplo.SubtemaId);
            ViewData["subtemaId"] = ejemplo.SubtemaId;
            return PartialView("_ArbolEjemplo", Lst);
        }

    }
}
