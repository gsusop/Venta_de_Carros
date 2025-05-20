using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    [RoutePrefix("api/Empleados")]
    public class EmpleadosController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Empleado> ConsultarTodos()
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorDocumento")]
        public Empleado ConsultarPorDocumento([FromUri] string Documento)
        {
            clsEmpleado Empleado = new clsEmpleado();
            return Empleado.Consultar(Documento);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Empleado nuevoEmpleado) // Cambiar el nombre del parámetro a nuevoEmpleado
        {
            clsEmpleado empleadoClase = new clsEmpleado(); // Cambiar el nombre de la variable local a empleadoClase
            empleadoClase.Empleado = nuevoEmpleado; // Asignar el parámetro a la propiedad Empleado de la clase
            return empleadoClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Empleado empleadoActualizado) // Cambiar el nombre del parámetro a empleadoActualizado
        {
            clsEmpleado empleadoClase = new clsEmpleado(); // Cambiar el nombre de la variable local a empleadoClase
            empleadoClase.Empleado = empleadoActualizado; // Asignar el parámetro a la propiedad Empleado de la clase
            return empleadoClase.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Empleado empleadoAEliminar) // Cambiar el nombre del parámetro a empleadoAEliminar
        {
            clsEmpleado empleadoClase = new clsEmpleado(); // Cambiar el nombre de la variable local a empleadoClase
            empleadoClase.Empleado = empleadoAEliminar; // Asignar el parámetro a la propiedad Empleado de la clase
            return empleadoClase.Eliminar();
        }
    }
}