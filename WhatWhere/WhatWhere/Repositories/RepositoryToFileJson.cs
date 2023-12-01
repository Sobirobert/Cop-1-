using System.Text.Json;
using WhatWhere.Entities;

namespace WhatWhere.Repositories;

public class RepositoryToFileJson<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly List<T> _items1 = new();
    private readonly List<T> _items2 = new();
    private readonly List<T> _items3 = new();
    protected static readonly string fileName1 = "AGDFileWrite";
    protected static readonly string fileName2 = "GroceriesFileWrite";
    protected static readonly string fileName3 = "KitchenAccessoriesFileWrite";
    protected static readonly string uRLFile1 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName1}.json";
    protected static readonly string uRLFile2 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName2}.json";
    protected static readonly string uRLFile3 = $@"D:\Programowanie2\Cop 1\Cop-1-\WhatWhere\WhatWhere\Migrations\{fileName3}.json";

    public event EventHandler<T> ItemAdded;

    public event EventHandler<T> ItemRemoved;

    public void Add(T item)
    {
        if (typeof(T) == typeof(AGD))
        {
            item.Id = _items1.Count + 1;
            _items1.Add(item);
            Save();
            ItemAdded?.Invoke(this, item);
        }
        else if (typeof(T) == typeof(Groceries))
        {
            item.Id = _items2.Count + 1;
            _items2.Add(item);
            Save();
            ItemAdded?.Invoke(this, item);
        }
        else if (typeof(T) == typeof(KitchenAccessories))
        {
            item.Id = _items3.Count + 1;
            _items3.Add(item);
            Save();
            ItemAdded?.Invoke(this, item);
        }
    }

    public T? GetById(int id)
    {
        if (id > 0)
        {
            return _items1.Find(item => item.Id == id);
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    public void Remove(T item)
    {
        if (item != null)
        {
            _items1.Remove(item);
        }
        else
        {
            throw new InvalidOperationException("The product doesn't exist");
        }
    }

    public void Save()
    {
        if (typeof(T) == typeof(AGD))
        {
            var json = JsonSerializer.Serialize(_items1);
            File.WriteAllText(uRLFile1, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        else if (typeof(T) == typeof(Groceries))
        {
            var json2 = JsonSerializer.Serialize(_items2);
            File.WriteAllText(uRLFile2, json2);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        else if (typeof(T) == typeof(KitchenAccessories))
        {
            var json3 = JsonSerializer.Serialize(_items3);
            File.WriteAllText(uRLFile3, json3);
            Console.WriteLine("Conversion to file JSON successful.");
        }
    }

    public IEnumerable<T> GetAll(string url)
    {
        var readfile = File.ReadAllText(url);
        var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);

        if (json != null || json.Any())
        {
            return json.ToList();
        }
        else
        {
            throw new Exception("File is empty");
        }
    }

    public void WriteAllConsoleFromFileAGD(IRepository<AGD> repository1)
    {
        var items = repository1.GetAll(uRLFile1);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void WriteAllConsoleFromFileGroceries(IRepository<Groceries> repository1)
    {
        var items = repository1.GetAll(uRLFile2);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ReadAllConsoleFromFileKitchenAccessories(IRepository<KitchenAccessories> repository1)
    {
        var items = repository1.GetAll(uRLFile3);
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearJSONFile(string uRLString)
    {
        File.WriteAllText(uRLString, string.Empty);
    }

    public void ClearAllFile()
    {
        ClearJSONFile(uRLFile1);
        ClearJSONFile(uRLFile2);
        ClearJSONFile(uRLFile3);
    }

    public T GetByIdAGD(int id)
    {
        var readfile = File.ReadAllText(uRLFile1);
        var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
        var itemById = json.ToList().SingleOrDefault(i => i.Id == id);
        if (itemById == null)
        {
            Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
        }
        return itemById;
    }

    public T GetByIdGroceries(int id)
    {
        var readfile = File.ReadAllText(uRLFile2);
        var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
        var itemById = json.ToList().SingleOrDefault(i => i.Id == id);
        if (itemById == null)
        {
            Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
        }
        return itemById;
    }

    public T GetByIdKitchenAccessories(int id)
    {
        var readfile = File.ReadAllText(uRLFile3);
        var json = JsonSerializer.Deserialize<IEnumerable<T>>(readfile);
        var itemById = json.ToList().SingleOrDefault(i => i.Id == id);
        if (itemById == null)
        {
            Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
        }
        return itemById;
    }

    public void RemoveAGDById(int id)
    {
        var file = GetAll(uRLFile1);
        if (file != null)
        {
            var list = file.Where(i => i.Id != id).ToList();
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(uRLFile1, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        else
        {
            throw new Exception("File is empty");
        }
    }

    public void RemoveGroceriesById(int id)
    {
        var file = GetAll(uRLFile2);
        if (file != null)
        {
            var list = file.Where(i => i.Id != id).ToList();
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(uRLFile2, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        else
        {
            throw new Exception("File is empty");
        }
    }

    public void RemoveKitchenAccessoriesById(int id)
    {
        var file = GetAll(uRLFile3);
        if (file != null)
        {
            var list = file.Where(i => i.Id != id).ToList();
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(uRLFile3, json);
            Console.WriteLine("Conversion to file JSON successful.");
        }
        else
        {
            throw new Exception("File is empty");
        }
    }
}