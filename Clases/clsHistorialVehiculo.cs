using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsHistorialVehiculo
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities();
        public Historial_Vehiculo Historial_Vehiculo { get; set; }


        public List<Historial_Vehiculo> ConsultarTodos()
        {
            return ITM_Ventas.Historial_Vehiculo.ToList();
        }


        public string Insertar()
        {
            ITM_Ventas.Historial_Vehiculo.Add(Historial_Vehiculo);
            ITM_Ventas.SaveChanges();
            return "Historial Insertado exitosamente";
        }

        public string Actualizar()
        {
            Historial_Vehiculo histoVeh = Consultar(Historial_Vehiculo.ID_Historial.ToString());
            if (histoVeh == null)
            {
                return "El historial no existe";
            }
            ITM_Ventas.Historial_Vehiculo.AddOrUpdate(Historial_Vehiculo);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Historial_Vehiculo Consultar(string idHistorial)
        {
            Historial_Vehiculo histVeh = ITM_Ventas.Historial_Vehiculo.FirstOrDefault(e => e.ID_Historial.ToString() == idHistorial.ToString());
            return histVeh;
        }

        public string Eliminar()
        {
            try
            {
                Historial_Vehiculo detaVehi = Consultar(Historial_Vehiculo.ID_Historial.ToString());
                if (detaVehi == null)
                {
                    return "El historial no existe";
                }
                ITM_Ventas.Historial_Vehiculo.Remove(detaVehi);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el historial exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }   
}
