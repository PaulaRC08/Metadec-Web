using BE_Metadec.Domain.IRepositories;
using BE_Metadec.Domain.Models;
using BE_Metadec.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BE_Metadec.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly MetadecDbContext _context;
        public UsuarioRepository(MetadecDbContext context) 
        { 
            _context = context;
        }
        public async Task SaveUser(MD_Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();

        }

        public async Task UpdatePassword(MD_Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<MD_Usuario> ValidarPassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuario.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<bool> ValidateExistence(MD_Usuario usuario)
        {
            var validateExistence = await _context.Usuario.AnyAsync(x => x.Usuario == usuario.Usuario);
            return validateExistence;
        }
    }
}
