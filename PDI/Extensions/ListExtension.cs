using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
    {
        return source ?? Enumerable.Empty<T>();
    }
}