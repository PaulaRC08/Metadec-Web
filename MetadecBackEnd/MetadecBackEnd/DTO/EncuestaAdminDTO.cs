using MetadecBackEnd.Domain.Models;
using System.Collections.Generic;

namespace MetadecBackEnd.DTO
{
    public class EncuestaAdminDTO
    {
        public virtual IEnumerable<repuestasDTO> pregunta1 { get; set; } = new List<repuestasDTO>();
        public virtual IEnumerable<repuestasDTO> pregunta2 { get; set; } = new List<repuestasDTO>();
        public virtual IEnumerable<repuestasDTO> pregunta3 { get; set; } = new List<repuestasDTO>();
        public virtual IEnumerable<repuestasDTO> pregunta4 { get; set; } = new List<repuestasDTO>();
        public virtual IEnumerable<repuestasDTO> pregunta5 { get; set; } = new List<repuestasDTO>();
    }

    public class repuestasDTO
    {
        public string name { get; set; }
        public int value { get; set; }
    }
}
