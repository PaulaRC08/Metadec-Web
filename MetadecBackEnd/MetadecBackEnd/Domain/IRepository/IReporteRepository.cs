using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IReporteRepository
    {
        Task<MdReporte> saveReporte(MdReporte reporte);
        Task<MdReporte> updateReporte(MdReporte reporte);
    }
}
