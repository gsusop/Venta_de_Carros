using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsDetalleServicio
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities();
        public Detalle_Servicio Detalle_Servicio { get; set; }
        public string Insertar()
        {
            ITM_Ventas.Detalle_Servicio.Add(Detalle_Servicio);
            ITM_Ventas.SaveChanges();
            return "Servicio Insertado exitosamente";
        }

        public string Actualizar()
        {
            Detalle_Servicio dellateServ = Consultar(Detalle_Servicio.ID_Detalle_Servicio.ToString());
            if (dellateServ == null)
            {
                return "El detalle del servicio no existe";
            }
            ITM_Ventas.Detalle_Servicio.AddOrUpdate(Detalle_Servicio);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Detalle_Servicio Consultar(string IdDetalle_Servicio)
        {
            Detalle_Servicio dellateServ = ITM_Ventas.Detalle_Servicio.FirstOrDefault(e => e.ID_Detalle_Servicio.ToString() == IdDetalle_Servicio.ToString());
            return dellateServ;
        }

        public string Eliminar()
        {
            try
            {
                Detalle_Servicio dellateServ = Consultar(Detalle_Servicio.ID_Detalle_Servicio.ToString());
                if (dellateServ == null)
                {
                    return "El servicio no existe";
                }
                ITM_Ventas.Detalle_Servicio.Remove(dellateServ);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el servicio exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Detalle_Servicio> ConsultarTodos()
        {
            return ITM_Ventas.Detalle_Servicio.ToList();
        }
    }
}