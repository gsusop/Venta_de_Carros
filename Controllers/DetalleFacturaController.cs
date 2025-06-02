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
    [RoutePrefix("api/DetalleFacturas")]
    [Authorize]
    public class DetalleFacturaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Detalle_Factura> ConsultarTodos()
        {
            clsDetalleFactura detFactura = new clsDetalleFactura();
            var data = detFactura.ConsultarTodos();
            return data;
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Detalle_Factura ConsultarPorDocumento([FromUri] string idDetalleFactura)
        {
            clsDetalleFactura detFactura = new clsDetalleFactura();
            return detFactura.Consultar(idDetalleFactura);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Detalle_Factura nuevoDetFactura) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsDetalleFactura detFacturaClase = new clsDetalleFactura(); // Cambiar el nombre de la variable local a empleadoClase
            detFacturaClase.Detalle_Factura = nuevoDetFactura; // Asignar el parámetro a la propiedad Empleado de la clase
            return detFacturaClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Detalle_Factura detFacturaActualizado)
        {
            clsDetalleFactura detFacturaClase = new clsDetalleFactura();
            detFacturaClase.Detalle_Factura = detFacturaActualizado;
            return detFacturaClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Detalle_Factura detFacturaAEliminar)
        {
            clsDetalleFactura detFacturaClase = new clsDetalleFactura();
            detFacturaClase.Detalle_Factura = detFacturaAEliminar;
            return detFacturaClase.Eliminar();
        }
    }
}