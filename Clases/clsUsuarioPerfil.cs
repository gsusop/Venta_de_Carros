using Plantilla.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Plantilla.Clases
{
    public class clsUsuarioPerfil
    {
        private VentaDeCarrosTallerEntities ITM_Ventas = new VentaDeCarrosTallerEntities(); // Objeto de la base de datos permite manipular el CRUD de los objetos generados

        public Usuario_Perfil usuariop { get; set; }// permite manipular o acceder a los atributos de la tabla Usuario perfil

        public string Insertar()
        {
            try
            {
                ITM_Ventas.Usuario_Perfil.Add(usuariop);
                ITM_Ventas.SaveChanges();
                return "Perfil de Usuario Registrado";
            }
            catch (Exception ex)
            {
                return "Error al insertar Perfil de Usuario: " + ex.Message;
            }
        }


        public string Eliminar()
        {
            try
            {
                Usuario_Perfil usu = Consultar(usuariop.id);
                if (usu == null)
                {
                    return "el Perfil de Usuario no existe";
                }
                ITM_Ventas.Usuario_Perfil.Remove(usu);
                ITM_Ventas.SaveChanges();
                return "Se eliminó el Perfil de Usuario exitosamente";
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
                Usuario_Perfil usa = Consultar(usuariop.id);
                if (usa == null)
                {
                    return "El Perfil de Usuario no es valido";
                }
                ITM_Ventas.Usuario_Perfil.AddOrUpdate(usuariop);
                ITM_Ventas.SaveChanges();
                return "Se actualizo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Usuario_Perfil Consultar(int User)
        {

                Usuario_Perfil u = ITM_Ventas.Usuario_Perfil.FirstOrDefault(v => v.id == User);
                return u;

        }

        public List<Usuario_Perfil> ConsultarTodos()
        {
            return ITM_Ventas.Usuario_Perfil.ToList();
        }
    }
}
