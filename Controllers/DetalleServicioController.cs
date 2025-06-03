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
    [RoutePrefix("api/DetalleServicios")]
    [Authorize]
    public class DetalleServicioController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Detalle_Servicio> ConsultarTodos()
        {
            clsDetalleServicio detServicio = new clsDetalleServicio();
            var data = detServicio.ConsultarTodos();
            return data;
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Detalle_Servicio ConsultarPorDocumento([FromUri] string idDetalleServicio)
        {
            clsDetalleServicio detServicio = new clsDetalleServicio();
            return detServicio.Consultar(idDetalleServicio);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Detalle_Servicio nuevoDetServicio) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsDetalleServicio detServicioClase = new clsDetalleServicio(); // Cambiar el nombre de la variable local a empleadoClase
            detServicioClase.Detalle_Servicio = nuevoDetServicio; // Asignar el parámetro a la propiedad Empleado de la clase
            return detServicioClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Detalle_Servicio detServicioActualizado)
        {
            clsDetalleServicio detServicioClase = new clsDetalleServicio();
            detServicioClase.Detalle_Servicio = detServicioActualizado;
            return detServicioClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Detalle_Servicio detServicioAEliminar)
        {
            clsDetalleServicio detServicioClase = new clsDetalleServicio();
            detServicioClase.Detalle_Servicio = detServicioAEliminar;
            return detServicioClase.Eliminar();
        }
    }
}