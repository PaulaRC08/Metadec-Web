using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ISesionRepository
    {
        Task saveSesion(MdSesion mdSesion);
        Task<bool> ValidateExistence(MdSesion mdSesion);
    }

}
