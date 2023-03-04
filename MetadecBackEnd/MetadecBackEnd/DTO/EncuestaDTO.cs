using MetadecBackEnd.Domain.Models;

namespace MetadecBackEnd.DTO
{
    public class EncuestaDTO
    {
        public int IdEncuesta { get; set; }

        public int IdUsuario { get; set; }
        public int IdSesion { get; set; }

        public string Pregunta1 { get; set; } = null!;

        public string Pregunta2 { get; set; } = null!;

        public string Pregunta3 { get; set; } = null!;

        public string Pregunta4 { get; set; } = null!;

        public string Pregunta5 { get; set; } = null!;

    }
}
