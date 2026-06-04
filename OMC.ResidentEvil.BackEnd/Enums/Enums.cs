using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Enums
{
    public enum Views {

         [Description ("Videogames")]
         Videogames = 1,

         [Description ("Characters")]
         Characters = 2,

         [Description("Guns")]
         Guns = 3,

    }

    public enum CharacterType {
        [Description("All")]
        All = 0,

        [Description("Main")]
        Main = 1,

        [Description("Secondary")]
        Secondary = 2,
    }
}
