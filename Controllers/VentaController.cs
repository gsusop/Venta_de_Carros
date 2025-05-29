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
    public class VentaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Venta> ConsultarTodos()
        {
            clsVenta Venta = new clsVenta();
            return Venta.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorId")]
        public Venta ConsultarPorId([FromUri] string idventa)
        {
            clsVenta venta = new clsVenta();
            return venta.Consultar(idventa);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Venta nuevaventa) 
        {
            clsVenta venta = new clsVenta();
            venta.Venta = nuevaventa; 
            return venta.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Venta ventaActualizada)
        {
            clsVenta venta = new clsVenta();
            venta.Venta = ventaActualizada;
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