using System;
using System.Collections.Generic;

namespace MetadecBackEnd.Domain.Models;

public partial class MdEncuestum
{

    public int IdEncuesta { get; set; }

    public int IdSesionUsuario { get; set; }

    public string Pregunta1 { get; set; } = null!;

    public string Pregunta2 { get; set; } = null!;

    public string Pregunta3 { get; set; } = null!;

    public string Pregunta4 { get; set; } = null!;

    public string Pregunta5 { get; set; } = null!;

    public virtual MdSesionUsuario? IdSesionUsuarioNavigation { get; set; } = null!;
}
