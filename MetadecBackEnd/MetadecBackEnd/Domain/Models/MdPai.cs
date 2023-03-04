using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdPai
{
    public int IdPais { get; set; }

    public string Pais { get; set; } = null!;

    public string CodigoPais { get; set; } = null!;

    public string Longitud { get; set; } = null!;

    public string Latitud { get; set; } = null!;

    public virtual ICollection<MdInstitucion>? MdInstitucions { get; } = new List<MdInstitucion>();

    public virtual ICollection<MdUsuario>? MdUsuarios { get; } = new List<MdUsuario>();
}
