using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task<MdUsuario> SaveUser(MdUsuario usuario);
        Task<bool> ValidateExistence(MdUsuario usuario);
        Task<MdUsuario> ValidarPassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(MdUsuario usuario);
    }
}
