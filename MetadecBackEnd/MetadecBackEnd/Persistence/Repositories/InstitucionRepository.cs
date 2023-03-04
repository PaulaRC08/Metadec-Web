using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class InstitucionRepository : IInstitucionRepository
    {
        private readonly MetadecudecContext _context;

        public InstitucionRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<List<MdInstitucion>> GetInstituciones()
        {
            var listInstituciones = await _context.MdInstitucions.Select(x => new MdInstitucion
            {
                IdInstitucion = x.IdInstitucion,
                NombreInstitucion = x.NombreInstitucion,
                IdPais = x.IdPais
            })
            .ToListAsync();
            return listInstituciones;
        }
    }
}
