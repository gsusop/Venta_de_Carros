using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsProveedor
    {
        private VentaDeCarrosTallerEntities2 ITM_Ventas = new VentaDeCarrosTallerEntities2();
        public Proveedor Proveedor { get; set; }

        public List<Proveedor> ConsultarTodos()
        {
            return ITM_Ventas.Proveedores.ToList();
        }

        public string Insertar()
        {
            ITM_Ventas.Proveedores.Add(Proveedor);
            ITM_Ventas.SaveChanges();
            return "Proveedor Insertado exitosamente";
        }

        public string Actualizar()
        {
            Proveedor proveedor = Consultar(Proveedor.ID_Proveedor.ToString());
            if (proveedor == null)
            {
                return "El Proveedor no existe";
            }
            ITM_Ventas.Proveedores.AddOrUpdate(Proveedor);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Proveedor Consultar(string idproveedro)
        {
            Proveedor proveedor = ITM_Ventas.Proveedores.FirstOrDefault(e => e.ID_Proveedor.ToString() == idproveedro.ToString());
            return proveedor;
        }

        public string Eliminar()
        {
            try
            {
                Proveedor proveedor = Consultar(Proveedor.ID_Proveedor.ToString());
                if (proveedor == null)
                {
                    return "El proveedor no existe";
                }
                ITM_Ventas.Proveedores.Remove(proveedor);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el proveedor exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}