using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public class UserCommunication : IUserCommunication
{
    MethodsExtensions _methodsExtensions = new MethodsExtensions();
    private readonly IRepository<AGD> _agdRepository;
    private readonly IRepository<Groceries> _groceriesRepository;
    private readonly IRepository<KitchenAccessories> _kitchenAccessoriesRepository;
    private readonly RepositoryToFileJson<AGD> _agdRepositoryToJSON;
    private readonly RepositoryToFileJson<Groceries> _groceriesRepositoryToJSON;
    private readonly RepositoryToFileJson<KitchenAccessories> _kitchenAccessoriesRepositoryToJSON;

    public UserCommunication(IRepository<AGD> agdRepository, IRepository<Groceries> groceriesRepository, IRepository<KitchenAccessories> KitchenAccessoriesRepository,
        RepositoryToFileJson<AGD> agdRepositoryToJSON, RepositoryToFileJson<Groceries> groceriesRepositoryToJSON, RepositoryToFileJson<KitchenAccessories> KitchenAccessoriesRepositoryToJSON)
    {
        _agdRepository = agdRepository;
        _groceriesRepository = groceriesRepository;
        _kitchenAccessoriesRepository = KitchenAccessoriesRepository;
        _agdRepositoryToJSON = agdRepositoryToJSON;
        _groceriesRepositoryToJSON = groceriesRepositoryToJSON;
        _kitchenAccessoriesRepositoryToJSON = KitchenAccessoriesRepositoryToJSON;
    }

    public UserCommunication()
    { }

    public void Menu()
    {
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

            switch (userInPut)
            {
                #region case 1

                case "1":
                    Console.WriteLine("Press information to Add AGD product");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddObjectToMemory<AGD>(_agdRepository);
                    break;

                #endregion case 1

                #region case "2"

                case "2":
                    Console.WriteLine("Press information to add Groceries");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddObjectToMemory<Groceries>(_groceriesRepository);

                    break;

                #endregion case "2"

                #region case "3"

                case "3":
                    Console.WriteLine("Press information to add Groceries");
                    Console.WriteLine("*************************************");
                    _methodsExtensions.AddObjectToMemory<KitchenAccessories>(_kitchenAccessoriesRepository);
                    break;

                #endregion case "3"

                #region case "4"

                case "4":
                    _methodsExtensions.WriteAllToConsole(_agdRepository);
                    _methodsExtensions.WriteAllToConsole(_groceriesRepository);
                    _methodsExtensions.WriteAllToConsole(_kitchenAccessoriesRepository);
                    break;

                #endregion case "4"

                #region case "5"

                case "5":
                    _agdRepositoryToJSON?.WriteAllConsoleFromFile(_agdRepositoryToJSON);
                    _groceriesRepositoryToJSON?.WriteAllConsoleFromFileGroceries(_groceriesRepositoryToJSON);
                    _kitchenAccessoriesRepositoryToJSON?.WriteAllConsoleFromFileKitchenAccessories(_kitchenAccessoriesRepositoryToJSON);
                    break;

                #endregion case "5"

                #region case "6"

                case "6":
                    Console.WriteLine("Do you want clear the files ?");
                    Console.WriteLine("Press Y - yes or N - not.");
                    var userInPut2 = Console.ReadLine();
                    if (userInPut2 == "y" || userInPut2 == "Y")
                    {
                        _agdRepositoryToJSON.ClearFile();
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
                        // RemoveAllMemory();
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
                        // RemoveAGDById(_agdRepository);
                    }
                    else if (userInPut5 == "2")
                    {
                        // RemoveGroceriesById(_groceriesRepository);
                    }
                    else if (userInPut5 == "3")
                    {
                        //RemoveKitchenAccessoriesById(_kitchenAccessoriesRepository);
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
                            //RemoveAGDById(_agdRepositoryToJSON);
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
                            //RemoveGroceriesById(_groceriesRepositoryToJSON);
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
                            //RemoveKitchenAccessoriesById(_kitchenAccessoriesRepositoryToJSON);
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
    }
    //public static void AddAGDToFile(RepositoryToFileJson<AGD> agdRepository)
    //{
    //    Console.WriteLine("Insert name");
    //    var nameAGD = Console.ReadLine();

    //    Console.WriteLine("Insert Location");
    //    var locationAGD = Console.ReadLine();

    //    Console.WriteLine("Insert Count");
    //    var countAGD = Console.ReadLine();
    //    int countAGDInt = AddInt(countAGD);

    //    Console.WriteLine("Insert guarantee date: (yyyy-MM-dd)");
    //    string dateString = Console.ReadLine();
    //    DateTime endDate = AddDateTime(dateString);

    //    var newAGD = new AGD
    //    {
    //        Name = nameAGD,
    //        Location = locationAGD,
    //        Count = countAGDInt,
    //        GuaranteeDate = endDate,
    //        DateChange = DateTime.Now
    //    };
    //    agdRepository.Add(newAGD);
    //    Console.WriteLine("Do you want save insert AGD ?");
    //    Console.WriteLine("Insert Y - Yes, N - No.");

    //    var userChosse = Console.ReadLine();
    //    if (userChosse == "Y" || userChosse == "y")
    //    {
    //        agdRepository.Save();
    //        Console.WriteLine("Success");
    //    }
    //    else if (userChosse == "N" || userChosse == "n")
    //    {
    //        Console.WriteLine("Okey, program doesn't save AGD. ");
    //    }
    //    else
    //    {
    //        throw new Exception("Incorrect chose");
    //    }
    //}

    //public static void AddKitchenAccessories(IRepository<KitchenAccessories> Repository)
    //{
    //    Console.WriteLine("Insert name");
    //    var nameKitchenAccessories = Console.ReadLine();

    //    Console.WriteLine("Insert Location");
    //    var locationKitchenAccessories = Console.ReadLine();

    //    Console.WriteLine("Insert Count");
    //    var countKitchenAccessories = Console.ReadLine();
    //    int countKitchenAccessoriesInt;
    //    countKitchenAccessoriesInt = AddInt(countKitchenAccessories);
    //    var newObjcet = new KitchenAccessories 
    //    { 
    //        Name = nameKitchenAccessories, 
    //        Location = locationKitchenAccessories, 
    //        Count = countKitchenAccessoriesInt,
    //        DateChange = DateTime.Now 
    //    };
    //    Repository.Add(newObjcet);
    //    Console.WriteLine("Success");


    //RepositoryToFile?.Add(newObjcet);
    //Console.WriteLine("Do you want save insert Groceries ?");
    //Console.WriteLine("Insert Y - Yes, N - No.");

    //var userChosse = Console.ReadLine();
    //if (userChosse == "Y" || userChosse == "y")
    //{
    //    RepositoryToFile?.SaveKitchenAccessories();
    //}
    //else if (userChosse == "N" || userChosse == "n")
    //{
    //    Console.WriteLine("Okey, program doesn't save Groceries ?");
    //}
    //else
    //{
    //    throw new Exception("Incorrect chose ");
    //}


    //public void RemoveAllMemory()
    //{
    //    _agdRepository.RemoveAll();
    //    _groceriesRepository.RemoveAll();
    //    _kitchenAccessoriesRepository.RemoveAll();
    //}

   

    //public static void RemoveAGDById(IRepository<AGD> repository)
    //{
    //    Console.WriteLine("Enter the Id of product you want to delete");
    //    try
    //    {
    //        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
    //        repository.Save();
    //    }
    //    catch
    //    {
    //        Console.WriteLine("Id chose is out of reach");
    //    }
    //}



    //public static void RemoveGroceriesById(IRepository<Groceries> repository)
    //{
    //    Console.WriteLine("Enter the Id of product you want to delete");
    //    try
    //    {
    //        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
    //        repository.Save();
    //    }
    //    catch
    //    {
    //        Console.WriteLine("Id chose is out of reach");
    //    }
    //}

    //#endregion RemoveGroceriesById

    //#region RemoveKitchenAccessoriesById

    //public static void RemoveKitchenAccessoriesById(IRepository<KitchenAccessories> repository)
    //{
    //    Console.WriteLine("Enter the Id of product you want to delete");
    //    try
    //    {
    //        repository.Remove(repository.GetById(int.Parse(Console.ReadLine())));
    //        repository.Save();
    //    }
    //    catch
    //    {
    //        Console.WriteLine("Id chose is out of reach");
    //    }
    //}

 
}