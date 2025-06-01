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
    [RoutePrefix("api/RevisionGarantia")]
    [Authorize]
    public class RevisionGarantiaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Revisiones_Garantia> ConsultarTodos()
        {
            clsRevisionesGarantia revisionGarantia = new clsRevisionesGarantia();
            var data = revisionGarantia.ConsultarTodos();
            return data;
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Revisiones_Garantia ConsultarPorDocumento([FromUri] string idRevision)
        {
            clsRevisionesGarantia revisionGarantia = new clsRevisionesGarantia();
            return revisionGarantia.Consultar(idRevision);
        }


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Revisiones_Garantia nuevaRevisionGarantia) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsRevisionesGarantia revisionGarantia = new clsRevisionesGarantia(); // Cambiar el nombre de la variable local a empleadoClase
            revisionGarantia.Revisiones_Garantia = nuevaRevisionGarantia; // Asignar el parámetro a la propiedad Empleado de la clase
            return revisionGarantia.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Revisiones_Garantia revisionGarantiaActualizada)
        {
            clsRevisionesGarantia revisionGarantia = new clsRevisionesGarantia();
            revisionGarantia.Revisiones_Garantia = revisionGarantiaActualizada;
            return revisionGarantia.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Revisiones_Garantia revisionGarantiaAEliminar)
        {
            clsRevisionesGarantia revisionGarantia = new clsRevisionesGarantia();
            revisionGarantia.Revisiones_Garantia = revisionGarantiaAEliminar;
            return revisionGarantia.Eliminar();
        }

    }
}