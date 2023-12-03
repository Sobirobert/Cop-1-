using WhatWhere.Entities;

namespace WhatWhere.DataProviders.Extensions;

public static class EntitiesHelper
{
    public static IEnumerable<Groceries> ByLocation(this IEnumerable<Groceries> query, string location)
    {
        return query.Where(x => x.Location == location);
    }
}