using Bussines;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPersonal.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Usuarios usuario = new Usuarios()
            {
                Nombre = "Hector"
            ,
                Paterno = "glez"
            ,
                Materno = "glez2"
            ,
                Email = "correo@dominio2.com"
            ,
                Estatus = true
            ,
                NombreDeUsuario = "Hgonzalez2"
            ,
                Password = "12345"
            ,
                Fecha_creo = DateTime.Now
            ,
                UsrCreoId = "1"
            };
            new BusUsuarios().save(usuario);
            return View();
        }
        
        [HttpPost]
        public JsonResult Sumar(int cantidadUno,int cantidadDos)
        {
            int resultado = cantidadUno + cantidadDos;
            return Json(resultado);
        }

       public PartialViewResult obtenerDatos()
        {
           


            List<Subtema> Lst = new BusSubtema().Listar();
            return PartialView("_LstArbol", Lst);
        }
    }
}