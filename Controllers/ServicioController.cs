using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    [RoutePrefix("api/Servicios")]
    public class ServicioController : ApiController
    {
 
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Servicio> ConsultarTodos()
        {
            clsServicio Factura = new clsServicio();
            return Factura.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Servicio ConsultarPorDocumento([FromUri] string idServicio)
        {
            clsServicio Servicio = new clsServicio();
            return Servicio.Consultar(idServicio);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Servicio nuevoServicio) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsServicio servicioClase = new clsServicio(); // Cambiar el nombre de la variable local a empleadoClase
            servicioClase.Servicio = nuevoServicio; // Asignar el parámetro a la propiedad Empleado de la clase
            return servicioClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Servicio servicioActualizado)
        {
            clsServicio servicioClase = new clsServicio();
            servicioClase.Servicio = servicioActualizado;
            return servicioClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Servicio servicioAEliminar)
        {
            clsServicio servicioClase = new clsServicio();
            servicioClase.Servicio = servicioAEliminar;
            return servicioClase.Eliminar();
        }
    }
}