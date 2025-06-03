using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Venta_de_Carros.Clases;
using Venta_de_Carros.Models;

namespace Venta_de_Carros.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    [Authorize]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("CrearUsuario")]

        public string CrearUsuario([FromBody] Usuario usuario, int idPerfil)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.CrearUsuario(idPerfil);
        }
    }
}