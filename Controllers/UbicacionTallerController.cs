using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    public class Ubicaciones_TallerController
    {
        [RoutePrefix("api/UbicacionesTalleres")]
        public class Ubicaciones_TallersController : ApiController
        {
            // GET api/<controller>
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Ubicaciones_Taller> ConsultarTodos()
            {
                clsUbicaciones_Taller Ubicaciones_Taller = new clsUbicaciones_Taller();
                return Ubicaciones_Taller.ConsultarTodos();
            }

            [HttpGet]
            [Route("ConsultarPorDocumento")]
            public Ubicaciones_Taller ConsultarPorDocumento([FromUri] string Documento)
            {
                clsUbicaciones_Taller Ubicaciones_Taller = new clsUbicaciones_Taller();
                return Ubicaciones_Taller.Consultar(Documento);
            }


            [HttpPost]
            [Route("Insertar")]
            // POST api/<controller>
            public string Insertar([FromBody] Ubicaciones_Taller nuevoUbicaciones_Taller) // Cambiar el nombre del parámetro a nuevoUbicaciones_Taller
            {
                clsUbicaciones_Taller Ubicaciones_TallerClase = new clsUbicaciones_Taller(); // Cambiar el nombre de la variable local a Ubicaciones_TallerClase
                Ubicaciones_TallerClase.Ubicaciones_Taller = nuevoUbicaciones_Taller; // Asignar el parámetro a la propiedad Ubicaciones_Taller de la clase
                return Ubicaciones_TallerClase.Insertar();
            }

            [HttpPut]
            [Route("Actualizar")]
            // PUT api/<controller>/5
            public string Actualizar([FromBody] Ubicaciones_Taller Ubicaciones_TallerActualizado) // Cambiar el nombre del parámetro a Ubicaciones_TallerActualizado
            {
                clsUbicaciones_Taller Ubicaciones_TallerClase = new clsUbicaciones_Taller(); // Cambiar el nombre de la variable local a Ubicaciones_TallerClase
                Ubicaciones_TallerClase.Ubicaciones_Taller = Ubicaciones_TallerActualizado; // Asignar el parámetro a la propiedad Ubicaciones_Taller de la clase
                return Ubicaciones_TallerClase.Actualizar();
            }
            [HttpDelete]
            [Route("Eliminar")]
            // DELETE api/<controller>/5
            public string Eliminar([FromBody] Ubicaciones_Taller Ubicaciones_TallerAEliminar) // Cambiar el nombre del parámetro a Ubicaciones_TallerAEliminar
            {
                clsUbicaciones_Taller Ubicaciones_TallerClase = new clsUbicaciones_Taller(); // Cambiar el nombre de la variable local a Ubicaciones_TallerClase
                Ubicaciones_TallerClase.Ubicaciones_Taller = Ubicaciones_TallerAEliminar; // Asignar el parámetro a la propiedad Ubicaciones_Taller de la clase
                return Ubicaciones_TallerClase.Eliminar();
            }
        }
    }
}