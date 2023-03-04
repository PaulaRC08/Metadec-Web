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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MdUsuario usuario)
        {
            try
            {

                usuario.FechaCreacion = DateTime.Now;
                var validateExistence = await _usuarioRepository.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "Usuario " + usuario.Usuario + " ya existe" });
                }
                usuario.Pasword = Encriptar.EncriptarPassword(usuario.Pasword);
                var usuarioRegistrado = await _usuarioRepository.SaveUser(usuario);
                return Ok(usuarioRegistrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // localhost:xxx/api/Usuario/CambiarPassword
        [Route("CambiarPassowrd")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;

                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);


                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _usuarioRepository.ValidarPassword(idUsuario, passwordEncriptado);
                if (usuario == null)
                {
                    return BadRequest(new { message = "La password es incrorrecta" });
                }
                else
                {
                    usuario.Pasword = Encriptar.EncriptarPassword(cambiarPassword.passwordNueva);
                    await _usuarioRepository.UpdatePassword(usuario);
                    return Ok(new { message = "La password fue actualizada con exito!" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
