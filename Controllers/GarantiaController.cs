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
    [RoutePrefix("api/Garantias")]
    public class GarantiaController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Garantia> ConsultarTodos()
        {
            clsGarantia Garantia = new clsGarantia();
            return Garantia.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Garantia ConsultarPorDocumento([FromUri] string idGarantia)
        {
            clsGarantia Garantia = new clsGarantia();
            return Garantia.Consultar(idGarantia);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Garantia nuevaGarantia) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsGarantia garantiaClase = new clsGarantia(); // Cambiar el nombre de la variable local a empleadoClase
            garantiaClase.Garantia = nuevaGarantia; // Asignar el parámetro a la propiedad Empleado de la clase
            return garantiaClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Garantia garantiaActualizada)
        {
            clsGarantia garantiaClase = new clsGarantia();
            garantiaClase.Garantia = garantiaActualizada;
            return garantiaClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Garantia garantiaAEliminar)
        {
            clsGarantia garantiaClase = new clsGarantia();
            garantiaClase.Garantia = garantiaAEliminar;
            return garantiaClase.Eliminar();
        }
    }
}