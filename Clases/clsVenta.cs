using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
	public class clsVenta
	{
        private VentaDeCarrosTallerEntities2 ITM_Ventas = new VentaDeCarrosTallerEntities2();
        public Venta Venta { get; set; }

        public List<Venta> ConsultarTodos()
        {
            return ITM_Ventas.Ventas.ToList();
        }

        public string Insertar()
        {
            ITM_Ventas.Ventas.Add(Venta);
            ITM_Ventas.SaveChanges();
            return "Venta Insertada exitosamente";
        }

        public string Actualizar()
        {
            Venta venta = Consultar(Venta.ID_Venta.ToString());
            if (venta == null)
            {
                return "El detalle de la factura no existe";
            }
            ITM_Ventas.Ventas.AddOrUpdate(Venta);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Venta Consultar(string idventa)
        {
            Venta venta = ITM_Ventas.Ventas.FirstOrDefault(e => e.ID_Venta.ToString() == idventa.ToString());
            return venta;
        }

        public string Eliminar()
        {
            try
            {
                Venta venta = Consultar(Venta.ID_Venta.ToString());
                if (venta == null)
                {
                    return "La venta no existe";
                }
                ITM_Ventas.Ventas.Remove(venta);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la venta exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}