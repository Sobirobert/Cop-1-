using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
    Console.WriteLine("Press 4 to show all products");
    Console.WriteLine("Press 5 to delete products");
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
                int countAGDInt;

                if (int.TryParse(countAGD, out countAGDInt))
                {

                    Console.WriteLine("The conversion was successful.");
                }
                else
                {
                    Console.WriteLine("The conversion wasn't successful.");
                }

                Console.WriteLine("Insert guarantee date: (yyyy-MM-dd)");
                string dateString = Console.ReadLine();
                DateTime endDate;
                if (DateTime.TryParse(dateString, out endDate))
                {
                    Console.WriteLine("The conversion was successful.");
                }
                else
                {
                    Console.WriteLine("The conversion wasn't successful.");
                }

                inwentoryAGD.Add(new AGD { Name = nameAGD, Location = locationAGD, Count = countAGDInt, GuaranteeDate = endDate, DateChange = DateTime.Now });
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert AGD ?");
                Console.WriteLine("Insert Y - Yes, N - No.");
               
                var userChosse = Console.ReadLine();
                if (userChosse == "Y" || userChosse == "y")
                {
                    inwentoryToFileAGD.Add(new AGD { Name = nameAGD, Location = locationAGD, Count = countAGDInt, GuaranteeDate = endDate, DateChange = DateTime.Now });
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
                int countcountGroceriesInt;

                if (int.TryParse(countGroceries, out countcountGroceriesInt))
                {

                    Console.WriteLine("The conversion was successful.");
                }
                else
                {
                    Console.WriteLine("The conversion wasn't successful.");
                }
                inwentoryGroceries.Add(new Groceries { Name = nameGroceries, Location = locationGroceries, Count = countcountGroceriesInt, DateChange = DateTime.Now });

                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert Groceries ?");
                Console.WriteLine("Insert Y - Yes, N - No.");
                var userChosse1 = Console.ReadLine();
                if(userChosse1 == "Y" || userChosse1 ==  "y")
                {
                    inwentoryToFileGroceries.Add(new Groceries { Name = nameGroceries, Location = locationGroceries, Count = countcountGroceriesInt, DateChange = DateTime.Now });
                }
                else if (userChosse1 == "N"|| userChosse1 == "n")
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
                if (int.TryParse(countKitchenAccessories, out countKitchenAccessoriesInt))
                {

                    Console.WriteLine("The conversion was successful.");
                }
                else
                {
                    Console.WriteLine("The conversion wasn't successful.");
                }

                inwentoryKitchenAccessories.Add(new KitchenAccessories { Name = nameKitchenAccessories, Location = locationKitchenAccessories, Count = countKitchenAccessoriesInt, DateChange = DateTime.Now});
                Console.WriteLine("Success");
                Console.WriteLine("Do you want save insert Groceries ?");
                Console.WriteLine("Insert Y - Yes, N - No.");
                var userChosse2 = Console.ReadLine();
                if (userChosse2 == "Y" || userChosse2 == "y")
                {
                    inwentoryToFileKitchenAccessories.Add(new KitchenAccessories { Name = nameKitchenAccessories, Location = locationKitchenAccessories, Count = countKitchenAccessoriesInt, DateChange = DateTime.Now });
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
                WriteAllToConsole(inwentoryAGD);
                WriteAllToConsoleFromFileJson(inwentoryToFileAGD);
                WriteAllToConsole(inwentoryGroceries);
                WriteAllToConsoleFromFileJson(inwentoryToFileGroceries);
                WriteAllToConsole(inwentoryKitchenAccessories);
                WriteAllToConsoleFromFileJson(inwentoryToFileKitchenAccessories);
                break;
            case "5":
                Console.WriteLine("Which name contact you want delete ?");
                var userDeleteContact = Console.ReadLine();
                break;
            case "x":
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

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    static void WriteAllToConsoleFromFileJson(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    //var userRepository = new SqlRepository<User>(new UserDataDbContext());

    //userRepository.ItemAdded += userRepositoryOnItemAdded;
    //userRepository.ItemRemove += userRepositoryOnItemRemove;

    //static void userRepositoryOnItemAdded(object? sender, User e)
    //{

    //    if (e.Administrator == true)
    //    {
    //        string administrator = $"Administrator \"{e.NickName}\" added from class \"{sender?.GetType().Name}\", Date: {DateTime.Now}";
    //        Console.WriteLine(administrator);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(administrator);
    //        }
    //    }
    //    else if (e.Moderator == true)
    //    {
    //        string moderator = $"Moderator  \"{e.NickName}\" added from class \"{sender?.GetType().Name}\", Date: {DateTime.Now}";
    //        Console.WriteLine(moderator);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(moderator);
    //        }
    //    }
    //    else
    //    {
    //        string user = $"User \"{e.NickName}\" added from class \"{sender?.GetType().Name}\", Date:  {DateTime.Now}";
    //        Console.WriteLine(user);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(user);
    //        }
    //    }
    //}
    //static void userRepositoryOnItemRemove(object? sender, User e)
    //{
    //    if (e.Administrator == true)
    //    {
    //        string administrator = $"Administrator \"{e.NickName}\" remove from class \"{sender?.GetType().Name}\", Date:  {DateTime.Now}";
    //        Console.WriteLine(administrator);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(administrator);
    //        }
    //    }
    //    else if (e.Moderator == true)
    //    {
    //        string moderator = $"Moderator  \"{e.NickName}\" remove from class \"{sender?.GetType().Name}\", Date:   {DateTime.Now}";
    //        Console.WriteLine(moderator);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(moderator);
    //        }
    //    }
    //    else
    //    {
    //        string user = $"User \"{e.NickName}\" remove from class \"{sender?.GetType().Name}\", Date:   {DateTime.Now}";
    //        Console.WriteLine(user);
    //        using (var writer = File.AppendText("History.txt"))
    //        {
    //            writer.WriteLine(user);
    //        }
    //    }
    //}

    //do
    //{
    //    Menu();

    //    string input = Console.ReadLine();
    //    if (input == "q" || input == "Q")
    //        break;

    //    switch (input)
    //    {
    //        case "1":
    //            WriteAllToConsole(userRepository);
    //            break;
    //        case "2":
    //            AddUser(userRepository);
    //            break;
    //        case "3":
    //            RemoveUser(userRepository);
    //            break;
    //        case "4":
    //            ClearDb(userRepository);
    //            break;
    //        case "c":
    //        case "C":
    //            Console.Clear();
    //            break;
    //        default:
    //            Console.WriteLine("wrong option");
    //            break;
    //    }
    //} while (true);

    //static void Menu()
    //{
    //    Console.WriteLine("|----------------------MENU----------------------|");
    //    Console.WriteLine("1 - show the user table");
    //    Console.WriteLine("2 - register the user");
    //    Console.WriteLine("3 - delete the selected user");
    //    Console.WriteLine("4 - clear data base");
    //    Console.WriteLine("c - clear console");
    //    Console.WriteLine("q - exit the program");
    //}

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

    //static void AddUser(IRepository<User> userRepository)
    //{
    //    Console.WriteLine("Indicate user status (adm = administrator, mdr = moderator)");

    //    bool adminStatus = false;
    //    bool moderatorStatus = false;
    //    string status = Console.ReadLine();

    //    if (status == "Adm" || status == "adm" || status == "ADM" || status == "adM" || status == "aDm")
    //    {
    //        adminStatus = true;
    //    }
    //    else if (status == "Mdr" || status == "mdr" || status == "MDR" || status == "mdR" || status == "mDr")
    //    {
    //        moderatorStatus = true;
    //    }

    //    Console.WriteLine("Please provide the following information in this order:\n1. Nickname\n2. Login\n3. Password");

    //    userRepository.Add(new User { NickName = Console.ReadLine(), Password = Console.ReadLine(), Login = Console.ReadLine(), Administrator = adminStatus, Moderator = moderatorStatus });
    //    userRepository.Save();
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



