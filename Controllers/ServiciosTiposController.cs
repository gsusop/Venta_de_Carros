
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Venta_de_Carros.Models;
using Venta_de_Carros.Clases;

namespace Venta_de_Carros.Controllers
{
    [RoutePrefix("api/ServiciosTipos")]
    public class ServiciosTiposController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Servicios_Tipos> ConsultarTodos()
        {
            clsServiciosTipos Servicios_Tipos = new clsServiciosTipos();
            return Servicios_Tipos.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Servicios_Tipos Consultar([FromUri] int ServiceType)
        {
            clsServiciosTipos Servicios_Tipos = new clsServiciosTipos();
            return Servicios_Tipos.Consultar(ServiceType);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Servicios_Tipos ST)
        {
            clsServiciosTipos Servicios_Tipos = new clsServiciosTipos();
            Servicios_Tipos.ST = ST;
            return Servicios_Tipos.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Servicios_Tipos ST)
        {
            clsServiciosTipos Servicios_Tipos = new clsServiciosTipos();
            Servicios_Tipos.ST = ST;
            return Servicios_Tipos.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Servicios_Tipos ST)
        {
            clsServiciosTipos Servicios_Tipos = new clsServiciosTipos();
            Servicios_Tipos.ST = ST;
            return Servicios_Tipos.Eliminar();
        }
    }
}
