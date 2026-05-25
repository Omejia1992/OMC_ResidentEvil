using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Interfaces
{
    internal interface IMethods <T1>
    {
        public static List<T1> Get(){ return new List<T1>(); }
        public static void Add(T1 type1) { }
        public static void Delete(T1 type1) { }
    }
}
