using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using MetadecBackEnd.Persistence.Repositories;
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

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> GetPaises(int idUsuario)
        {
            try
            {
                var list = await _sesionUsuarioRepository.listaPaises(idUsuario);

                if (list == null)
                {
                    return Ok("Sin Sesiones Realizadas");
                }
                var result = list.GroupBy(n => n)
                    .Select(c => new { Pais = c.Key, total = c.Count() }).Take(5);
                return Ok(result);
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
        [Route("sesiones/{idUsuario}")]
        [HttpGet]
        public async Task<IActionResult> Get(int idUsuario)
        {
            try
            {
                var ListaSesiones = await _sesionUsuarioRepository.listSesionesActivas(idUsuario);
                if (ListaSesiones == null)
                {
                    return Ok("Sin Sesiones Terminadas");
                }
                else
                {
                    List<SesionesUsuarioDTO> listDTOSesion = new List<SesionesUsuarioDTO>();
                    foreach (var item in ListaSesiones)
                    {
                        SesionesUsuarioDTO sesionDTO = new SesionesUsuarioDTO();
                        sesionDTO.Clase = item.IdSesionNavigation.Clase;
                        sesionDTO.FechaSesion = item.IdSesionNavigation.FechaSesion.ToShortDateString().ToString();
                        sesionDTO.NumeroJugadores = item.IdSesionNavigation.MdSesionUsuarios.Count();
                        listDTOSesion.Add(sesionDTO);
                    }

                    return Ok(listDTOSesion);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
