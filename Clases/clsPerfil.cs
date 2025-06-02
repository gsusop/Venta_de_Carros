using Plantilla.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Plantilla.Clases
{
    public class clsPerfil
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados

        public Perfil perfil { get; set; }// permite manipular o acceder a los atributos de la tabla perfil

        public string Insertar()
        {
            try
            {
                ITM_Ventas.Perfil.Add(perfil);
                ITM_Ventas.SaveChanges();
                return "Perfil Registrado";
            }
            catch (Exception ex)
            {
                return "Error al insertar Perfil: " + ex.Message;
            }
        }

        public string Eliminar()
        {
            try
            {
                Perfil usu = Consultar(perfil.id);
                if (usu == null)
                {
                    return "el Perfil no existe";
                }
                ITM_Ventas.Perfil.Remove(usu);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el Perfil exitosamente";
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
                Perfil usa = Consultar(perfil.id);
                if (usa == null)
                {

                    return "El Perfil no es valido";
                }
                ITM_Ventas.Perfil.AddOrUpdate(perfil);
                ITM_Ventas.SaveChanges();
                return "Se actualizo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Perfil Consultar(int Perfils)
        {
                Perfil u = ITM_Ventas.Perfil.FirstOrDefault(v => v.id == Perfils);
                return u;
            
        }

        public List<Perfil> ConsultarTodos()
        {
            return ITM_Ventas.Perfil.ToList();
        }
    }
}
