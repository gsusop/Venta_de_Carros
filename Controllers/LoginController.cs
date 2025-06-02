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
    [EnableCors(origins: "*", headers:"*",methods:"*")]
    [RoutePrefix("api/Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]

        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            clsLogin _Login = new clsLogin();
            _Login.login = login;
            return _Login.Ingresar();
        }
    }
}