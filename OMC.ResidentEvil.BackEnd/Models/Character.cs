using System;
using System.Collections.Generic;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class Character
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public bool IsMain { get; set; }

    public bool IsSideKick { get; set; }

    public bool IsVillain { get; set; }

    public virtual ICollection<VideogameCharacter> VideogameCharacters { get; set; } = new List<VideogameCharacter>();
}
