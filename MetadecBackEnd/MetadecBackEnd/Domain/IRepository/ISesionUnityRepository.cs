using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ISesionUnityRepository
    {
        Task<List<MdSesionUsuario>> listSesionesDocente(int docente);
        Task<MdSesion> ValidateSesion(string Usuario, string password);

        Task<MdSesion> updateSesionActive(int idSesion);
    }
}
