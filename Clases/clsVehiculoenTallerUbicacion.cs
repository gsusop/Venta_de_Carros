using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Plantilla.Clases
{
    public class clsVehiculoenTallerUbicacion
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados

        public Vehiculo_en_Taller_Ubicacion vehiculoEnTallerUbicacion { get; set; }// permite manipular o acceder a los atributos de la tabla Venta de carros

        public string Insertar()
        {
            try
            {
                ITM_Ventas.Vehiculo_en_Taller_Ubicacion.Add(vehiculoEnTallerUbicacion);
                ITM_Ventas.SaveChanges();
                return "Vehiculo en Taller Registrado";
            }
            catch (Exception ex)
            {
                return "Error al insertar vehiculo: " + ex.Message;
            }
        }


        public string Eliminar()
        {
            try
            {
                Vehiculo_en_Taller_Ubicacion vehiTaller = Consultar(vehiculoEnTallerUbicacion.ID_Vehiculo_Ubicacion);
                if (vehiTaller == null)
                {
                    return "el vehiculo en taller no existe";
                }
                ITM_Ventas.Vehiculo_en_Taller_Ubicacion.Remove(vehiTaller);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el vehiculo en taller exitosamente";
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
                Vehiculo_en_Taller_Ubicacion veh = Consultar(vehiculoEnTallerUbicacion.ID_Vehiculo_Ubicacion);
                if (veh == null)
                {
                    return "El vehiculo no es valido";
                }
                ITM_Ventas.Vehiculo_en_Taller_Ubicacion.AddOrUpdate(vehiculoEnTallerUbicacion);
                ITM_Ventas.SaveChanges();
                return "Se actualizo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Vehiculo_en_Taller_Ubicacion Consultar(int VehiculoTaller)
        {
            Vehiculo_en_Taller_Ubicacion veh1 = ITM_Ventas.Vehiculo_en_Taller_Ubicacion.FirstOrDefault(v => v.ID_Vehiculo_Ubicacion == VehiculoTaller);
            return veh1;
        }

        public List<Vehiculo_en_Taller_Ubicacion> ConsultarTodos()
        {
            return ITM_Ventas.Vehiculo_en_Taller_Ubicacion.ToList();
        }
    }
}
