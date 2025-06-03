
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Venta_de_Carros.Models;
using Venta_de_Carros.Clases;

namespace Venta_de_Carros.Controllers
{
    [RoutePrefix("api/VehiculoenTallerUbicacion")]
    public class VehiculoenTallerUbicacionController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Vehiculo_en_Taller_Ubicacion> ConsultarTodos()
        {
            clsVehiculoenTallerUbicacion Vehiculo_en_Taller_Ubicacion = new clsVehiculoenTallerUbicacion();
            return Vehiculo_en_Taller_Ubicacion.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Vehiculo_en_Taller_Ubicacion Consultar([FromUri] int VehiculoTaller)
        {
            clsVehiculoenTallerUbicacion Vehiculo_en_Taller_Ubicacion = new clsVehiculoenTallerUbicacion();
            return Vehiculo_en_Taller_Ubicacion.Consultar(VehiculoTaller);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Vehiculo_en_Taller_Ubicacion vehiculoEnTallerUbicacion)
        {
            clsVehiculoenTallerUbicacion Vehiculo_en_Taller_Ubicacion = new clsVehiculoenTallerUbicacion();
            Vehiculo_en_Taller_Ubicacion.vehiculoEnTallerUbicacion = vehiculoEnTallerUbicacion;
            return Vehiculo_en_Taller_Ubicacion.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Vehiculo_en_Taller_Ubicacion vehiculoEnTallerUbicacion)
        {
            clsVehiculoenTallerUbicacion Vehiculo_en_Taller_Ubicacion = new clsVehiculoenTallerUbicacion();
            Vehiculo_en_Taller_Ubicacion.vehiculoEnTallerUbicacion = vehiculoEnTallerUbicacion;
            return Vehiculo_en_Taller_Ubicacion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Vehiculo_en_Taller_Ubicacion vehiculoEnTallerUbicacion)
        {
            clsVehiculoenTallerUbicacion Vehiculo_en_Taller_Ubicacion = new clsVehiculoenTallerUbicacion();
            Vehiculo_en_Taller_Ubicacion.vehiculoEnTallerUbicacion = vehiculoEnTallerUbicacion;
            return Vehiculo_en_Taller_Ubicacion.Eliminar();
        }

    }
}
