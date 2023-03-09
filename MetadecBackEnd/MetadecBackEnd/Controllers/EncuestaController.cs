using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {

        private readonly IEncuestaRepository _encuestaRepository;
        public EncuestaController(IEncuestaRepository encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EncuestaDTO encuesta)
        {
            try
            {
                var encuestaReg = await _encuestaRepository.SaveEncuesta(encuesta);
                return Ok(encuestaReg);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var encuestaReg = await _encuestaRepository.resultadosEncuesta();
                return Ok(encuestaReg);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
