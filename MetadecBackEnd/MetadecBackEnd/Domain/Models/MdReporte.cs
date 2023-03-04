using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdReporte
{
    public int IdReporte { get; set; }

    public int IdUsuarioReportado { get; set; }

    public int IdUsuarioReporto { get; set; }

    public int IdDocenteAtendio { get; set; }

    public bool ComunicacionOfensiva { get; set; }

    public bool NombreOfensivo { get; set; }

    public bool ComportIrrespetuoso { get; set; }

    public bool Amenaza { get; set; }

    public string? DescripcionReporte { get; set; }

    public DateTime? FechaReporte { get; set; }

    public bool ReporteActivo { get; set; }

    public string? Penalizacion { get; set; }
    public virtual MdUsuario? IdDocenteAtendioNavigation { get; set; } = null!;

    public virtual MdUsuario? IdUsuarioReportadoNavigation { get; set; } = null!;

    public virtual MdUsuario? IdUsuarioReportoNavigation { get; set; } = null!;
}
