using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.Persistence.Repositories;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteRepository _estudianteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public EstudianteController(IEstudianteRepository estudianteRepository,
                                    IUsuarioRepository usuarioRepository)
        {
            _estudianteRepository = estudianteRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MdEstudiante estudiante)
        {
            try
            {
                var validateExistence = await _usuarioRepository.ValidateExistence(estudiante.IdUsuarioNavigation);
                if (validateExistence)
                {
                    return Ok(new { message = "Usuario ya existe" });
                }
                estudiante.IdUsuarioNavigation.Pasword = Encriptar.EncriptarPassword(estudiante.IdUsuarioNavigation.Pasword);

                await _estudianteRepository.saveEstudiante(estudiante);
                return Ok(new { message = "Estudiante Registrado Exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
