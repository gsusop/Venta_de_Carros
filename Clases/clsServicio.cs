using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsServicio
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); 
        public Servicio Servicio { get; set; }
        public string Insertar()
        {
            ITM_Ventas.Servicios.Add(Servicio);
            ITM_Ventas.SaveChanges();
            return "Servicio Insertado exitosamente";
        }

        public string Actualizar()
        {
            Servicio serv = Consultar(Servicio.ID_Servicio.ToString());
            if (serv == null)
            {
                return "El servicio no existe";
            }
            ITM_Ventas.Servicios.AddOrUpdate(Servicio);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Servicio Consultar(string IdServicio)
        {
            Servicio serv = ITM_Ventas.Servicios.FirstOrDefault(e => e.ID_Servicio.ToString() == IdServicio.ToString());
            return serv;
        }

        public string Eliminar()
        {
            try
            {
                Servicio serv = Consultar(Servicio.ID_Servicio.ToString());
                if (serv == null)
                {
                    return "El servicio no existe";
                }
                ITM_Ventas.Servicios.Remove(serv);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el servicio exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Servicio> ConsultarTodos()
        {
            return ITM_Ventas.Servicios.ToList();
        }
    }
}