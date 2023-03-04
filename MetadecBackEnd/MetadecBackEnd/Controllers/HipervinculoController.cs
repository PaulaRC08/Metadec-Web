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
    public class HipervinculoController : ControllerBase
    {
        private readonly IHipervinculoRepository _hipervinculoRepository;

        public HipervinculoController(IHipervinculoRepository hipervinculoRepository)
        {
            _hipervinculoRepository = hipervinculoRepository;
        }

        [HttpGet("{idSesion}")]
        public async Task<IActionResult> Get(int idSesion)
        {
            try
            {
                var ListaSesiones = await _hipervinculoRepository.getHiprtvinculosSesion(idSesion);

                if (ListaSesiones.Count==0)
                {
                    return Ok("Sin Sesiones Programadas");
                }
                else
                {
                    ListHipervinculosDTO listSesionesDTO = new ListHipervinculosDTO();
                    foreach (var item in ListaSesiones)
                    {
                        HipervinculoDTO hiper = new HipervinculoDTO();
                        hiper.NombreHipervinculo = item.NombreHipervinculo;
                        hiper.UrlHpervinculo = item.UrlHpervinculo;
                        hiper.TipoHipervinculo = item.TipoHipervinculo;
                        listSesionesDTO.hipervinculosDTO.Add(hiper);
                    }
                    return Ok(listSesionesDTO);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
