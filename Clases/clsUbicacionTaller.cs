using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsUbicaciones_Taller
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        public Ubicaciones_Taller Ubicaciones_Taller { get; set; }// permite manipular o acceder a los atributos de la tabla Ubicaciones_Taller
        public string Insertar()
        {
            ITM_Ventas.Ubicaciones_Taller.Add(Ubicaciones_Taller);// agrega un nuevo Taller a la tabla Ubicaciones_Taller (INsert Into)
            ITM_Ventas.SaveChanges();//Guarda los cambios en la BD
            return "Taller Insertado exitosamente";//Mensaje de confirmaion
        }

        public string Actualizar()
        {
            Ubicaciones_Taller ubt = Consultar(Ubicaciones_Taller.Nombre_Ubicacion);
            if (ubt == null)
            {
                return "EL Taller no existe";
            }
            ITM_Ventas.Ubicaciones_Taller.AddOrUpdate(Ubicaciones_Taller);//Actualiza un Ubicaciones_Taller en la tabla Ubicaciones_Taller
            ITM_Ventas.SaveChanges();
            return "Se actualizó el Taller correctamente";
        }
        public Ubicaciones_Taller Consultar(string Nombre)
        {
            Ubicaciones_Taller ubt = ITM_Ventas.Ubicaciones_Taller.FirstOrDefault(ut => ut.Nombre_Ubicacion == Nombre);//consulta un Ubicaciones_Taller por su documento
            return ubt;
        }

        public string Eliminar()
        {
            try
            {
                Ubicaciones_Taller ubt = Consultar(Ubicaciones_Taller.Nombre_Ubicacion);
                if (ubt == null)
                {
                    return "EL Ubicaciones_Taller no existe";
                }
                ITM_Ventas.Ubicaciones_Taller.Remove(ubt);//Elimina un Taller de la tabla Ubicaciones_Taller
                ITM_Ventas.SaveChanges();//GUarda los cambios
                return "Se eliminó el Taller exitosamente";// Mensaje de confirmacion
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Ubicaciones_Taller> ConsultarTodos()
        {
            return ITM_Ventas.Ubicaciones_Taller.ToList();
        }

    }
}