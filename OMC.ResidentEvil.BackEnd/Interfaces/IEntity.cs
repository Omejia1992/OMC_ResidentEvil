using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Interfaces
{
    internal interface IEntity
    {
        int Id { get; set; }
        string Name{ get; set; }
    }
}
