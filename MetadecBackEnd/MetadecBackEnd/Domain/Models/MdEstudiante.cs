using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdEstudiante
{
    public int IdEstudiante { get; set; }

    public int IdUsuario { get; set; }

    public int IdInstitucionPrograma { get; set; }

    public virtual MdInstitucionPrograma? IdInstitucionProgramaNavigation { get; set; } = null!;

    public virtual MdUsuario? IdUsuarioNavigation { get; set; } = null!;
}
