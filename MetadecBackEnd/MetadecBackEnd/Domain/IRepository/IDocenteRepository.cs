using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface IDocenteRepository
    {

        Task saveDocente(MdDocente mdDocente);

    }
}
