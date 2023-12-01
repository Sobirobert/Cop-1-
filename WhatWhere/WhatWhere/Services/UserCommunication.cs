using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public class UserCommunication : IUserCommunication
{
    private MethodsExtensions _methodsExtensions = new MethodsExtensions();
    private readonly IRepository<AGD> _agdRepositoryToJSON;
    private readonly IRepository<Groceries> _groceriesRepositoryToJSON;
    private readonly IRepository<KitchenAccessories> _kitchenAccessoriesRepositoryToJSON;

    public UserCommunication(IRepository<AGD> agdRepositoryToJSON, IRepository<Groceries> groceriesRepositoryToJSON, IRepository<KitchenAccessories> KitchenAccessoriesRepositoryToJSON)
    {
        _agdRepositoryToJSON = agdRepositoryToJSON;
        _groceriesRepositoryToJSON = groceriesRepositoryToJSON;
        _kitchenAccessoriesRepositoryToJSON = KitchenAccessoriesRepositoryToJSON;
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("Hello User.");
            Console.WriteLine("Choose option");
            Console.WriteLine("Press 1 to Add AGD product to JSON");
            Console.WriteLine("Press 2 to Add Groceries product to JSON");
            Console.WriteLine("Press 3 to Add KitchenAccessories product to JSON");
            Console.WriteLine("Press 4 to show all products from file");
            Console.WriteLine("Press 5 to clear all products from file");
            Console.WriteLine("Press 6 to find product by ID");
            Console.WriteLine("Press 7 to remove one products from File by ID");
            Console.WriteLine("To exit insert 'x' ");
            Console.WriteLine("Choose option again.");
            var userInPut = Console.ReadLine();

            switch (userInPut)
            {
                case "1":
                    Console.WriteLine("Press information to Add AGD product");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddAGDObjectToMemory(_agdRepositoryToJSON);
                    break;

                case "2":
                    Console.WriteLine("Press information to Add AGD product");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddGroceriesObjectToMemory(_groceriesRepositoryToJSON);
                    break;

                case "3":
                    Console.WriteLine("Press information to Add AGD product");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddKitchenAccessoriesObjectToMemory(_kitchenAccessoriesRepositoryToJSON);
                    break;

                case "4":
                    _agdRepositoryToJSON.WriteAllConsoleFromFileAGD(_agdRepositoryToJSON);
                    _groceriesRepositoryToJSON.WriteAllConsoleFromFileGroceries(_groceriesRepositoryToJSON);
                    _kitchenAccessoriesRepositoryToJSON.ReadAllConsoleFromFileKitchenAccessories(_kitchenAccessoriesRepositoryToJSON);
                    break;

                case "5":
                    _agdRepositoryToJSON.ClearAllFile();
                    break;

                case "6":
                    Console.WriteLine("What kind of product do you want find?");
                    Console.WriteLine("Insert 1 - AGD, insert 2 - Groceries, 3 - KitchenAccessories.");
                    var userInPut2 = Console.ReadLine();
                    if (userInPut2 == "1")
                    {
                        Console.WriteLine("Enter the Id of AGD which do you want to find");
                        try
                        {
                            var userInPut3 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut3);
                            var findeById = _agdRepositoryToJSON.GetByIdAGD(intUserInPut);
                            Console.WriteLine($"{findeById}");
                        }
                        catch
                        {
                            Console.WriteLine("wrong option");
                        }
                    }
                    else if (userInPut2 == "2")
                    {
                        Console.WriteLine("Enter the Id of Groceries which do you want to find");
                        try
                        {
                            var userInPut4 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut4);
                            var findeById = _groceriesRepositoryToJSON.GetByIdGroceries(intUserInPut);
                            Console.WriteLine($"{findeById}");
                        }
                        catch
                        {
                            Console.WriteLine("wrong option");
                        }
                    }
                    else if (userInPut2 == "3")
                    {
                        Console.WriteLine("Enter the Id of Kitchen Accessories which do you want to find");
                        try
                        {
                            var userInPut5 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut5);
                            var findeById = _kitchenAccessoriesRepositoryToJSON.GetByIdKitchenAccessories(intUserInPut);
                            Console.WriteLine($"{findeById}");
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

                case "7":
                    Console.WriteLine("What kind of product do you want delete?");
                    Console.WriteLine("Insert 1 - AGD, insert 2 - Groceries, 3 - KitchenAccessories.");
                    var inPut = Console.ReadLine();
                    if (inPut == "1")
                    {
                        Console.WriteLine("Enter the Id of AGD which do you want to delete");
                        try
                        {
                            var userInPut5 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut5);
                            _agdRepositoryToJSON.RemoveAGDById(intUserInPut);
                            Console.WriteLine("Success");
                        }
                        catch
                        {
                            Console.WriteLine("wrong option");
                        }
                    }
                    else if (inPut == "2")
                    {
                        Console.WriteLine("Enter the Id of Groceries which do you want to delete");
                        try
                        {
                            var userInPut5 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut5);
                            _groceriesRepositoryToJSON.RemoveGroceriesById(intUserInPut);
                            Console.WriteLine("Success");
                        }
                        catch
                        {
                            Console.WriteLine("wrong option");
                        }
                    }
                    else if (inPut == "3")
                    {
                        Console.WriteLine("Enter the Id of Kitchen Accessories which do you want to delete");
                        try
                        {
                            var userInPut5 = Console.ReadLine();
                            var intUserInPut = _methodsExtensions.AddStringConversionToInt(userInPut5);
                            _kitchenAccessoriesRepositoryToJSON.RemoveKitchenAccessoriesById(intUserInPut);
                            Console.WriteLine("Success");
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

                case "x":
                case "X":
                    return;

                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }
}