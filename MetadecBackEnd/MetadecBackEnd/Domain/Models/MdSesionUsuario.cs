using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdSesionUsuario
{
    public int IdSesionUsuarios { get; set; }

    public int IdUsuario { get; set; }

    public int IdSesion { get; set; }

    public bool ClientMaster { get; set; }

    public virtual MdSesion? IdSesionNavigation { get; set; } = null!;

    public virtual MdUsuario? IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<MdEncuestum>? MdEncuesta { get; } = new List<MdEncuestum>();
}
