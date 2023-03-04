using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdDocente
{
    public int IdDocente { get; set; }

    public int IdUsuario { get; set; }

    public int IdInstitucion { get; set; }

    public virtual MdInstitucion? IdInstitucionNavigation { get; set; } = null!;

    public virtual MdUsuario? IdUsuarioNavigation { get; set; } = null!;
}
