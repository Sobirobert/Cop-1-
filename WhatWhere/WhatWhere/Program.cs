using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using WhatWhere;
using WhatWhere.Data;
using WhatWhere.Entities;
using WhatWhere.Repositories;

//var itemAdded = new ItemAdded(ThingAdded);

var inwentoryAGD = new SqlRepository<AGD>(new WhatWhereDbContext());
var inwentoryGroceries = new SqlRepository<Groceries>(new WhatWhereDbContext());
var inwentoryKitchenAccessories = new SqlRepository<KitchenAccessories>(new WhatWhereDbContext());
var inwentoryToFileAGD = new RepositoryToFileJson<AGD>();
var inwentoryToFileGroceries = new RepositoryToFileJson<Groceries>();
var inwentoryToFileKitchenAccessories = new RepositoryToFileJson<KitchenAccessories>();


while (true)
{
    Console.WriteLine("Hello User.");
    Console.WriteLine("Choose option");
    Console.WriteLine("Press 1 to Add AGD product");
    Console.WriteLine("Press 2 to Add Groceries product");
    Console.WriteLine("Press 3 to Add KitchenAccessories product");
    Console.WriteLine("Press 4 to show all products in memory");
    Console.WriteLine("Press 5 to delete products from file");
    Console.WriteLine("Press 6 to delete products from file");
    Console.WriteLine("To exit insert 'x' ");
    Console.WriteLine("Choose option again.");
    var userInPut = Console.ReadLine();
    try
    {
        switch (userInPut)
        {
            case "1":
                Console.WriteLine("Press information to Add AGD product");
                Console.WriteLine("*************************************");

                Console.WriteLine("Insert name");
                var nameAGD = Console.ReadLine();

                Console.WriteLine("Insert Location");
                var locationAGD = Console.ReadLine();

                Console.WriteLine("Insert Count");
                var countAGD = Console.ReadLine();
                int countAGDInt = AddInt(countAGD);
             
                Console.WriteLine("Insert guarantee date: (yyyy-MM-dd)");
                string dateString = Console.ReadLine();
                DateTime endDate = AddDateTime(dateString);
               
                inwentoryAGD.Add(new AGD { Name = nameAGD, Location = locationAGD, Count = countAGDInt, GuaranteeDate = endDate, DateChange = DateTime.Now });
                inwentoryToFileAGD.Add(new AGD { Name = nameAGD, Location = locationAGD, Count = countAGDInt, GuaranteeDate = endDate, DateChange = DateTime.Now });
                inwentoryAGD.Save();
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert AGD ?");
                Console.WriteLine("Insert Y - Yes, N - No.");

                var userChosse = Console.ReadLine();
                if (userChosse == "Y" || userChosse == "y")
                {
                    inwentoryToFileAGD.Save();
                }
                else if (userChosse == "N" || userChosse == "n")
                {
                    Console.WriteLine("Okey, program doesn't save AGD ?");
                }
                else
                {
                    throw new Exception("Incorrect chose");
                }

                break;

            case "2":
                Console.WriteLine("Press information to add Groceries");
                Console.WriteLine("*************************************");
                Console.WriteLine("Insert name");
                var nameGroceries = Console.ReadLine();
                Console.WriteLine("Insert Location");
                var locationGroceries = Console.ReadLine();
                Console.WriteLine("Insert Count");
                var countGroceries = Console.ReadLine();
                int countcountGroceriesInt = AddInt(countGroceries);
                            
                inwentoryGroceries.Add(new Groceries { Name = nameGroceries, Location = locationGroceries, Count = countcountGroceriesInt, DateChange = DateTime.Now });
                inwentoryToFileGroceries.Add(new Groceries { Name = nameGroceries, Location = locationGroceries, Count = countcountGroceriesInt, DateChange = DateTime.Now });
                inwentoryGroceries.Save();
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert Groceries ?");
                Console.WriteLine("Insert Y - Yes, N - No.");

                var userChosse1 = Console.ReadLine();
                if (userChosse1 == "Y" || userChosse1 == "y")
                {

                    inwentoryToFileGroceries.SaveGroceries();
                }
                else if (userChosse1 == "N" || userChosse1 == "n")
                {
                    Console.WriteLine("Okey, program doesn't save Groceries ?");
                }
                else
                {
                    throw new Exception("Incorrect chose ");
                }

                break;

            case "3":
                Console.WriteLine("Insert name");
                var nameKitchenAccessories = Console.ReadLine();
                Console.WriteLine("Insert Location");
                var locationKitchenAccessories = Console.ReadLine();
                Console.WriteLine("Insert Count");
                var countKitchenAccessories = Console.ReadLine();
                int countKitchenAccessoriesInt;
                countKitchenAccessoriesInt = AddInt(countKitchenAccessories);
            
                inwentoryKitchenAccessories.Add(new KitchenAccessories { Name = nameKitchenAccessories, Location = locationKitchenAccessories, Count = countKitchenAccessoriesInt, DateChange = DateTime.Now });
                inwentoryToFileKitchenAccessories.Add(new KitchenAccessories { Name = nameKitchenAccessories, Location = locationKitchenAccessories, Count = countKitchenAccessoriesInt, DateChange = DateTime.Now });
                inwentoryKitchenAccessories.Save();

                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert Groceries ?");
                Console.WriteLine("Insert Y - Yes, N - No.");

                var userChosse2 = Console.ReadLine();
                if (userChosse2 == "Y" || userChosse2 == "y")
                {
                    inwentoryToFileKitchenAccessories.SaveKitchenAccessories();
                }
                else if (userChosse2 == "N" || userChosse2 == "n")
                {
                    Console.WriteLine("Okey, program doesn't save Groceries ?");
                }
                else
                {
                    throw new Exception("Incorrect chose ");
                }
                break;

            case "4":
                inwentoryAGD.WriteAllToConsole(inwentoryAGD);
                inwentoryGroceries.WriteAllToConsole(inwentoryGroceries);
                inwentoryKitchenAccessories.WriteAllToConsole(inwentoryKitchenAccessories);

                break;
            case "5":
                inwentoryToFileAGD.WriteAllConsoleFromFile(inwentoryToFileAGD);
                inwentoryToFileGroceries.WriteAllConsoleFromFileGroceries(inwentoryToFileGroceries);
                inwentoryToFileKitchenAccessories.WriteAllConsoleFromFileKitchenAccessories(inwentoryToFileKitchenAccessories);
                break;
            case "6":
                Console.WriteLine("Which name contact you want delete ?");
                Console.WriteLine("Enter the Id of user you want to delete");
                try
                {
                    //repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
                    // repository.Save();
                }
                catch
                {
                    Console.WriteLine("wrong option");
                }
                break;
            case "x":
            case "X":
                return;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Exception caught: {e.Message}");
    }

    static int AddInt(string value)
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


    static DateTime AddDateTime(string value)
    {
        if (DateTime.TryParse(value, out DateTime date))
        {
            Console.WriteLine("The conversion success.");
        }
        else
        {
            Console.WriteLine("The conversion wasn't successful.");
        }
        return date;
    }

    //userRepository.ItemAdded += userRepositoryOnItemAdded;
    //userRepository.ItemRemove += userRepositoryOnItemRemove;


    //static void WriteAllToConsole(IReadRepository<IEntity> repository)
    //{
    //    var items = repository.GetAll();

    //    if (items.Any())
    //    {
    //        foreach (var item in items)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }
    //    else
    //    {
    //        Console.WriteLine("elements not found");
    //    }
    //    Console.ReadKey();//waiting
    //}

    //static void RemoveUser(IRepository<User> repository)
    //{
    //    Console.WriteLine("Enter the Id of user you want to delete");
    //    try
    //    {
    //        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
    //        repository.Save();
    //    }
    //    catch
    //    {
    //        Console.WriteLine("wrong option");
    //    }
    //}

    //static void ClearDb(IRepository<User> repository)
    //{
    //    var items = repository.GetAll();

    //    if (items.Any())
    //    {
    //        foreach (var item in items)
    //        {
    //            repository.Remove(item);
    //        }
    //        repository.Save();

    //        Console.WriteLine("Db is claen!");
    //        Console.ReadKey();
    //    }
    //    else
    //    {
    //        Console.WriteLine("Db is null");
    //    }
    //}

}



