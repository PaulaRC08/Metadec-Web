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
    public class ReporteController : ControllerBase
    {
        private readonly IReporteRepository _reporteRepository;

        public ReporteController(IReporteRepository reporteRepository)
        {
            _reporteRepository = reporteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MdReporte reporte)
        {

            try
            {
                _reporteRepository.saveReporte(reporte);
                return Ok("Reporte añadido");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
