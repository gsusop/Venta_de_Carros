using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsEmpleado
    {
        private VentaDeCarrosTallerEntities1 ITM_Ventas = new VentaDeCarrosTallerEntities1(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados
        public Empleado Empleado { get; set; }// permite manipular o acceder a los atributos de la tabla Empleado
        public string Insertar()
        {
            ITM_Ventas.Empleados.Add(Empleado);// agrega un nuevo empleado a la tabla EMPLEADO (INsert Into)
            ITM_Ventas.SaveChanges();//Guarda los cambios en la BD
            return "Empleado Insertado exitosamente";//Mensaje de confirmaion
        }

        public string Actualizar()
        {
            Empleado emp = Consultar(Empleado.Numero_Documento);
            if (emp == null)
            {
                return "EL documento no existe";
            }
            ITM_Ventas.Empleados.AddOrUpdate(Empleado);//Actualiza un empleado en la tabla EMPLEADO
            ITM_Ventas.SaveChanges();
            return "Se actualizó correctamente";
        }
        public Empleado Consultar(string Documento)
        {
            Empleado emp = ITM_Ventas.Empleados.FirstOrDefault(e => e.Numero_Documento == Documento);//consulta un Empleado por su documento
            return emp;
        }

        public string Eliminar()
        {
            try
            {
                Empleado emp = Consultar(Empleado.Numero_Documento);
                if (emp == null)
                {
                    return "EL documento no existe";
                }
                ITM_Ventas.Empleados.Remove(emp);//Elimina un Empleado de la tabla Empleado
                ITM_Ventas.SaveChanges();//GUarda los cambios
                return "Se eliminó el Empleado exitosamente";// Mensaje de confirmacion
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Empleado> ConsultarTodos()
        {
            return ITM_Ventas.Empleados.ToList();
        }

    }
}