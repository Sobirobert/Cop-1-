﻿using WhatWhere.Entities;
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

    public void AddObjectToMemory<T>(SqlRepository<T> repository, RepositoryToFileJson<T> repository2)
        where T : class, IEntity, new()
    {
        Console.WriteLine("Insert name");
        string name = Console.ReadLine();

        Console.WriteLine("Insert Location");
        var location = Console.ReadLine();

        Console.WriteLine("Insert Count");
        var count = Console.ReadLine();
        int countInt = AddStringConversionToInt(count);

        T newObject = new T();

        if (typeof(T) == typeof(AGD))
        {
            ((AGD)(object)newObject).Name = name;
            ((AGD)(object)newObject).Location = location;
            ((AGD)(object)newObject).Count = countInt;
            ((AGD)(object)newObject).DateChange = DateTime.Now;
            repository?.Add(newObject);
            Console.WriteLine("AGD Added\n");
            repository2?.Add(newObject);
            Console.WriteLine("Do you want save object ?\n");
            Console.WriteLine("Press Y - yes or N - no.\n");
            var userInPut = Console.ReadLine();
            if (userInPut == "Y" || userInPut == "y")
            {
                if (repository2 != null)
                {
                    repository2.Save();
                    Console.WriteLine("Object Saved\n");
                }

            }
            else if (userInPut != null && (userInPut == "N" || userInPut == "n"))
            {
                Console.WriteLine("Object didn't Save\n");
            }
            else
            {
                Console.WriteLine("Wrong answer");
            }
        }
        else if (typeof(T) == typeof(Groceries))
        {
            ((Groceries)(object)newObject).Name = name;
            ((Groceries)(object)newObject).Location = location;
            ((Groceries)(object)newObject).Count = countInt;
            ((Groceries)(object)newObject).DateChange = DateTime.Now;
            repository?.Add(newObject);
            Console.WriteLine("Groceries Added\n");

            Console.WriteLine("Do you want save object ?\n");
            Console.WriteLine("Press Y - yes or N - no.\n");
            var userInPut = Console.ReadLine();
            if (userInPut != null && (userInPut == "Y" || userInPut == "y"))
            {
                repository2?.AddGroceries(newObject);

                Console.WriteLine("Object Saved\n");
            }
            else if (userInPut != null && (userInPut == "N" || userInPut == "n"))
            {
                Console.WriteLine("Object didn't Save\n");
            }
            else
            {
                Console.WriteLine("Wrong answer");
            }
        }
        else if (typeof(T) == typeof(KitchenAccessories))
        {
            ((KitchenAccessories)(object)newObject).Name = name;
            ((KitchenAccessories)(object)newObject).Location = location;
            ((KitchenAccessories)(object)newObject).Count = countInt;
            ((KitchenAccessories)(object)newObject).DateChange = DateTime.Now;
            repository.Add(newObject);

            Console.WriteLine("KitchenAccessories Added\n");

            Console.WriteLine("Do you want save object ?\n");
            Console.WriteLine("Press Y - yes or N - no.\n");
            var userInPut = Console.ReadLine();
            if (userInPut != null && (userInPut == "Y" || userInPut == "y"))
            {
                repository2?.AddKitchenAccessories(newObject);
                Console.WriteLine("Object Saved\n");
            }
            else if (userInPut != null && (userInPut == "N" || userInPut == "n"))
            {
                Console.WriteLine("Object didn't Save\n");
            }
            else
            {
                Console.WriteLine("Wrong answer");
            }
        }
    }
   
    public void WriteAllToConsole<T>(SqlRepository<T> repository) where T : class, IEntity, new()
    {
        var items = repository.GetAll();
        if (items?.ToList() == null)
        {
            Console.WriteLine($"No objects found.");
        }
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}