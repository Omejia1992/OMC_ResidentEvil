using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.DTOS
{
    public class SideCharacterDTO : CharacterDTO
    {
        public bool IsSidekick { get; set; }
        public bool IsVillian { get; set; }
    }
}
