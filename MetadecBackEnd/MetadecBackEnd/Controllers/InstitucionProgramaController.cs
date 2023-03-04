using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionProgramaController : ControllerBase
    {

        private readonly IInstitucionProgramaRepository _institucionProgramaRepository;

        public InstitucionProgramaController(IInstitucionProgramaRepository institucionProgamaRepository)
        {
            _institucionProgramaRepository = institucionProgamaRepository;
        }

        [HttpGet("{idInstitucion}")]
        public async Task<IActionResult> Get(int idInstitucion)
        {
            try
            {
                var cuestionario = await _institucionProgramaRepository.GetProgramasInstitucion(idInstitucion);
                return Ok(cuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
