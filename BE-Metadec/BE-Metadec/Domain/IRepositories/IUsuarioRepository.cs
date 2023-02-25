using BE_Metadec.Domain.Models;

namespace BE_Metadec.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(MD_Usuario usuario);
        Task<bool> ValidateExistence(MD_Usuario usuario);
        Task<MD_Usuario> ValidarPassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(MD_Usuario usuario);
    }
}
