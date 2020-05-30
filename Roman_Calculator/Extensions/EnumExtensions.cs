using System;
using System.Collections.Generic;

namespace Roman_Calculator.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<int> EnumToValues<T>()
            where T : Enum
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                yield return (int)value;
            }
        }

        public static IEnumerable<string> EnumToNames<T>()
           where T : Enum
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                yield return name;
            }
        }
    }

    

}
