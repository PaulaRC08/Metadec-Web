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

        public async Task<List<string>> listaPaises(int idUsuario)
        {
            var listPaises3 = await _context.MdSesions.Where(x => x.MdSesionUsuarios
                            .Any(s => s.IdUsuarioNavigation.IdUsuario == idUsuario) && x.SesionRealizada == true)
                            .Include(l=>l.MdSesionUsuarios.Where(x=>x.IdUsuario != idUsuario))
                                .ThenInclude(s=>s.IdUsuarioNavigation.IdPaisNavigation)
                            .ToListAsync();
            List<string> paises = new List<string>();

            foreach (var sesion in listPaises3)
            {
                foreach (var sesionusuario in sesion.MdSesionUsuarios)
                {
                    paises.Add(sesionusuario.IdUsuarioNavigation.IdPaisNavigation.Pais);
                }
            }
            //var list = _context.MdSesionUsuarios.FromSql($"SELECT  FROM dbo.MD_SESION_USUARIO").ToList();
            return paises;
        }

        public async Task<List<MdSesionUsuario>> listSesionesActivas(int idUsuario)
        {
            var listSesion = await _context.MdSesionUsuarios
                    .Where(x => x.IdUsuario == idUsuario && x.IdSesionNavigation.SesionRealizada == true)
                    .Include(x => x.IdSesionNavigation)
                        .ThenInclude(x=> x.MdSesionUsuarios)
                   .OrderByDescending(x => x.IdSesionNavigation.FechaSesion).ToListAsync();
            return listSesion;
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
