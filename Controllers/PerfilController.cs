
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Venta_de_Carros.Models;
using Venta_de_Carros.Clases;

namespace Venta_de_Carros.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Perfil")]
    [Authorize]
    public class PerfilController : ApiController
    {
            // GET api/<controller>
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Perfil> ConsultarTodos()
            {
                clsPerfil Perfil = new clsPerfil();
                return Perfil.ConsultarTodos();
            }

            [HttpGet]
            [Route("Consultar")]
            public Perfil Consultar([FromUri] int Perfils)
            {
                clsPerfil Perfil = new clsPerfil();
                return Perfil.Consultar(Perfils);
            }


            [HttpPost]
            [Route("Insertar")]
            // POST api/<controller>
            public string Insertar([FromBody] Perfil perfil)
            {
                clsPerfil Perfil = new clsPerfil();
                Perfil.perfil = perfil;
                return Perfil.Insertar();
            }

            [HttpPut]
            [Route("Actualizar")]
            // PUT api/<controller>/5
            public string Actualizar([FromBody] Perfil perfil)
            {
                clsPerfil Perfil = new clsPerfil();
                Perfil.perfil = perfil;
                return Perfil.Actualizar();
            }
            [HttpDelete]
            [Route("Eliminar")]
            // DELETE api/<controller>/5
            public string Eliminar([FromBody] Perfil perfil)
            {
                clsPerfil Perfil = new clsPerfil();
                Perfil.perfil = perfil;
                return Perfil.Eliminar();
            }
        }
    }
