using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ILoginUnityRepository
    {
        Task<LoginUnityDTO> ValidateUser(string Usuario, string password);
        Task<MdReporte> ValidateReport(int idUsuario);
    }
}
