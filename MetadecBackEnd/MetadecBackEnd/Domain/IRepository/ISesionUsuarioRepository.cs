using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Domain.IRepository
{
    public interface ISesionUsuarioRepository
    {
        Task<List<MdSesionUsuario>> listSesionesDocente(int docente);
        Task saveSesionUsuarios(SesionUsuarioDTO sesionUsuarioDto);
    }
}
