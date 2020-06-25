using Bussines;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebPersonal.Controllers
{
    public class APIUsuariosController : ApiController
    {
        // GET: api/APIUsuarios
        BusUsuarios busUsuario;        
        public APIUsuariosController()
        {
            busUsuario = new BusUsuarios();
        }
        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return busUsuario.LstUusuarios();
        }

        // GET: api/APIUsuarios/5
        [HttpGet]
        public Usuarios Get(int id)
        {
            return busUsuario.LstUusuariosById(id);
        }
        [HttpGet]
        public Usuarios ValidaAcceso(string NombreDeUsuario,string Password)
        {
            return busUsuario.ValidaAcceso(NombreDeUsuario, Password);
        }

        // POST: api/APIUsuarios
        [HttpPost]
        public Boolean Post(Usuarios usuario)
        {
            Boolean respuesta = false;
            if (ModelState.IsValid)
            {
                busUsuario.save(usuario);
                respuesta = true;
            }            
            return respuesta;
        }

        // PUT: api/APIUsuarios/5
        [HttpPut]
        public Boolean Put(Usuarios usuario)
        {
            Boolean respuesta = false;
            if (ModelState.IsValid)
            {
                busUsuario.update(usuario);
                respuesta = true;
            }            
            return respuesta;
        }

        // DELETE: api/APIUsuarios/5
        [HttpDelete]
        public Boolean Delete(int id)
        {
            Boolean respuesta = false;
            if (id > 0)
            {
                busUsuario.Delete(id);
                respuesta = true;
            }
            return respuesta;
        }
    }
}
