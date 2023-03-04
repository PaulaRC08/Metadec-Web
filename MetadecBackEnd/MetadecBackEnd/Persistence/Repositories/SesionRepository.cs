using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class SesionRepository: ISesionRepository
    {

        public readonly MetadecudecContext _context;
        public SesionRepository(MetadecudecContext context)
        {
            _context = context;
        }


        public async Task saveSesion(MdSesion mdSesion)
        {
            _context.Add(mdSesion);
            _context.SaveChanges();
        }

        public async Task<bool> ValidateExistence(MdSesion mdSesion)
        {
            var validateExistence = await _context.MdSesions.AnyAsync(x => x.CodigoSesion == mdSesion.CodigoSesion);
            return validateExistence;
        }
    }
}
