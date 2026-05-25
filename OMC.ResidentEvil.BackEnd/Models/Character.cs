using System;
using System.Collections.Generic;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class Character
{
    public int Id { get; set; }

    public int IdGame { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public bool IsMain { get; set; }

    public virtual Videogame IdGameNavigation { get; set; } = null!;
}
