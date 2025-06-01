using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
	public class clsDetalleRepuestoOrden
	{
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities();

        public Detalle_Repuestos_Orden Detalle_Repuestos_Orden { get; set; }

        public string Insertar()
        {
            ITM_Ventas.Detalle_Repuestos_Orden.Add(Detalle_Repuestos_Orden);
            ITM_Ventas.SaveChanges();
            return "Detalle de repuesto insertado exitosamente";
        }

        public string Actualizar()
        {
            Detalle_Repuestos_Orden detRepuOrd = Consultar(Detalle_Repuestos_Orden.ID_Detalle_Repuesto.ToString());
            if (detRepuOrd == null)
            {
                return "El detalle del repuesto no existe";
            }
            ITM_Ventas.Detalle_Repuestos_Orden.AddOrUpdate(Detalle_Repuestos_Orden);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public List<Detalle_Repuestos_Orden> ConsultarTodos()
        {
            return ITM_Ventas.Detalle_Repuestos_Orden.ToList();
        }


        public string Eliminar()
        {
            try
            {
                Detalle_Repuestos_Orden detRepuOrd = Consultar(Detalle_Repuestos_Orden.ID_Detalle_Repuesto.ToString());
                if (detRepuOrd == null)
                {
                    return "El detalle de repuesto orden no existe";
                }
                ITM_Ventas.Detalle_Repuestos_Orden.Remove(detRepuOrd);
                ITM_Ventas.SaveChanges();
                return "Se eliminó El detalle de repuesto orden exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //para actualizar   y eliminar
        public Detalle_Repuestos_Orden Consultar(string IDDetalle_Repuesto)
        {
            Detalle_Repuestos_Orden detRepuOrd = ITM_Ventas.Detalle_Repuestos_Orden.FirstOrDefault(e => e.ID_Detalle_Repuesto.ToString() == IDDetalle_Repuesto.ToString());
            return detRepuOrd;
        }


    }
}


