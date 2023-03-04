using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        public readonly MetadecudecContext _context;
        public UsuarioRepository(MetadecudecContext context)
        {
            _context = context;
        }
        public async Task<MdUsuario> SaveUser(MdUsuario usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            usuario.ActivoJuego = false;
            _context.Add(usuario);
            await _context.SaveChangesAsync();
            var usuarioRegistrado = _context.MdUsuarios.Where(x => x.Usuario==usuario.Usuario).FirstOrDefault();
            return usuarioRegistrado;
        }

        public async Task UpdatePassword(MdUsuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<MdUsuario> ValidarPassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.MdUsuarios.Where(x => x.IdUsuario == idUsuario && x.Pasword == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<bool> ValidateExistence(MdUsuario usuario)
        {
            var validateExistence = await _context.MdUsuarios.AnyAsync(x => x.Usuario == usuario.Usuario);
            return validateExistence;
        }

    }
}
