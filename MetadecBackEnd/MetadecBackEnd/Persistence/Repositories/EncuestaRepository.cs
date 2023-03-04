using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.Domain.Models;
using MetadecBackEnd.DTO;

namespace MetadecBackEnd.Persistence.Repositories
{
    public class EncuestaRepository : IEncuestaRepository
    {
       
        private readonly MetadecudecContext _context;

        public EncuestaRepository(MetadecudecContext context)
        {
            _context = context;
        }

        public async Task<MdEncuestum> SaveEncuesta(EncuestaDTO encuesta)
        {
            //usuario.FechaCreacion = DateTime.Now;
            var sesionUsuario = _context.MdSesionUsuarios.Where(s => s.IdSesion ==  encuesta.IdSesion && s.IdUsuario == encuesta.IdUsuario)
                .OrderByDescending(s => s.IdSesionUsuarios).FirstOrDefault();
            MdEncuestum md = new MdEncuestum();
            md.IdSesionUsuario = sesionUsuario.IdSesionUsuarios;
            md.Pregunta1 = encuesta.Pregunta1;
            md.Pregunta2 = encuesta.Pregunta2;
            md.Pregunta3 = encuesta.Pregunta3;
            md.Pregunta4 = encuesta.Pregunta4;
            md.Pregunta5 = encuesta.Pregunta5;
            _context.Add(md);
            await _context.SaveChangesAsync();
            var encuestaAdd = _context.MdEncuesta.Where(x => x.IdSesionUsuario==sesionUsuario.IdSesionUsuarios).FirstOrDefault();
            return encuestaAdd;
        }
    }
}
