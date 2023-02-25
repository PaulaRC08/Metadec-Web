using BE_Metadec.Domain.Models;

namespace BE_Metadec.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(MD_Usuario usuario);
        Task<bool> ValidateExistence(MD_Usuario usuario);
        Task<MD_Usuario> ValidarPassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(MD_Usuario usuario);
    }
}
