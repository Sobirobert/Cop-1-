using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public class MethodsExtensions : IMethodsExtensions
{
    #region AddStringConversionToInt

    public int AddStringConversionToInt(string value)
    {
        if (int.TryParse(value, out int number))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return number;
    }

    #endregion AddStringConversionToInt

    public void AddAGDObjectToMemory(IRepository<AGD> repository)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new AGD
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        repository.Add(newObjcet);
    }

    public void AddGroceriesObjectToMemory(IRepository<Groceries> repository)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new Groceries
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        repository.Add(newObjcet);
    }

    public void AddKitchenAccessoriesObjectToMemory(IRepository<KitchenAccessories> repository)
    {
        Console.WriteLine("Insert name");
        var name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        var newObjcet = new KitchenAccessories
        {
            Name = name,
            Location = location,
            Count = countInt,
            DateChange = DateTime.Now
        };
        repository.Add(newObjcet);
    }
}