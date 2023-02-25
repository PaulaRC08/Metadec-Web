using BE_Metadec.Domain.IRepositories;
using BE_Metadec.Domain.IServices;
using BE_Metadec.Domain.Models;

namespace BE_Metadec.Services
{
    public class UsuarioServices : IUsuarioService
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServices(IUsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task SaveUser(MD_Usuario usuario)
        { 
            await _usuarioRepository.SaveUser(usuario);
        }

        public async Task<bool> ValidateExistence(MD_Usuario usuario)
        {
            return await _usuarioRepository.ValidateExistence(usuario);
        }
        public async Task<MD_Usuario> ValidarPassword(int idUsuario, string passwordAnterior)
        {
            return await _usuarioRepository.ValidarPassword(idUsuario, passwordAnterior);
        }

        public async Task UpdatePassword(MD_Usuario usuario)
        {
            await _usuarioRepository.UpdatePassword(usuario);
        }
    }
}
