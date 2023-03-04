using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.DTO;
using MetadecBackEnd.Persistence.Repositories;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUnityController : ControllerBase
    {

        private readonly ILoginUnityRepository _loginUnityRepository;
        private readonly IReporteRepository _repoteRepository;

        public LoginUnityController(ILoginUnityRepository loginUnityRepository,
                                    IReporteRepository reporteRepository)
        {
            _loginUnityRepository = loginUnityRepository;
            _repoteRepository = reporteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            try
            {
                var password = Encriptar.EncriptarPassword(login.password);
                var user = await _loginUnityRepository.ValidateUser(login.usuario, password);
                
                if (user == null)
                {
                    return Ok("Datos incorrectos");
                }
                var reporte = await _loginUnityRepository.ValidateReport(user.idUsuario);
                if (reporte != null)
                {
                    if (reporte.Penalizacion != "Bloquear Micro" && reporte.Penalizacion != "Expulsar Sala")
                    {
                        DateTime fechaLimite = reporte.FechaReporte.Value.AddDays(int.Parse(reporte.Penalizacion.Substring(0, 1)));
                        if (fechaLimite >= DateTime.Now)
                        {
                            return Ok("Reporte Activo");
                        }
                        else
                        {
                            _repoteRepository.updateReporte(reporte);
                        }
                    }
                }
                
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}
