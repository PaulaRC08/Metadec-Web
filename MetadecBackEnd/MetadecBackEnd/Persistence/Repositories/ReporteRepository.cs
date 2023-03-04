using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        public readonly MetadecudecContext _context;
        public ReporteRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<MdReporte> saveReporte(MdReporte reporte)
        {
            reporte.FechaReporte = DateTime.Now;
            _context.MdReportes.Add(reporte);
            _context.SaveChanges();
            return reporte;
        }

        public async Task<MdReporte> updateReporte(MdReporte reporte)
        {
            reporte.ReporteActivo = false;
            _context.MdReportes.Update(reporte);
            _context.SaveChanges();
            return reporte;
        }
    }
}
