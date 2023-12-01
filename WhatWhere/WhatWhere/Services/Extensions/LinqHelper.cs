using WhatWhere.Entities;

namespace WhatWhere.Services.Extensions;

public static class LinqHelper
{
    public static IEnumerable<AGD> ByLocation(this IEnumerable<AGD> query, string location)
    {
        return query.Where(x => x.Location == location);
    }
}