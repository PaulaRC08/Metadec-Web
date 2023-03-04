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
    public class DocenteController : ControllerBase
    {
        private readonly IDocenteRepository _docenteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public DocenteController(IDocenteRepository docenteRepository,
                                    IUsuarioRepository usuarioRepository)
        {
            _docenteRepository = docenteRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MdDocente docente)
        {
            try
            {
                var validateExistence = await _usuarioRepository.ValidateExistence(docente.IdUsuarioNavigation);
                if (validateExistence)
                {
                    return BadRequest(new { message = "Usuario " + docente.IdUsuarioNavigation.Usuario + " ya existe" });
                }
                docente.IdUsuarioNavigation.Pasword = Encriptar.EncriptarPassword(docente.IdUsuarioNavigation.Pasword);

                await _docenteRepository.saveDocente(docente);
                return Ok(new { message = "Docente Registrado Exitosamente" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
