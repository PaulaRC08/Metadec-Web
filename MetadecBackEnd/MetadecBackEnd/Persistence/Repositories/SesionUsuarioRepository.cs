using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class SesionUsuarioRepository: ISesionUsuarioRepository
    {
        public readonly MetadecudecContext _context;
        public SesionUsuarioRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<List<MdSesionUsuario>> listSesionesDocente(int docente)
        {
            var start = DateTime.Now.Date;
            var end = start.AddMonths(1);
            var listSesion = await _context.MdSesionUsuarios
                    .Where(x => x.IdUsuario == docente && (
                            x.IdSesionNavigation.FechaSesion >= start && 
                            x.ClientMaster == true &&
                            x.IdSesionNavigation.SesionRealizada == false))
                    .Include(x=> x.IdSesionNavigation)
                   .OrderBy(x=> x.IdSesionNavigation.FechaSesion) .ToListAsync();
            return listSesion;
        }

        public async Task saveSesionUsuarios(SesionUsuarioDTO sesionUsuarioDto)
        {
            List<MdSesionUsuario> listUsuarios = new List<MdSesionUsuario>();
            foreach (var item in sesionUsuarioDto.idUsuarios)
            {
                MdSesionUsuario mdSesionUsuario = new MdSesionUsuario();
                mdSesionUsuario.IdSesion = sesionUsuarioDto.IdSesion;
                mdSesionUsuario.IdUsuario = item;
                mdSesionUsuario.ClientMaster = false;
                listUsuarios.Add(mdSesionUsuario);
            }
            listUsuarios.ForEach(x => _context.MdSesionUsuarios.Add(x));
            _context.SaveChanges();
            
        }
    }
}
