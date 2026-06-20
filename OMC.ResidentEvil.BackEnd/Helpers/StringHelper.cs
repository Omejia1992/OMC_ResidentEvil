using System;
using System.Collections.Generic;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    internal class StringHelper
    {
        public static string Combiner(List<string> names) {

            return string.Join(", ", names);
        }

    }
}
