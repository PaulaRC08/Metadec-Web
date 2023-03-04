using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IPaisRepository
    {
        Task<List<MdPai>> GetPaises();
    }
}
