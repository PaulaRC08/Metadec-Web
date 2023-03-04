using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IInstitucionProgramaRepository
    {
        Task<List<MdInstitucionPrograma>> GetProgramasInstitucion(int idInstitucion);
    }
}
