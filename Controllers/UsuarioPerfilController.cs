using Plantilla.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Venta_de_Carros.Models;

namespace Plantilla.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
   
    [Authorize]
    [RoutePrefix("api/UsuarioPerfil")]
    public class UsuarioPerfilController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Usuario_Perfil> ConsultarTodos()
        {
            clsUsuarioPerfil Usuario_Perfil = new clsUsuarioPerfil();
            return Usuario_Perfil.ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public Usuario_Perfil Consultar([FromUri] int User)
        {
            clsUsuarioPerfil Usuario_Perfil = new clsUsuarioPerfil();
            return Usuario_Perfil.Consultar(User);
        }


        [HttpPost]
        [Route("Insertar")]
        // POST api/<controller>
        public string Insertar([FromBody] Usuario_Perfil usuariop)
        {
            clsUsuarioPerfil Usuario_Perfil = new clsUsuarioPerfil();
            Usuario_Perfil.usuariop = usuariop;
            return Usuario_Perfil.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        // PUT api/<controller>/5
        public string Actualizar([FromBody] Usuario_Perfil usuariop)
        {
            clsUsuarioPerfil Usuario_Perfil = new clsUsuarioPerfil();
            Usuario_Perfil.usuariop = usuariop;
            return Usuario_Perfil.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        // DELETE api/<controller>/5
        public string Eliminar([FromBody] Usuario_Perfil usuariop)
        {
            clsUsuarioPerfil Usuario_Perfil = new clsUsuarioPerfil();
            Usuario_Perfil.usuariop = usuariop;
            return Usuario_Perfil.Eliminar();
        }

    }
}