namespace MetadecBackEnd.DTO
{
    public class SesionUnityDTO
    {
        public int IdSesion { get; set; }
        public string Clase { get; set; } = null!;
        public string FechaSesion { get; set; }
        public string CodigoSesion { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class ListSesionesDTO
    {
        public List<SesionUnityDTO> sesiones { get; set; } = new List<SesionUnityDTO>();
    }
}
