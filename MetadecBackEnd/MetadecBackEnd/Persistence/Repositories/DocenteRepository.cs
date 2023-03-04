using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class DocenteRepository: IDocenteRepository
    {
        public readonly MetadecudecContext _context;
        public DocenteRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task saveDocente(MdDocente mdDocente)
        {
            _context.Add(mdDocente);
            _context.SaveChanges();
        }
    }
}
