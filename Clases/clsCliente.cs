using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsCliente
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        public Cliente cliente { get; set; }// permite manipular o acceder a los atributos de la tabla CLIENTE
        public string Insertar()
        {
            ITM_Ventas.Clientes.Add(cliente);// agrega un nuevo empleado a la tabla EMPLEADO (INsert Into)
            ITM_Ventas.SaveChanges();//Guarda los cambios en la BD
            return "Cliente Insertado exitosamente";//Mensaje de confirmaion
        }

        public string Actualizar()
        {
            Cliente clt = Consultar(cliente.Numero_Documento);
            if (clt == null)
            {
                return "EL documento no existe";
            }
            ITM_Ventas.Clientes.AddOrUpdate(cliente);//Actualiza un emplado en la tabla EMPLEADO
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }
        public Cliente Consultar(string Documento)
        {
            Cliente clt = ITM_Ventas.Clientes.FirstOrDefault(e => e.Numero_Documento == Documento);//consulta un cliente por su documento
            return clt;
        }

        public string Eliminar()
        {
            try
            {
                Cliente clt = Consultar(cliente.Numero_Documento);
                if (clt == null)
                {
                    return "EL documento no existe";
                }
                ITM_Ventas.Clientes.Remove(clt);//Elimina un cliente de la tabla CLIENTE
                ITM_Ventas.SaveChanges();//GUarda los cambios
                return "Se eliminó el cliente exitosamente";// Mensaje de confirmacion
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Cliente> ConsultarTodos()
        {
            return ITM_Ventas.Clientes.ToList();
        }

    }
}
