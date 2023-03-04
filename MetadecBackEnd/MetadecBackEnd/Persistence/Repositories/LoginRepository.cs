using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        
        public readonly MetadecudecContext _context;
        public LoginRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<MdUsuario> ValidateUser(string Usuario, string password)
        {
            var user = await _context.MdUsuarios.Where(x => x.Usuario == Usuario && x.Pasword == password).FirstOrDefaultAsync();
            return user;
        }
    }
}
