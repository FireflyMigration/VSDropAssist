using System;
using System.Collections.Generic;

namespace VSDropAssist.Core
{
    public static class StringExtensions
    {
        public static int IndexOf<TSource>(this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            int i = 0;

            foreach (TSource element in source)
            {
                if (predicate(element))
                    return i;

                i++;
            }

            return -1;
        }
    }
}