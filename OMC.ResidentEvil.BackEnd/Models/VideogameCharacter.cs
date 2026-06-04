using System;
using System.Collections.Generic;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class VideogameCharacter
{
    public int Id { get; set; }

    public int IdGame { get; set; }

    public int Idcharacter { get; set; }

    public virtual Videogame IdGameNavigation { get; set; } = null!;

    public virtual Character IdcharacterNavigation { get; set; } = null!;
}
