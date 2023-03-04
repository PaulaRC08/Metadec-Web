using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class PaisRepository: IPaisRepository
    {
        private readonly MetadecudecContext _context;

        public PaisRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<List<MdPai>> GetPaises()
        {
            var listPaises = await _context.MdPais.Select(x => new MdPai
            {
                IdPais = x.IdPais,
                Pais = x.Pais,
                CodigoPais = x.CodigoPais,
                Latitud = x.Latitud,
                Longitud = x.Longitud
            }).ToListAsync();
            return listPaises;
        }
    }
}
