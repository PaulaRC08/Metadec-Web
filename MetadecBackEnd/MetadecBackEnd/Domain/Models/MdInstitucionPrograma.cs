using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdInstitucionPrograma
{
    public int IdInstitucionPrograma { get; set; }

    public int IdInstitucion { get; set; }

    public int IdPrograma { get; set; }

    public virtual MdInstitucion? IdInstitucionNavigation { get; set; } = null!;

    public virtual MdPrograma? IdProgramaNavigation { get; set; } = null!;

    public virtual ICollection<MdEstudiante>? MdEstudiantes { get; set; } = new List<MdEstudiante>();
}
