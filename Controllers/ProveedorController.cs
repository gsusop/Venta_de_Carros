using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    [RoutePrefix("api/Proveedores")]
    [Authorize]
    // La clase del controlador debe heredar de ApiController
    // Renombramos la ruta para que sea consistente con el plural de la tabla

    public class ProveedoresController : ApiController
        {
            /// <summary>
            /// Consulta todos los proveedores.
            /// </summary>
            /// <returns>Una lista de proveedores.</returns>
            [HttpGet]
            [Route("ConsultarTodos")]
            public List<Proveedor> ConsultarTodos() // El tipo de retorno es Proveedore
            {
                clsProveedore proveedoreClase = new clsProveedore(); // Instanciamos clsProveedore
                return proveedoreClase.ConsultarTodos();
            }

            /// <summary>
            /// Consulta un proveedor por su NIT.
            /// </summary>
            /// <param name="nit">El NIT del proveedor a consultar.</param>
            /// <returns>El proveedor encontrado.</returns>
            [HttpGet]
            // Usamos {nit} en la ruta para indicar que es un parámetro de la URL
            [Route("ConsultarPorNit/{nit}")]
            public Proveedor ConsultarPorNit([FromUri] string nit) // El tipo de retorno es Proveedore
            {
                clsProveedore proveedoreClase = new clsProveedore(); // Instanciamos clsProveedore
                return proveedoreClase.Consultar(nit);
            }

            /// <summary>
            /// Inserta un nuevo proveedor.
            /// </summary>
            /// <param name="nuevoProveedore">El objeto Proveedore a insertar.</param>
            /// <returns>Mensaje de confirmación o error.</returns>
            [HttpPost]
            [Route("Insertar")]
            public string Insertar([FromBody] Proveedor nuevoProveedore) // El parámetro es de tipo Proveedore
            {
                clsProveedore proveedoreClase = new clsProveedore(); // Instanciamos clsProveedore
                proveedoreClase.Proveedor = nuevoProveedore; // Asignamos el objeto a la propiedad de la clase
                return proveedoreClase.Insertar();
            }

            /// <summary>
            /// Actualiza un proveedor existente.
            /// </summary>
            /// <param name="proveedoreActualizado">El objeto Proveedore con los datos actualizados.</param>
            /// <returns>Mensaje de confirmación o error.</returns>
            [HttpPut]
            [Route("Actualizar")]
            public string Actualizar([FromBody] Proveedor proveedoreActualizado) // El parámetro es de tipo Proveedore
            {
                clsProveedore proveedoreClase = new clsProveedore(); // Instanciamos clsProveedore
                proveedoreClase.Proveedor = proveedoreActualizado; // Asignamos el objeto a la propiedad de la clase
                return proveedoreClase.Actualizar();
            }

            /// <summary>
            /// Elimina un proveedor por su NIT.
            /// </summary>
            /// <param name="nit">El NIT del proveedor a eliminar.</param>
            /// <returns>Mensaje de confirmación o error.</returns>
            [HttpDelete]
            // Usamos {nit} en la ruta para indicar que es un parámetro de la URL
            [Route("Eliminar/{nit}")]
            public string Eliminar([FromUri] string nit) // Recibimos el NIT desde la URI
            {
                clsProveedore proveedoreClase = new clsProveedore(); // Instanciamos clsProveedore
                return proveedoreClase.Eliminar(nit); // Pasamos el NIT al método de la clase
            }
        }
    
}
