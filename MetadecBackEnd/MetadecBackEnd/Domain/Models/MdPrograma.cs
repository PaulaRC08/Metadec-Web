using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdPrograma
{
    public int IdPrograma { get; set; }

    public string Programa { get; set; } = null!;

    public virtual ICollection<MdInstitucionPrograma>? MdInstitucionProgramas { get; set; } = new List<MdInstitucionPrograma>();
}
