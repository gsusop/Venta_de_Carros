
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
    [Authorize]
    [RoutePrefix("api/TiposdeServicio")]
    public class TiposdeServicioController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Tipos_de_Servicio> ConsultarTodos()
        {
            clsTiposdeServicio Tipos_de_Servicio = new clsTiposdeServicio();
            return Tipos_de_Servicio.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Tipos_de_Servicio Consultar([FromUri] int ServiceType)
        {
            clsTiposdeServicio Tipos_de_Servicio = new clsTiposdeServicio();
            return Tipos_de_Servicio.Consultar(ServiceType);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Tipos_de_Servicio tps)
        {
            clsTiposdeServicio Tipos_de_Servicio = new clsTiposdeServicio();
            Tipos_de_Servicio.tps = tps;
            return Tipos_de_Servicio.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Tipos_de_Servicio tps)
        {
            clsTiposdeServicio Tipos_de_Servicio = new clsTiposdeServicio();
            Tipos_de_Servicio.tps = tps;
            return Tipos_de_Servicio.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Tipos_de_Servicio tps)
        {
            clsTiposdeServicio Tipos_de_Servicio = new clsTiposdeServicio();
            Tipos_de_Servicio.tps = tps;
            return Tipos_de_Servicio.Eliminar();
        }

    }
}
