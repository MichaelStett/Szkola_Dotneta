using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman_Calculator.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<int> EnumToEnumerable<T>()
            where T : Enum
        {
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                yield return (int)value;
            }
        }
    }

    

}
