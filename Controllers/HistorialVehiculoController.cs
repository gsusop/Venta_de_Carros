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
    [RoutePrefix("api/HistorialVehiculo")]
    [Authorize]
    public class HistorialVehiculoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Historial_Vehiculo> ConsultarTodos()
        {
            clsHistorialVehiculo histVeh = new clsHistorialVehiculo();
          //  var data = histVeh.ConsultarTodos();
            return histVeh.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarPorId")]
        public Historial_Vehiculo ConsultarPorId([FromUri] string idHistorial)
        {
            clsHistorialVehiculo histVeh = new clsHistorialVehiculo();
            return histVeh.Consultar(idHistorial); 

        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Historial_Vehiculo histoveh) 
        {
            clsHistorialVehiculo histVeh = new clsHistorialVehiculo();
            histVeh.Historial_Vehiculo = histoveh; 
            return histVeh.Insertar();
        }


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Historial_Vehiculo histVehActuali)
        {
            clsHistorialVehiculo histVeh = new clsHistorialVehiculo();
            histVeh.Historial_Vehiculo = histVehActuali;
            return histVeh.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Historial_Vehiculo histovehelimi)
        {
            clsHistorialVehiculo histVeh = new clsHistorialVehiculo();
            histVeh.Historial_Vehiculo = histovehelimi;
            return histVeh.Eliminar();
        }




    }
}
