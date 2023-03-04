using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.DTO
{
    public class HipervinculoDTO
    {
        public string NombreHipervinculo { get; set; } = null!;

        public string UrlHpervinculo { get; set; } = null!;

        public string TipoHipervinculo { get; set; } = null!;
    }

    public class ListHipervinculosDTO
    {
        public List<HipervinculoDTO> hipervinculosDTO { get; set; } = new List<HipervinculoDTO>();
    }
}
