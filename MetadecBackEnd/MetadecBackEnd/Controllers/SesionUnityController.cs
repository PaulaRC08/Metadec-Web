using MetadecBackEnd.Domain.IRepository;
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
    public class SesionUnityController : ControllerBase
    {
        private readonly ISesionUnityRepository _sesionUnityRepository;

        public SesionUnityController(ISesionUnityRepository sesionUnityRepository)
        {
            _sesionUnityRepository = sesionUnityRepository;

        }

        [HttpGet("{idDocente}")]
        public async Task<IActionResult> Get(int idDocente)
        {
            try
            {
                var ListaSesiones = await _sesionUnityRepository.listSesionesDocente(idDocente);
                if (ListaSesiones == null)
                {
                    return Ok("Sin Sesiones Programadas");
                }
                else
                {
                    ListSesionesDTO listDTOSesion = new ListSesionesDTO();
                    foreach (var item in ListaSesiones)
                    {
                        SesionUnityDTO sesionDTO = new SesionUnityDTO();
                        sesionDTO.Clase = item.IdSesionNavigation.Clase;
                        sesionDTO.CodigoSesion = item.IdSesionNavigation.CodigoSesion;
                        sesionDTO.Password = Encriptar.DesencriptarPasswordSesion(item.IdSesionNavigation.Password);
                        sesionDTO.FechaSesion = item.IdSesionNavigation.FechaSesion.ToShortDateString();
                        sesionDTO.IdSesion = item.IdSesion;
                        listDTOSesion.sesiones.Add(sesionDTO);
                    }
                    
                    return Ok(listDTOSesion);
                }  
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            try
            {
                var password = Encriptar.EncriptarPasswordSesion(login.password);
                var user = await _sesionUnityRepository.ValidateSesion(login.usuario, password);
                if (user == null)
                {
                    return Ok("Datos incorrectos");
                }
                return Ok("Ingreso Correctamente");
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [Route("desactivarSesion/{idSesion}")]
        [HttpGet]
        public async Task<IActionResult> CambiarPassword(int idSesion)
        {
            try
            {
                var sesion = await _sesionUnityRepository.updateSesionActive(idSesion);
                if (sesion == null)
                {
                    return Ok("Error");
                }
                else
                {
                    return Ok("Sesion Desactivada");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
