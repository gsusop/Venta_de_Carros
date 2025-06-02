
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
    [RoutePrefix("api/Ventas")]
    [Authorize]
    public class VentaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Venta> ConsultarTodos()
        {
            clsVenta venta = new clsVenta();
            var data = venta.ConsultarTodos();
            return data;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Venta nuevaventa) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsVenta venta = new clsVenta();
            venta.Venta = nuevaventa; // Asignar el parámetro a la propiedad Empleado de la clase
            return venta.Insertar();
        }



        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Venta ventaAct)
        {
            clsVenta venta = new clsVenta();
            venta.Venta = ventaAct;
            return venta.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Venta ventaElimi)
        {
            clsVenta venta = new clsVenta();
            venta.Venta = ventaElimi;
            return venta.Eliminar();
        }


    }
}
