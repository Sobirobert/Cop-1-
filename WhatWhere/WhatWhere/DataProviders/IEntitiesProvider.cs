using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.DataProviders;

public interface IEntitiesProvider
{
    List<Groceries> OrderByNameDescending();
    List<Groceries> OrderByCountDescending();
    List<Groceries> OrderByLocation();
    List<Groceries> SelectByLocationFridge();

    //List<string> GetUniqueEntitiesByName();
    //int SelectByCountSortByMin();
    //List<Groceries> GetSpecificColumns();
    //string AnonymousClass();
    //List<Groceries> OrderByName();
    //List<Groceries> OrderByCountAndName();
    //List<Groceries> OrderByCountAndNameDesc();
    //List<Groceries> WhereStartsWith(string prefix);
    //List<Groceries> WhereStartsWithAndCountIsGreaterThan(string prefix, decimal count);
    //List<Groceries> WhereColorIs(string color);
    //Groceries FirstByLocation(string location);
    //Groceries? FirstOrDefaultByLocation(string location);
    //Groceries FirstOrDefaultByLocationWithDefault(string location);
    //Groceries LastByCount(int count);
    //Groceries SingleById(int id);
    //Groceries SingleOrDefaultById(int id);
    //List<Groceries> TakeGroceries(int howMany);
    //List<Groceries> TakeGroceries(Range range);
    //List<Groceries> TakeCarsWhileNameStartsWith(string prefix);
    //List<Groceries> SkipGroceries( int howMany);
    //List<Groceries> SkipGroceriesWhileNameStartsWit(string prefix);
    //List<string> DistinctAllLocation();
    //List<Groceries> DistinctByLocation();
    //List<Groceries[]> ChunkGroceries(int size);
    //List<Groceries> SelectLowCountProducts();
}