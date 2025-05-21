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
    [RoutePrefix("api/Facturas")]
    public class FacturaController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Factura> ConsultarTodos()
        {
            clsFactura Factura = new clsFactura();
            return Factura.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Factura ConsultarPorDocumento([FromUri] string idFactura)
        {
            clsFactura Factura = new clsFactura();
            return Factura.Consultar(idFactura);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Factura nuevaFactura) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsFactura facturaClase = new clsFactura(); // Cambiar el nombre de la variable local a empleadoClase
            facturaClase.Factura = nuevaFactura; // Asignar el parámetro a la propiedad Empleado de la clase
            return facturaClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Factura facturaActualizada) 
        {
            clsFactura facturaClase = new clsFactura(); 
            facturaClase.Factura = facturaActualizada; 
            return facturaClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Factura facturaAEliminar) 
        {
            clsFactura facturaClase = new clsFactura(); 
            facturaClase.Factura = facturaAEliminar; 
            return facturaClase.Eliminar();
        }
    }
}