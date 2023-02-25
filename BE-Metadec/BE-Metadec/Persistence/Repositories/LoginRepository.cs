using BE_Metadec.Domain.IRepositories;
using BE_Metadec.Domain.Models;
using BE_Metadec.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BE_Metadec.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        public readonly MetadecDbContext _context;
        public LoginRepository(MetadecDbContext context)
        {
            _context = context;
        }

        public async Task<MD_Usuario> ValidateUser(string Usuario, string password)
        {
            var user = await _context.Usuario.Where(x => x.Usuario == Usuario && x.Password == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
