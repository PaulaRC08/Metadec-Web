using MetadecBackEnd.Domain.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {

        private readonly IPaisRepository _paisRepository;

        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }

        [Route("GetListPaises")]
        [HttpGet]
        public async Task<IActionResult> GetListPaises()
        {
            try
            {
                var listCuestionario = await _paisRepository.GetPaises();
                return Ok(listCuestionario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
