using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Plantilla.Clases
{
    public class clsTiposdeServicio
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados

        public Tipos_de_Servicio tps { get; set; }// permite manipular o acceder a los atributos de la tabla Tipos de servicio

        public string Insertar()
        {
            try
            {
                ITM_Ventas.Tipos_de_Servicio.Add(tps);
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
                Tipos_de_Servicio usu = Consultar(tps.ID_Tipo_Servicio);
                if (usu == null)
                {
                    return "el tipo de servicio no existe";
                }
                ITM_Ventas.Tipos_de_Servicio.Remove(usu);
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
                Tipos_de_Servicio usa = Consultar(tps.ID_Tipo_Servicio);
                if (usa == null)
                {
                    return "El tipo de servicio no es valido";
                }
                ITM_Ventas.Tipos_de_Servicio.AddOrUpdate(tps);
                ITM_Ventas.SaveChanges();
                return "Se actualizo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Tipos_de_Servicio Consultar(int ServiceType)
        {
           
            Tipos_de_Servicio u = ITM_Ventas.Tipos_de_Servicio.FirstOrDefault(v => v.ID_Tipo_Servicio == ServiceType);
            return u;
            
        }

        public List<Tipos_de_Servicio> ConsultarTodos()
        {
            return ITM_Ventas.Tipos_de_Servicio.ToList();
        }
    }
}
