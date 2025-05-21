using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Venta_de_Carros.Models;
using System.Data.Entity.Infrastructure; // Necesario para DbUpdateException
using System.Data.Entity.Validation; // Opcional, para errores de validación de EF

namespace Venta_de_Carros.Clases
{
    // La clase se llama clsProveedore para ser consistente con el nombre de la entidad
    public class clsProveedore
    {
        // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1();

        // Permite manipular o acceder a los atributos de la tabla Proveedore
        public Proveedore Proveedore { get; set; }

        /// <summary>
        /// Inserta un nuevo proveedor en la base de datos.
        /// </summary>
        /// <returns>Mensaje de confirmación o error.</returns>
        public string Insertar()
        {
            try
            {
                ITM_Ventas.Proveedores.Add(Proveedore); // Agrega un nuevo proveedor a la tabla Proveedores
                ITM_Ventas.SaveChanges(); // Guarda los cambios en la BD
                return "Proveedore insertado exitosamente"; // Mensaje de confirmación
            }
            catch (DbUpdateException ex)
            {
                // Manejo de excepciones específicas de Entity Framework (ej. violación de UNIQUE constraint)
                return "Error al insertar el proveedore. Verifique que el NIT no esté duplicado o que los datos sean válidos. Detalle: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción inesperada
                return "Ocurrió un error inesperado al insertar el proveedore: " + ex.Message;
            }
        }

        /// <summary>
        /// Actualiza un proveedor existente en la base de datos.
        /// </summary>
        /// <returns>Mensaje de confirmación o error.</returns>
        public string Actualizar()
        {
            try
            {
                // Consultamos el proveedor por su NIT para verificar si existe
                Proveedore prv = Consultar(Proveedore.NIT);
                if (prv == null)
                {
                    return "El proveedore no existe"; // Mensaje si el proveedor no se encuentra
                }
                // Actualiza un proveedor en la tabla PROVEEDORES
                ITM_Ventas.Proveedores.AddOrUpdate(Proveedore);
                ITM_Ventas.SaveChanges(); // Guarda los cambios
                return "Se actualizó el proveedore correctamente"; // Mensaje de confirmación
            }
            catch (DbUpdateException ex)
            {
                // Manejo de excepciones específicas de Entity Framework
                return "Error al actualizar el proveedore. Verifique que el NIT no esté duplicado o que los datos sean válidos. Detalle: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción inesperada
                return "Ocurrió un error inesperado al actualizar el proveedore: " + ex.Message;
            }
        }

        /// <summary>
        /// Consulta un proveedor por su NIT.
        /// </summary>
        /// <param name="nit">El NIT del proveedor a consultar.</param>
        /// <returns>El objeto Proveedore si se encuentra, de lo contrario, null.</returns>
        public Proveedore Consultar(string nit)
        {
            // Consulta un proveedor por su NIT
            Proveedore prv = ITM_Ventas.Proveedores.FirstOrDefault(e => e.NIT == nit);
            return prv;
        }

        /// <summary>
        /// Elimina un proveedor de la base de datos.
        /// </summary>
        /// <param name="nit">El NIT del proveedor a eliminar.</param>
        /// <returns>Mensaje de confirmación o error.</returns>
        public string Eliminar(string nit) // Recibe el NIT como parámetro
        {
            try
            {
                // Consultamos el proveedor por su NIT para verificar si existe
                Proveedore prv = Consultar(nit);
                if (prv == null)
                {
                    return "El proveedore no existe"; // Mensaje si el proveedor no se encuentra
                }
                // Elimina un proveedor de la tabla Proveedores
                ITM_Ventas.Proveedores.Remove(prv);
                ITM_Ventas.SaveChanges(); // Guarda los cambios
                return "Se eliminó el proveedore exitosamente"; // Mensaje de confirmación
            }
            catch (DbUpdateException ex)
            {
                // Manejo de excepciones de integridad referencial
                // Si hay registros en Inventario_Repuestos que referencian a este proveedor, la eliminación fallará.
                if (ex.InnerException != null && ex.InnerException.Message.Contains("REFERENCE constraint"))
                {
                    return "No se puede eliminar el proveedore porque tiene repuestos asociados en el inventario. Elimine los repuestos asociados primero.";
                }
                return "Error al eliminar el proveedore. Detalle: " + ex.Message;
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción inesperada
                return "Ocurrió un error inesperado al eliminar el proveedore: " + ex.Message;
            }
        }

        /// <summary>
        /// Consulta todos los proveedores en la base de datos.
        /// </summary>
        /// <returns>Una lista de todos los proveedores.</returns>
        public List<Proveedore> ConsultarTodos()
        {
            return ITM_Ventas.Proveedores.ToList();
        }
    }
}
