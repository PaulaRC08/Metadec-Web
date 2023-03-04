using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdSesion
{
    public int IdSesion { get; set; }

    public string Clase { get; set; } = null!;

    public DateTime FechaSesion { get; set; }

    public string CodigoSesion { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool SesionRealizada { get; set; }

    public virtual ICollection<MdHipervinculo>? MdHipervinculos { get; } = new List<MdHipervinculo>();

    public virtual ICollection<MdSesionUsuario>? MdSesionUsuarios { get; } = new List<MdSesionUsuario>();
}
