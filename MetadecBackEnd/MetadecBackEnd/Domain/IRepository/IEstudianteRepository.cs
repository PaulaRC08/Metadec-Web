using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IEstudianteRepository
    {
        Task saveEstudiante(MdEstudiante mdEstudiante);
    }
}
