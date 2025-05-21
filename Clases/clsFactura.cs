using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsFactura
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        public Factura Factura { get; set; }
        public string Insertar()
        {
            ITM_Ventas.Facturas.Add(Factura);
            ITM_Ventas.SaveChanges();
            return "Factura Insertada exitosamente";
        }

        public string Actualizar()
        {
            Factura fact = Consultar(Factura.ID_Factura.ToString());
            if (fact == null)
            {
                return "La factura no existe";
            }
            ITM_Ventas.Facturas.AddOrUpdate(Factura);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Factura Consultar(string IdFactura)
        {
            Factura fact = ITM_Ventas.Facturas.FirstOrDefault(e => e.ID_Factura.ToString() == IdFactura.ToString());
            return fact;
        }

        public string Eliminar()
        {
            try
            {
                Factura fact = Consultar(Factura.ID_Factura.ToString());
                if (fact == null)
                {
                    return "La factura no existe";
                }
                ITM_Ventas.Facturas.Remove(fact);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la factura exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Factura> ConsultarTodos()
        {
            return ITM_Ventas.Facturas.ToList();
        }
    }
}