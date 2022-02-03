using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class Extension
    {
        public static bool find<T>(this List<T> list, T target)
        {
            return list.Contains(target);
        }
    }
}
