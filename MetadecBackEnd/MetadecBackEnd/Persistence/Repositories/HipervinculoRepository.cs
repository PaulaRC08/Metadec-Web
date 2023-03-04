using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class HipervinculoRepository : IHipervinculoRepository
    {
        public readonly MetadecudecContext _context;
        public HipervinculoRepository(MetadecudecContext context)
        {
            _context = context;
        }


        public async Task<List<MdHipervinculo>> getHiprtvinculosSesion(int idSesion)
        {
            var listHipervinculos = await _context.MdHipervinculos.Where(x => x.IdSesion == idSesion).ToListAsync();
            return listHipervinculos;
        }
    }
}
