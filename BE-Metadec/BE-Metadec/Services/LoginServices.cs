using BE_Metadec.Domain.IRepositories;
using BE_Metadec.Domain.IServices;
using BE_Metadec.Domain.Models;

namespace BE_Metadec.Services
{
    public class LoginServices: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginServices(ILoginRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }

        public async Task<MD_Usuario> ValidateUser(string Usuario, string password)
        {
            return await _loginRepository.ValidateUser(Usuario,password);
        }
    }
}
