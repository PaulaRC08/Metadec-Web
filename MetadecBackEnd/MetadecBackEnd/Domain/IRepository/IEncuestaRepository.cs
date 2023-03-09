using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IEncuestaRepository
    {
        Task<MdEncuestum> SaveEncuesta(EncuestaDTO encuesta);

        Task<EncuestaAdminDTO> resultadosEncuesta();
    }
}
