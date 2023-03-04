using MetadecBackEnd.Controllers;
using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class LoginUnityRepository: ILoginUnityRepository
    {
        public readonly MetadecudecContext _context;
        public LoginUnityRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<MdReporte> ValidateReport(int idUsuario)
        {
            var reporte = await _context.MdReportes.Where(r => r.IdUsuarioReportado == idUsuario && r.ReporteActivo == true).OrderByDescending(t => t.FechaReporte).FirstOrDefaultAsync();
            return reporte;
        }

        public async Task<LoginUnityDTO> ValidateUser(string Usuario, string password)
        {
            var user = await _context.MdUsuarios.Where(x => x.Usuario == Usuario && x.Pasword == password)
                                                .Include(x=>x.IdPaisNavigation)
                                                .Include(x => x.MdReporteIdUsuarioReportadoNavigations)
                                                .FirstOrDefaultAsync();
            LoginUnityDTO userUnity = new LoginUnityDTO();
            if (user != null) {
                userUnity.idUsuario = user.IdUsuario;
                userUnity.usuario = user.Usuario;
                userUnity.pais = user.IdPaisNavigation.Pais;
                userUnity.rol = user.TipoUsuario;
                userUnity.avatarUrl = user.AvatarUrl;
            }
            else
            {
                userUnity = null;
            }

            return userUnity;
        }
    }
}
