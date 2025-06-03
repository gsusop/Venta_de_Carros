using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Clases
{
    public class clsUsuario
    {
        private VentaDeCarrosTallerEntities2 ITM_Ventas = new VentaDeCarrosTallerEntities2();

        public Usuario usuario { get; set; }

        public string CrearUsuario(int idPerfil)
        {
            //se va a crear el usuario y asignar perfil
            clsCypher cypher = new clsCypher();
            string claveCifrada;
            cypher.Password = usuario.Clave;

            if (cypher.CifrarClave())
            {
                claveCifrada = cypher.PasswordCifrado;
            }
            else
            {
                return "Error al cifrar la clave";
            }
            usuario.Clave = claveCifrada;

            //Graba el usuario
            usuario.Salt = cypher.Salt;
            ITM_Ventas.Usuarios.Add(usuario);
            ITM_Ventas.SaveChanges();

            //Graba el usuario Perfil
            Usuario_Perfil usuarioPerfil = new Usuario_Perfil();
            usuarioPerfil.idUsuario = usuario.id;
            usuarioPerfil.idPerfil = idPerfil;
            usuarioPerfil.Activo = true; //Cuando se crea normalmente, debe ser activo
            ITM_Ventas.Usuarios_Perfiles.Add(usuarioPerfil);
            ITM_Ventas.SaveChanges();

            return "Se creo el usuario exitosamente";

        }

    }
}