using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ISesionUsuarioRepository
    {
        Task<List<MdSesionUsuario>> listSesionesDocente(int docente);
        Task<List<MdSesionUsuario>> listSesionesActivas(int idUsuario);
        Task saveSesionUsuarios(SesionUsuarioDTO sesionUsuarioDto);
        Task<List<string>> listaPaises(int idUsuario);
    }
}
