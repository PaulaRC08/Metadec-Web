using BE_Metadec.Domain.Models;

namespace BE_Metadec.Domain.IServices
{
    public interface ILoginService
    {
        Task<MD_Usuario> ValidateUser(string Usuario, string password);
    }
}
