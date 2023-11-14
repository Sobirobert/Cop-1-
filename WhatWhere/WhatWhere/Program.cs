using WhatWhere.Data;
using WhatWhere.Entities;
using WhatWhere.Repositories;

#region Eventy

static void ThingAddedAGD(AGD item)
{
    Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
}
static void ThingAddedGroceries(Groceries item)
{
    Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
}
static void ThingAddedKitchenAccessories(KitchenAccessories item)
{
    Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
}
static void ThingAGDRepositoryOnItemAdded(object? sender, AGD e)
{
    Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
}
static void ThingGroceriesRepositoryOnItemAdded(object? sender, Groceries e)
{
    Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
}
static void ThingKitchenAccessoriesRepositoryOnItemAdded(object? sender, KitchenAccessories e)
{
    Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
}
static void ThingAGDRepositoryOnItemRemove(object? sender, AGD e)
{
    Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
}
static void ThingGroceriesRepositoryOnItemRemove(object? sender, Groceries e)
{
    Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
}
static void ThingKitchenAccessoriesRepositoryOnItemRemove(object? sender, KitchenAccessories e)
{
    Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
}

#endregion Eventy

var inwentoryAGD = new SqlRepository<AGD>(new WhatWhereDbContext(), ThingAddedAGD);
var inwentoryGroceries = new SqlRepository<Groceries>(new WhatWhereDbContext(), ThingAddedGroceries);
var inwentoryKitchenAccessories = new SqlRepository<KitchenAccessories>(new WhatWhereDbContext(), ThingAddedKitchenAccessories);
var inwentoryToFileAGD = new RepositoryToFileJson<AGD>();
var inwentoryToFileGroceries = new RepositoryToFileJson<Groceries>();
var inwentoryToFileKitchenAccessories = new RepositoryToFileJson<KitchenAccessories>();

inwentoryAGD.ItemAdded += ThingAGDRepositoryOnItemAdded;
inwentoryGroceries.ItemAdded += ThingGroceriesRepositoryOnItemAdded;
inwentoryKitchenAccessories.ItemAdded += ThingKitchenAccessoriesRepositoryOnItemAdded;
inwentoryAGD.ItemRemove += ThingAGDRepositoryOnItemRemove;
inwentoryGroceries.ItemRemove += ThingGroceriesRepositoryOnItemRemove;
inwentoryKitchenAccessories.ItemRemove += ThingKitchenAccessoriesRepositoryOnItemRemove;

while (true)
{
    Console.WriteLine("Hello User.");
    Console.WriteLine("Choose option");
    Console.WriteLine("Press 1 to Add AGD product");
    Console.WriteLine("Press 2 to Add Groceries product");
    Console.WriteLine("Press 3 to Add KitchenAccessories product");
    Console.WriteLine("Press 4 to show all products in memory");
    Console.WriteLine("Press 5 to show all products from file");
    Console.WriteLine("Press 6 to clear all products from file");
    Console.WriteLine("Press 7 to clear all products in memory");
    Console.WriteLine("Press 8 to remove one products in memory");
    Console.WriteLine("Press 9 to remove one products from File");
    Console.WriteLine("To exit insert 'x' ");
    Console.WriteLine("Choose option again.");
    var userInPut = Console.ReadLine();
    try
    {
        switch (userInPut)
        {
            #region case "1"

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

            #endregion case "1"

            #region case "2"

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

            #endregion case "2"

            #region case "3"

            case "3":
                Console.WriteLine("Press information to add Groceries");
                Console.WriteLine("*************************************");

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

            #endregion case "3"

            #region case "4"

            case "4":
                inwentoryAGD.WriteAllToConsole(inwentoryAGD);
                inwentoryGroceries.WriteAllToConsole(inwentoryGroceries);
                inwentoryKitchenAccessories.WriteAllToConsole(inwentoryKitchenAccessories);

                break;

            #endregion case "4"

            #region case "5"

            case "5":
                inwentoryToFileAGD.WriteAllConsoleFromFile(inwentoryToFileAGD);
                inwentoryToFileGroceries.WriteAllConsoleFromFileGroceries(inwentoryToFileGroceries);
                inwentoryToFileKitchenAccessories.WriteAllConsoleFromFileKitchenAccessories(inwentoryToFileKitchenAccessories);
                break;

            #endregion case "5"

            #region case "6"

            case "6":
                Console.WriteLine("Do you want clear the files ?");
                Console.WriteLine("Press Y - yes or N - not.");
                var userInPut2 = Console.ReadLine();
                if (userInPut2 == "y" || userInPut2 == "Y")
                {
                    inwentoryToFileAGD.ClearFile();
                    Console.WriteLine("Memory wipe successful.");
                }
                else if (userInPut2 == "n" || userInPut2 == "N")
                {
                    return;
                }
                else
                {
                    throw new Exception("incorrect value");
                }
                break;

            #endregion case "6"

            #region case "7"

            case "7":
                Console.WriteLine("Do you want clear memory ?");
                Console.WriteLine("Press Y - yes or N - not.");
                var userInPut3 = Console.ReadLine();
                if (userInPut3 == "y" || userInPut3 == "Y")
                {
                    RemoveAllMemory();
                }
                else if (userInPut3 == "n" || userInPut3 == "N")
                {
                    return;
                }
                else
                {
                    throw new Exception("incorrect value");
                }
                break;

            #endregion case "7"

            #region case "8"

            case "8":
                Console.WriteLine("What kind of product do you want delete?");
                Console.WriteLine("Insert 1 - AGD, insert 2 - Groceries, 3 - KitchenAccessories.");
                var userInPut5 = Console.ReadLine();
                if (userInPut5 == "1")
                {
                    RemoveAGDById(inwentoryAGD);
                }
                else if (userInPut5 == "2")
                {
                    RemoveGroceriesById(inwentoryGroceries);
                }
                else if (userInPut5 == "3")
                {
                    RemoveKitchenAccessoriesById(inwentoryKitchenAccessories);
                }
                else
                {
                    throw new Exception("Wrong number.");
                }
                break;

            #endregion case "8"

            #region case "9"

            case "9":
                Console.WriteLine("What kind of product do you want delete?");
                Console.WriteLine("Insert 1 - AGD, insert 2 - Groceries, 3 - KitchenAccessories.");
                var userInPut6 = Console.ReadLine();
                if (userInPut6 == "1")
                {
                    Console.WriteLine("Enter the Id of AGD you want to delete");
                    try
                    {
                        RemoveAGDById(inwentoryToFileAGD);
                    }
                    catch
                    {
                        Console.WriteLine("wrong option");
                    }
                }
                else if (userInPut6 == "2")
                {
                    Console.WriteLine("Enter the Id of Groceries do you want to delete");
                    try
                    {
                        RemoveGroceriesById(inwentoryToFileGroceries);
                    }
                    catch
                    {
                        Console.WriteLine("wrong option");
                    }
                }
                else if (userInPut6 == "3")
                {
                    Console.WriteLine("Enter the Id of Kitchen Accessories you want to delete");
                    try
                    {
                        RemoveKitchenAccessoriesById(inwentoryToFileKitchenAccessories);
                    }
                    catch
                    {
                        Console.WriteLine("wrong option");
                    }
                }
                else
                {
                    throw new Exception("Wrong number.");
                }
                break;

            #endregion case "9"

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

    #region AddInt

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

    #endregion AddInt

    #region AddDateTime

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

    #endregion AddDateTime

    #region RemoveAllMemory

    void RemoveAllMemory()
    {
        inwentoryAGD.RemoveAll();
        inwentoryGroceries.RemoveAll();
        inwentoryKitchenAccessories.RemoveAll();
    }

    #endregion RemoveAllMemory

    #region RemoveAGDById

    static void RemoveAGDById(IRepository<AGD> repository)
    {
        Console.WriteLine("Enter the Id of product you want to delete");
        try
        {
            repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
            repository.Save();
        }
        catch
        {
            Console.WriteLine("Id chose is out of reach");
        }
    }

    #endregion RemoveAGDById

    #region RemoveGroceriesById

    static void RemoveGroceriesById(IRepository<Groceries> repository)
    {
        Console.WriteLine("Enter the Id of product you want to delete");
        try
        {
            repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
            repository.Save();
        }
        catch
        {
            Console.WriteLine("Id chose is out of reach");
        }
    }

    #endregion RemoveGroceriesById

    #region RemoveKitchenAccessoriesById

    static void RemoveKitchenAccessoriesById(IRepository<KitchenAccessories> repository)
    {
        Console.WriteLine("Enter the Id of product you want to delete");
        try
        {
            repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
            repository.Save();
        }
        catch
        {
            Console.WriteLine("Id chose is out of reach");
        }
    }

    #endregion RemoveKitchenAccessoriesById
}