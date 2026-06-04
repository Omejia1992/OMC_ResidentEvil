using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.DTOS
{
    public class MainCharacterDTO : CharacterDTO
    {
        public bool IsProtagonist { get; set; }
        public bool MultipleGames { get; set; }
        public int GamesAmount { get; set; }
    }
}
