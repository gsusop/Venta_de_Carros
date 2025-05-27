using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    public class VehiculoController
    {
        [RoutePrefix("api/Vehiculos")]
        public class VehiculosController : ApiController
        {
            // GET api/<controller>
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Vehiculo> ConsultarTodos()
            {
                clsVehiculo Vehiculo = new clsVehiculo();
                return Vehiculo.ConsultarTodos();
            }

            [HttpGet]
            [Route("ConsultarPorDocumento")]
            public Vehiculo ConsultarPorDocumento([FromUri] string Documento)
            {
                clsVehiculo Vehiculo = new clsVehiculo();
                return Vehiculo.Consultar(Documento);
            }


            [HttpPost]
            [Route("Insertar")]
            // POST api/<controller>
            public string Insertar([FromBody] Vehiculo nuevoVehiculo) // Cambiar el nombre del parámetro a nuevoVehiculo
            {
                clsVehiculo VehiculoClase = new clsVehiculo(); // Cambiar el nombre de la variable local a VehiculoClase
                VehiculoClase.Vehiculo = nuevoVehiculo; // Asignar el parámetro a la propiedad Vehiculo de la clase
                return VehiculoClase.Insertar();
            }

            [HttpPut]
            [Route("Actualizar")]
            // PUT api/<controller>/5
            public string Actualizar([FromBody] Vehiculo VehiculoActualizado) // Cambiar el nombre del parámetro a VehiculoActualizado
            {
                clsVehiculo VehiculoClase = new clsVehiculo(); // Cambiar el nombre de la variable local a VehiculoClase
                VehiculoClase.Vehiculo = VehiculoActualizado; // Asignar el parámetro a la propiedad Vehiculo de la clase
                return VehiculoClase.Actualizar();
            }
            [HttpDelete]
            [Route("Eliminar")]
            // DELETE api/<controller>/5
            public string Eliminar([FromBody] Vehiculo VehiculoAEliminar) // Cambiar el nombre del parámetro a VehiculoAEliminar
            {
                clsVehiculo VehiculoClase = new clsVehiculo(); // Cambiar el nombre de la variable local a VehiculoClase
                VehiculoClase.Vehiculo = VehiculoAEliminar; // Asignar el parámetro a la propiedad Vehiculo de la clase
                return VehiculoClase.Eliminar();
            }
        }
    }
}