using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/OrdenServicio")]
    [Authorize]
    public class OrdenServicioController : ApiController
    {

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Ordenes_de_Servicio> ConsultarTodos()
        {
            clsOrdenServicio claseOrdenServ = new clsOrdenServicio();
            var data = claseOrdenServ.ConsultarTodos();
            return data;
        }


        [HttpGet]
        [Route("ConsultarPorId")]
        public Ordenes_de_Servicio ConsultarPorId([FromUri] string idOrdenServ)
        {
            clsOrdenServicio claseOrdenServ = new clsOrdenServicio();
            return claseOrdenServ.Consultar(idOrdenServ);
        }

        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Ordenes_de_Servicio nuevaOrdenSer) 
        {
            clsOrdenServicio claseOrdenServ = new clsOrdenServicio();
            claseOrdenServ.Ordenes_de_Servicio = nuevaOrdenSer; 
            return claseOrdenServ.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Ordenes_de_Servicio ordenServActu)
        {
            clsOrdenServicio claseOrdenServ = new clsOrdenServicio();
            claseOrdenServ.Ordenes_de_Servicio = ordenServActu;
            return claseOrdenServ.Actualizar();
        }


        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Ordenes_de_Servicio ordenServElimi)
        {
            clsOrdenServicio claseOrdenServ = new clsOrdenServicio();
            claseOrdenServ.Ordenes_de_Servicio = ordenServElimi;
            return claseOrdenServ.Eliminar();
        }





    }
}


