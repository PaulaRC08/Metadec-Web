using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdUsuario
{
    public int IdUsuario { get; set; }

    public string Usuario { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public string AvatarUrl { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Sexo { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int IdPais { get; set; }

    public bool TratamientoDatos { get; set; }

    public bool Administrador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public bool ActivoJuego { get; set; }

    public virtual MdPai? IdPaisNavigation { get; set; } = null!;

    public virtual ICollection<MdDocente>? MdDocentes { get; set; } = new List<MdDocente>();

    public virtual ICollection<MdEstudiante>? MdEstudiantes { get; set; } = new List<MdEstudiante>();

    public virtual ICollection<MdReporte>? MdReporteIdDocenteAtendioNavigations { get; set; } = new List<MdReporte>();

    public virtual ICollection<MdReporte>? MdReporteIdUsuarioReportadoNavigations { get; set; } = new List<MdReporte>();

    public virtual ICollection<MdReporte>? MdReporteIdUsuarioReportoNavigations { get; set; } = new List<MdReporte>();

    public virtual ICollection<MdSesionUsuario>? MdSesionUsuarios { get; set; } = new List<MdSesionUsuario>();
}
