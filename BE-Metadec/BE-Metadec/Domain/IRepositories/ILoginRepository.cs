using BE_Metadec.Domain.Models;

namespace BE_Metadec.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<MD_Usuario> ValidateUser(string Usuario, string password);
    }
}
