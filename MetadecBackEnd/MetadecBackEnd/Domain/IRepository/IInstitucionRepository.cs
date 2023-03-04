using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IInstitucionRepository
    {
        Task<List<MdInstitucion>> GetInstituciones();
    }
}
