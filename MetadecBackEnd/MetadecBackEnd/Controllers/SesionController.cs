using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.Persistence.Repositories;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionController(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Post([FromBody] MdSesion sesion)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                foreach (var item in sesion.MdSesionUsuarios)
                {
                    item.IdUsuario = idUsuario;
                }

                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random rnd = new Random();
                var contra="";
                string character = "";
                var claseSplit = sesion.Clase.Split(" ");
                for (int i = 0; i < 6; i++)
                {
                    character += characters[rnd.Next(characters.Length)];
                }
                sesion.CodigoSesion = claseSplit[0] + character;
                for (int i = 0; i < 6; i++)
                {
                    contra = contra + rnd.Next(0, 9) + characters[rnd.Next(characters.Length)];
                }
                sesion.Password = contra;
                sesion.Password = Encriptar.EncriptarPasswordSesion((sesion.Password));
                await _sesionRepository.saveSesion(sesion);
                return Ok(new { message = "Sesion Registrada Exitosamente" });
                //return Ok(sesion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
