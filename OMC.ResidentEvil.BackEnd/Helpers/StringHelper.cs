using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace OMC.ResidentEvil.BackEnd.Helpers
{
    public static class StringHelper
    {
        public static string Combiner(List<string> names) {

            return string.Join(", ", names);
        }

        public static string GetDescription(this Enum value)
        {            
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
            
        }
    }
}
