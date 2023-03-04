using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IHipervinculoRepository
    {
        Task<List<MdHipervinculo>> getHiprtvinculosSesion(int idSesion);
    }
}
