using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class InstitucionProgramaRepository : IInstitucionProgramaRepository
    {
        private readonly MetadecudecContext _context;

        public InstitucionProgramaRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<List<MdInstitucionPrograma>> GetProgramasInstitucion(int idInstitucion)
        {
            var listProgramas = await _context.MdInstitucionProgramas
                .Where(x => x.IdInstitucion == idInstitucion)
                .Include(x => x.IdProgramaNavigation).ToListAsync();
            return listProgramas;
        }
    }

}