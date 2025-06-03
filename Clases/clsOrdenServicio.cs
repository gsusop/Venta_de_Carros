using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
	public class clsOrdenServicio
	{
        private VentaDeCarrosTallerEntities2 ITM_Ventas = new VentaDeCarrosTallerEntities2(); 
        public Ordenes_de_Servicio Ordenes_de_Servicio { get; set; }

        public Ordenes_de_Servicio Consultar(string idOrdenServ)
        {
            Ordenes_de_Servicio ordenServ = ITM_Ventas.Ordenes_de_Servicios.FirstOrDefault(e => e.ID_Orden.ToString() == idOrdenServ.ToString());
            return ordenServ;
        }

        public List<Ordenes_de_Servicio> ConsultarTodos()
        {
            try
            {
                return ITM_Ventas.Ordenes_de_Servicios.ToList(); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar todas las ordenes de servicio: {ex.Message}");
                return new List<Ordenes_de_Servicio>();
            }
        }



        public string Insertar()
        {
            ITM_Ventas.Ordenes_de_Servicios.Add(Ordenes_de_Servicio);
            ITM_Ventas.SaveChanges();
            return "Orden de servicio Insertada exitosamente";
        }

        public string Actualizar()
        {
            Ordenes_de_Servicio ordenServ = Consultar(Ordenes_de_Servicio.ID_Orden.ToString());
            if (ordenServ == null)
            {
                return "La orden de servicio no existe";
            }
            ITM_Ventas.Ordenes_de_Servicios.AddOrUpdate(Ordenes_de_Servicio);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public string Eliminar()
        {
            try
            {
                Ordenes_de_Servicio ordenServ = Consultar(Ordenes_de_Servicio.ID_Orden.ToString());
                if (ordenServ == null)
                {
                    return "La orden de servicio no existe";
                }
                ITM_Ventas.Ordenes_de_Servicios.Remove(ordenServ);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la orden de servicio exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}



    

 

 
