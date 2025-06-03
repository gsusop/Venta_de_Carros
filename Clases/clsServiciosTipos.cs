using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Plantilla.Clases
{
    public class clsServiciosTipos
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados

        public Servicios_Tipos ST { get; set; }// permite manipular o acceder a los atributos de la tabla servicios tipos

        public string Insertar()
        {
            try
            {
                ITM_Ventas.Servicios_Tipos.Add(ST);
                ITM_Ventas.SaveChanges();
                return "Tipo de Servicio Registrado";
            }
            catch (Exception ex)
            {
                return "Error al insertar Tipo de Servicio: " + ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Servicios_Tipos usu = Consultar(ST.ID_Servicio_Tipo);
                if (usu == null)
                {
                    return "el tipo de servicio no existe";
                }
                ITM_Ventas.Servicios_Tipos.Remove(usu);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el tipo de servicio exitosamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Servicios_Tipos usa = Consultar(ST.ID_Servicio_Tipo);
                if (usa == null)
                {
                    return "El tipo de servicio no es valido";
                }
                ITM_Ventas.Servicios_Tipos.AddOrUpdate(ST);
                ITM_Ventas.SaveChanges();
                return "Se actualizo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Servicios_Tipos Consultar(int ServiceType)
        {
      
                Servicios_Tipos u = ITM_Ventas.Servicios_Tipos.FirstOrDefault(v => v.ID_Servicio_Tipo == ServiceType);
                return u;
                      
        }

        public List<Servicios_Tipos> ConsultarTodos()
        {
            return ITM_Ventas.Servicios_Tipos.ToList();
        }
    }
}
