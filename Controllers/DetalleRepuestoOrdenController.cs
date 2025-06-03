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
    [RoutePrefix("api/DetalleRepuestoOrden")]
    public class DetalleRepuestoOrdenController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Detalle_Repuestos_Orden> ConsultarTodos()
        {
            clsDetalleRepuestoOrden detRepuOrd = new clsDetalleRepuestoOrden();
            var data = detRepuOrd.ConsultarTodos();
            return data;
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Detalle_Repuestos_Orden detalle_repuestos) 
        {
            clsDetalleRepuestoOrden detRepuOrd = new clsDetalleRepuestoOrden();
            detRepuOrd.Detalle_Repuestos_Orden  = detalle_repuestos;
            return detRepuOrd.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Detalle_Repuestos_Orden detalleRepuestoActualizado)
        {
            clsDetalleRepuestoOrden detRepuOrd = new clsDetalleRepuestoOrden();
            detRepuOrd.Detalle_Repuestos_Orden = detalleRepuestoActualizado; 
            return detRepuOrd.Insertar();
        }



        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Detalle_Repuestos_Orden detRepuordeAEliminar)
        {
            clsDetalleRepuestoOrden detRepuOrd = new clsDetalleRepuestoOrden();
            detRepuOrd.Detalle_Repuestos_Orden = detRepuordeAEliminar;
            return detRepuOrd.Eliminar();
        }





    }

}

