using System;
using System.Collections.Generic;

namespace OMC.ResidentEvil.BackEnd.Models;

public partial class Videogame
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public bool HasRemake { get; set; }

    public virtual ICollection<Gun> Guns { get; set; } = new List<Gun>();

    public virtual ICollection<VideogameCharacter> VideogameCharacters { get; set; } = new List<VideogameCharacter>();
}
