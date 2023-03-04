using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ILoginRepository
    {
        Task<MdUsuario> ValidateUser(string Usuario, string password);
    }
}
