using System.Text;
using WhatWhere.Entities;
using WhatWhere.Repositories;
using WhatWhere.Services.Extensions;

namespace WhatWhere.Services;

public class LinqMethods : ILinqMethods
{
    private readonly IRepository<AGD> _agdRepository;
    protected static readonly string fileName1 = "AGDFileWrite";
    protected static readonly string fileName2 = "GroceriesFileWrite";
    protected static readonly string fileName3 = "KitchenAccessoriesFileWrite";
    protected static readonly string uRLFile1 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName1}.json";
    protected static readonly string uRLFile2 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName2}.json";
    protected static readonly string uRLFile3 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName3}.json";

    public LinqMethods(IRepository<AGD> agdRepository)
    {
        _agdRepository = agdRepository;
    }

    public List<string> GetUniqueAGDByName()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        var names = agds.Select(c => c.Name).Distinct().ToList();
        return names;
    }

    public decimal GetMinimumCountOfAllAGDs()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Select(x => x.Count).Min();
    }

    public List<AGD> GetSpecificColumns()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        var list = agds.Select(agd => new AGD
        {
            Id = agd.Id,
            Name = agd.Name,
            Location = agd.Location
        }).ToList();
        return list;
    }

    public string AnonymousClass()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        var list = agds.Select(agd => new
        {
            Identifier = agd.Id,
            ProductName = agd.Name,
            ProductLocation = agd.Location
        });

        StringBuilder sb = new(2048);

        foreach (var agd in list)
        {
            sb.AppendLine($"Product ID: {agd.Identifier}");
            sb.AppendLine($"Product Name: {agd.ProductName}");
            sb.AppendLine($"Product Location: {agd.ProductLocation}");
        }
        return sb.ToString();
    }

    public List<AGD> OrderByName()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.OrderBy(x => x.Name).ToList();
    }

    public List<AGD> OrderByNameDescending()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.OrderByDescending(x => x.Name).ToList();
    }

    public List<AGD> OrderByCountAndName()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.OrderBy(x => x.Count)
            .ThenBy(x => x.Name)
            .ToList();
    }

    public List<AGD> OrderByCountAndNameDesc()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.OrderByDescending(x => x.Count)
            .ThenByDescending(x => x.Name)
            .ToList();
    }

    public List<AGD> WhereStartsWith(string prefix)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Where(x => x.Name.StartsWith(prefix)).ToList();
    }

    public List<AGD> WhereStartsWithAndCountIsGreaterThan(string prefix, decimal count)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Where(x => x.Name.StartsWith(prefix) && x.Count > count).ToList();
    }

    public List<AGD> WhereColorIs(string color)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.ByLocation("Lowdówka").ToList();
    }

    public AGD FirstByLocation(string location)
    {
        var cars = _agdRepository.GetAll(uRLFile1);
        return cars.First(x => x.Location == location);
    }

    public AGD? FirstOrDefaultByLocation(string location)
    {
        var cars = _agdRepository.GetAll(uRLFile1);
        return cars.FirstOrDefault(x => x.Location == location);
    }

    public AGD FirstOrDefaultByLocationWithDefault(string location)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
            .FirstOrDefault(
            x => x.Location == location,
            new AGD { Id = -1, Name = "Not found" });
    }

    public AGD LastByCount(int count)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Last(x => x.Count == count);
    }

    public AGD SingleById(int id)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Single(x => x.Id == id);
    }

    public AGD SingleOrDefaultById(int id)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.SingleOrDefault(x => x.Id == id);
    }

    public List<AGD> TakeAGDs(int howMany)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
            .OrderBy(x => x.Name)
            .Take(howMany)
            .ToList();
    }

    public List<AGD> TakeAGDs(Range range)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
            .OrderBy(x => x.Name)
            .Take(range)
            .ToList();
    }

    public List<AGD> TakeCarsWhileNameStartsWith(string prefix)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
           .OrderBy(x => x.Name)
           .TakeWhile(x => x.Name.StartsWith(prefix))
           .ToList();
    }

    public List<AGD> SkipAGDs(int howMany)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
           .OrderBy(x => x.Name)
           .Skip(howMany)
           .ToList();
    }

    public List<AGD> SkipAGDsWhileNameStartsWit(string prefix)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
          .OrderBy(x => x.Name)
          .SkipWhile(x => x.Name.StartsWith(prefix))
          .ToList();
    }

    public List<string> DistinctAllLocation()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
            .Select(x => x.Location)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<AGD> DistinctByLocation()
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds
            .DistinctBy(x => x.Location)
            .OrderBy(x => x.Count)
            .ToList();
    }

    public List<AGD[]> ChunkAGDs(int size)
    {
        var agds = _agdRepository.GetAll(uRLFile1);
        return agds.Chunk(size).ToList();
    }
}