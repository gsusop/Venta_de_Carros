using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsGarantia
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1();
        public Garantia Garantia { get; set; }

        public string Insertar()
        {
            ITM_Ventas.Garantias.Add(Garantia);
            ITM_Ventas.SaveChanges();
            return "Garantia Insertada exitosamente";
        }

        public string Actualizar()
        {
            Garantia gr = Consultar(Garantia.ID_Garantia.ToString());
            if (gr == null)
            {
                return "La garantia no existe";
            }
            ITM_Ventas.Garantias.AddOrUpdate(Garantia);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public Garantia Consultar(string IdGarantia)
        {
            Garantia gr = ITM_Ventas.Garantias.FirstOrDefault(e => e.ID_Garantia.ToString() == IdGarantia.ToString());
            return gr;
        }

        public string Eliminar()
        {
            try
            {
                Garantia gr = Consultar(Garantia.ID_Garantia.ToString());
                if (gr == null)
                {
                    return "La garantia no existe";
                }
                ITM_Ventas.Garantias.Remove(gr);
                ITM_Ventas.SaveChanges();
                return "Se eliminó la garantia exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Garantia> ConsultarTodos()
        {
            return ITM_Ventas.Garantias.ToList();
        }
    }
}