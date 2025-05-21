using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsVehiculo
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        public Vehiculo Vehiculo { get; set; }// permite manipular o acceder a los atributos de la tabla Vehiculo
        public string Insertar()
        {
            ITM_Ventas.Vehiculos.Add(Vehiculo);// agrega un nuevo Vehiculo a la tabla Vehiculo (INsert Into)
            ITM_Ventas.SaveChanges();//Guarda los cambios en la BD
            return "Vehiculo Insertado exitosamente";//Mensaje de confirmaion
        }

        public string Actualizar()
        {
            Vehiculo veh = Consultar(Vehiculo.Placa);
            if (veh == null)
            {
                return "EL documento no existe";
            }
            ITM_Ventas.Vehiculos.AddOrUpdate(Vehiculo);//Actualiza un vehiculo en la tabla Vehiculo
            ITM_Ventas.SaveChanges();
            return "Se actualizó el vehiculo correctamente";
        }
        public Vehiculo Consultar(string Placa)
        {
            Vehiculo veh = ITM_Ventas.Vehiculos.FirstOrDefault(v => v.Placa == Placa);//consulta un Vehiculo por su documento
            return veh;
        }

        public string Eliminar()
        {
            try
            {
                Vehiculo veh = Consultar(Vehiculo.Placa);
                if (veh == null)
                {
                    return "EL Vehiculo no existe";
                }
                ITM_Ventas.Vehiculos.Remove(veh);//Elimina un Vehiculo de la tabla Vehiculo
                ITM_Ventas.SaveChanges();//GUarda los cambios
                return "Se eliminó el Vehiculo exitosamente";// Mensaje de confirmacion
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Vehiculo> ConsultarTodos()
        {
            return ITM_Ventas.Vehiculos.ToList();
        }

    }
}