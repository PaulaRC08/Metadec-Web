using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdInstitucion
{
    public int IdInstitucion { get; set; }

    public string NombreInstitucion { get; set; } = null!;

    public int IdPais { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual MdPai? IdPaisNavigation { get; set; } = null!;

    public virtual ICollection<MdDocente>? MdDocentes { get; set; } = new List<MdDocente>();

    public virtual ICollection<MdInstitucionPrograma>? MdInstitucionProgramas { get; set; } = new List<MdInstitucionPrograma>();
}
