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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IReporteRepository _repoteRepository;
        private readonly ILoginUnityRepository _loginUnityRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository,
                                 ILoginUnityRepository loginUnityRepository,
                                 IReporteRepository reporteRepository)
        {
            _loginUnityRepository = loginUnityRepository;
            _usuarioRepository = usuarioRepository;
            _repoteRepository = reporteRepository;
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
                    return Ok(new { message = "Usuario ya existe" });
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

        [HttpGet("{idUsuario}")]
        public async Task<IActionResult> Get(int idUsuario)
        {
            try
            {
                var usuario = _usuarioRepository.getUsuarioById(idUsuario);
                UserResum userDTO= new UserResum();
                userDTO.NombreCompleto = usuario.Result.Nombres + " " + usuario.Result.Apellidos;
                userDTO.AvatarUrl = usuario.Result.AvatarUrl;
                userDTO.Sexo =  usuario.Result.Sexo;
                userDTO.Correo = usuario.Result.Correo;
                userDTO.Pais = usuario.Result.IdPaisNavigation.Pais;
                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("reportes/{idUser}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetReport(int idUser)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                idUser = JwtConfigurator.GetTokenIdUsuario(identity);

                var reporte = await _loginUnityRepository.ValidateReport(idUser);
                if (reporte != null)
                {
                    if (reporte.Penalizacion != "Bloquear Micro" && reporte.Penalizacion != "Expulsar Sala")
                    {
                        DateTime fechaLimite = reporte.FechaReporte.Value.AddDays(int.Parse(reporte.Penalizacion.Substring(0, 1)));
                        if (fechaLimite >= DateTime.Now)
                        {
                            
                            ReporteDTO reportedto = new ReporteDTO();
                            reportedto.FechaReporte = reporte.FechaReporte.Value.ToShortDateString();
                            reportedto.FechaFin = fechaLimite.ToShortDateString();
                            reportedto.ComunicacionOfensiva = reporte.ComunicacionOfensiva;
                            reportedto.NombreOfensivo = reporte.NombreOfensivo;
                            reportedto.ComportIrrespetuoso = reporte.ComportIrrespetuoso;
                            reportedto.Amenaza = reporte.Amenaza;
                            return Ok(reportedto);
                        }
                        else
                        {
                            _repoteRepository.updateReporte(reporte);
                            return Ok(false);
                        }
                    }
                }

                return Ok(false);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

            // localhost:xxx/api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
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
                    return Ok(new { message = "La password es incrorrecta" });
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
