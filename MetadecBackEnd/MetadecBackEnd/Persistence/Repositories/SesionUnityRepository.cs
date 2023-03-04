using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class SesionUnityRepository : ISesionUnityRepository
    {
        public readonly MetadecudecContext _context;
        public SesionUnityRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public Task<List<MdSesionUsuario>> listSesionesDocente(int docente)
        {
            var start = DateTime.Now.Date;
            var end = start.AddDays(8);
            var listSesion = _context.MdSesionUsuarios
                    .Where(x => x.IdUsuario == docente && (
                            x.IdSesionNavigation.FechaSesion >= start &&
                            x.IdSesionNavigation.FechaSesion <= end &&
                            x.ClientMaster == true &&
                            x.IdSesionNavigation.SesionRealizada == false))
                    .Include(x => x.IdSesionNavigation)
                   .OrderBy(x => x.IdSesionNavigation.FechaSesion).ToListAsync();
            return listSesion;
        }

        public async Task<MdSesion> updateSesionActive(int idSesion)
        {
            var sesion = _context.MdSesions.Where(x=> x.IdSesion==idSesion).FirstOrDefault();
            sesion.SesionRealizada = true;
            _context.MdSesions.Update(sesion);
            _context.SaveChanges();
            return sesion;
        }

        public async Task<MdSesion> ValidateSesion(string Usuario, string password)
        {
            var user = await _context.MdSesions.Where(x => x.CodigoSesion == Usuario && x.Password == password).FirstOrDefaultAsync();
            return user;
        }


    }
}
