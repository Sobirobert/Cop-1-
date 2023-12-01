using WhatWhere.Entities;

namespace WhatWhere.Services;

public interface ILinqMethods
{
    List<string> GetUniqueAGDByName();

    decimal GetMinimumCountOfAllAGDs();

    List<AGD> GetSpecificColumns();

    string AnonymousClass();

    List<AGD> OrderByName();

    List<AGD> OrderByNameDescending();

    List<AGD> OrderByCountAndName();

    List<AGD> OrderByCountAndNameDesc();

    List<AGD> WhereStartsWith(string prefix);

    List<AGD> WhereStartsWithAndCountIsGreaterThan(string prefix, decimal count);

    List<AGD> WhereColorIs(string color);

    AGD FirstByLocation(string location);

    AGD? FirstOrDefaultByLocation(string location);

    AGD FirstOrDefaultByLocationWithDefault(string location);

    AGD LastByCount(int count);

    AGD SingleById(int id);

    AGD SingleOrDefaultById(int id);

    List<AGD> TakeAGDs(int howMany);

    List<AGD> TakeAGDs(Range range);

    List<AGD> TakeCarsWhileNameStartsWith(string prefix);

    List<AGD> SkipAGDs(int howMany);

    List<AGD> SkipAGDsWhileNameStartsWit(string prefix);

    List<string> DistinctAllLocation();

    List<AGD> DistinctByLocation();

    List<AGD[]> ChunkAGDs(int size);
}