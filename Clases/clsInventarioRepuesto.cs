using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
	public class clsInventarioRepuesto
	{
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); 
        public Inventario_Repuesto Inventario_Repuesto { get; set; }

        public List<Inventario_Repuesto> ConsultarTodos()
        {
            try
            {
                return ITM_Ventas.Inventario_Repuesto.ToList(); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar el inventario: {ex.Message}");
                return new List<Inventario_Repuesto>();
            }
        }

        public Inventario_Repuesto Consultar(string IdRepuesto)
        {
            Inventario_Repuesto invRep = ITM_Ventas.Inventario_Repuesto.FirstOrDefault(e => e.ID_Repuesto.ToString() == IdRepuesto.ToString());
            return invRep;
        }

        public string Insertar()
        {
            ITM_Ventas.Inventario_Repuesto.Add(Inventario_Repuesto);
            ITM_Ventas.SaveChanges();
            return "Inventario Insertada exitosamente";
        }

        public string Actualizar()
        {
            Inventario_Repuesto invRep = Consultar(Inventario_Repuesto.ID_Repuesto.ToString());
            if (invRep == null)
            {
                return "El inventario no existe";
            }
            ITM_Ventas.Inventario_Repuesto.AddOrUpdate(Inventario_Repuesto);
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }

        public string Eliminar()
        {
            try
            {
                Inventario_Repuesto invRep = Consultar(Inventario_Repuesto.ID_Repuesto.ToString());
                if (invRep == null)
                {
                    return "el inventario no existe";
                }
                ITM_Ventas.Inventario_Repuesto.Remove(invRep);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el inventario exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}


    
        

       

