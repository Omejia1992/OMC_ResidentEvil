using System;
using System.Collections.Generic;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class Gun
{
    public int Id { get; set; }

    public int IdGame { get; set; }

    public string Name { get; set; } = null!;

    public virtual Videogame IdGameNavigation { get; set; } = null!;
}
