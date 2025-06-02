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

    [RoutePrefix("api/InventarioRepuesto")]
    [Authorize]
    public class InventarioRepuestoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Inventario_Repuesto> ConsultarTodos()
        {
            clsInventarioRepuesto inventarioRepuesto = new clsInventarioRepuesto();
            var data = inventarioRepuesto.ConsultarTodos();
            return data;
        }


        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Inventario_Repuesto ConsultarPorDocumento([FromUri] string IdRepuesto)
        {
            clsInventarioRepuesto inventarioRepuesto = new clsInventarioRepuesto();
            return inventarioRepuesto.Consultar(IdRepuesto);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Inventario_Repuesto nuevoInventario)
        {
            clsInventarioRepuesto inventarioRepuesto = new clsInventarioRepuesto();
            inventarioRepuesto.Inventario_Repuesto = nuevoInventario; 
            return inventarioRepuesto.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Inventario_Repuesto inveActualizado)
        {
            clsInventarioRepuesto inventarioRepuesto = new clsInventarioRepuesto();
            inventarioRepuesto.Inventario_Repuesto = inveActualizado;
            return inventarioRepuesto.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Inventario_Repuesto InvenElimina)
        {
            clsInventarioRepuesto inventarioRepuesto = new clsInventarioRepuesto();
            inventarioRepuesto.Inventario_Repuesto = InvenElimina;
            return inventarioRepuesto.Eliminar();
        }

    }
}