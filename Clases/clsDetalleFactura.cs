using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsDetalleFactura
    {
        private VentaDeCarrosTallerEntities2 ITM_Ventas = new VentaDeCarrosTallerEntities2();
        public Detalle_Factura Detalle_Factura { get; set; }
        public string Insertar()
        {
            ITM_Ventas.Detalles_Facturas.Add(Detalle_Factura);
            ITM_Ventas.SaveChanges();
            return "Factura Insertada exitosamente";
        }

        public string Actualizar()
        {
            Detalle_Factura dellateFact = Consultar(Detalle_Factura.ID_Detalle_Factura.ToString());
            if (dellateFact == null)
            {
                return "El detalle de la factura no existe";
            }
            ITM_Ventas.Detalles_Facturas.AddOrUpdate(Detalle_Factura);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Detalle_Factura Consultar(string IdDetalle_Factura)
        {
            Detalle_Factura dellateFact = ITM_Ventas.Detalles_Facturas.FirstOrDefault(e => e.ID_Detalle_Factura.ToString() == IdDetalle_Factura.ToString());
            return dellateFact;
        }

        public string Eliminar()
        {
            try
            {
                Detalle_Factura dellateFact = Consultar(Detalle_Factura.ID_Detalle_Factura.ToString());
                if (dellateFact == null)
                {
                    return "La factura no existe";
                }
                ITM_Ventas.Detalles_Facturas.Remove(dellateFact);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la factura exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Detalle_Factura> ConsultarTodos()
        {
            return ITM_Ventas.Detalles_Facturas.ToList();
        }
    }
}