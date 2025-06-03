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
    [RoutePrefix("api/Proveedores")]
    [Authorize]
    public class ProveedorControler : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Proveedor> ConsultarTodos()
        {
            clsProveedor proveedor = new clsProveedor();
            var data = proveedor.ConsultarTodos();
            return data;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Proveedor proveedorinsertar) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.Proveedor = proveedorinsertar;
            return proveedor.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Proveedor provActualizar)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.Proveedor = provActualizar;
            return proveedor.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Proveedor proveedorEliminar)
        {
            clsProveedor proveedor = new clsProveedor();
            proveedor.Proveedor = proveedorEliminar;
            return proveedor.Eliminar();
        }
    }
}