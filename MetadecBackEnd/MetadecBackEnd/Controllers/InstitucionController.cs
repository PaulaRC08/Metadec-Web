using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionController : ControllerBase
    {

        private readonly IInstitucionRepository _institucionRepository;

        public InstitucionController(IInstitucionRepository institucionRepository)
        {
            _institucionRepository = institucionRepository;
        }

        [Route("GetListInsti")]
        [HttpGet]
        public async Task<IActionResult> GetListInstitucion()
        {
            try
            {
                var listInstituciones = await _institucionRepository.GetInstituciones();
                return Ok(listInstituciones);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
