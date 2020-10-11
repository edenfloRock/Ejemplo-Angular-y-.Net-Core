using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WS_VENTAS.Models.Request;
using WS_VENTAS.Models.Response;
using WS_VENTAS.Services;

namespace WS_VENTAS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        //COMO YA ESTÁ INYECTADA, SE PUEDE OBTENER
        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autenticar([FromBody] AuthRequest model) {
            Respuesta respuesta = new Respuesta();

            // se utiliza la inyeccion
            var userResp = _userService.Auth(model);

            if (userResp == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o Contraseña incorrecta!";
                return BadRequest(respuesta);
            }
            else {
                respuesta.Exito = 1;
                respuesta.Data = userResp;
            }

                
                
            return Ok(model);
        }
    }
}
