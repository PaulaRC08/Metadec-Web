using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        public readonly MetadecudecContext _context;
        public EstudianteRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task saveEstudiante(MdEstudiante mdEstudiante)
        {
            _context.Add(mdEstudiante);
            _context.SaveChanges();
        }
    }
}
