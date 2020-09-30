using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToLearn.Extensions
{
    public static class RandomExtensions
    {
        public static T EnumValue<T>(this Random random)
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }
    }
}
