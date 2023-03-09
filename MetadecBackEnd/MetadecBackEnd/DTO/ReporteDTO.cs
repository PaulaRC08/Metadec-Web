namespace MetadecBackEnd.DTO
{
    public class ReporteDTO
    {

        public bool ComunicacionOfensiva { get; set; }

        public bool NombreOfensivo { get; set; }

        public bool ComportIrrespetuoso { get; set; }

        public bool Amenaza { get; set; }

        public string FechaReporte { get; set; }

        public string FechaFin { get; set; }
    }
}
