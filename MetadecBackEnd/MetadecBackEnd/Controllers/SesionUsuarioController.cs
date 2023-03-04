using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionUsuarioController : ControllerBase
    {
        private readonly ISesionUsuarioRepository _sesionUsuarioRepository;

        public SesionUsuarioController(ISesionUsuarioRepository sesionUsuarioRepository)
        {
            _sesionUsuarioRepository = sesionUsuarioRepository;

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idDocente = JwtConfigurator.GetTokenIdUsuario(identity);

                var ListaSesiones =await _sesionUsuarioRepository.listSesionesDocente(idDocente);
                foreach (var item in ListaSesiones)
                {
                    item.IdSesionNavigation.Password = Encriptar.DesencriptarPasswordSesion(item.IdSesionNavigation.Password);
                }
                return Ok(ListaSesiones);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SesionUsuarioDTO sesionUsuario)
        {
            try
            {
                await _sesionUsuarioRepository.saveSesionUsuarios(sesionUsuario);
                return Ok("Usuarios Registrados en Sesion");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
