using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdHipervinculo
{
    public int IdHipervinculo { get; set; }

    public int IdSesion { get; set; }

    public string NombreHipervinculo { get; set; } = null!;

    public string UrlHpervinculo { get; set; } = null!;

    public string TipoHipervinculo { get; set; } = null!;

    public virtual MdSesion? IdSesionNavigation { get; set; } = null!;
}
