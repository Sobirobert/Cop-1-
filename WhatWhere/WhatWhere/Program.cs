using System.Xml.Linq;
using WhatWhere.Data;
using WhatWhere.Entities;
using WhatWhere.Repositories;

var inwentoryAGD = new SqlRepository<AGD>(new WhatWhereDbContext());
var inwentoryGroceries = new SqlRepository<Groceries>(new WhatWhereDbContext());
var inwentoryKitchenAccessories = new SqlRepository<KitchenAccessories>(new WhatWhereDbContext());


Console.WriteLine("Hello User.");
Console.WriteLine("Choose option");
Console.WriteLine("Press 1 to Add AGD product");
Console.WriteLine("Press 2 to Add Groceries product");
Console.WriteLine("Press 3 to Add KitchenAccessories product");
Console.WriteLine("Press 4 to Search contacts");
Console.WriteLine("Press 5 to delete contacts");
Console.WriteLine("To exit insert 'x' ");
Console.WriteLine("Choose option again.");

var userInPut = Console.ReadLine();

try
{
    switch (userInPut)
    {
        case "1":
            Console.WriteLine("Press 1 to Add AGD product");
            Console.WriteLine("Press 2 to Add Groceries product");
            Console.WriteLine("Press 3 to Add KitchenAccessories product");
            Console.WriteLine("Insert number");
            var number = Console.ReadLine();
            if (number == "1")
            {

                Console.WriteLine("Insert name");
                var nameAGD = Console.ReadLine();
                Console.WriteLine("Insert Location");
                var locationAGD = Console.ReadLine();
                Console.WriteLine("Insert Count");
                var countAGD = Console.ReadLine();
                int countAGDInt;

                if (int.TryParse(countAGD, out countAGDInt))
                {

                    Console.WriteLine("Konwersja powiodła się.");
                }
                else
                {
                    Console.WriteLine("Konwersja nie powiodła się.");
                }

                var newAGD = new AGD(nameAGD, locationAGD, countAGDInt);
                inwentoryAGD.Add(newAGD);
            }
            else if (number == "2")
            {
                Console.WriteLine("Insert name");
                var nameGroceries = Console.ReadLine();
                Console.WriteLine("Insert Location");
                var locationGroceries = Console.ReadLine();
                Console.WriteLine("Insert Count");
                var countGroceries = Console.ReadLine();
                int countcountGroceriesInt;

                if (int.TryParse(countGroceries, out countcountGroceriesInt))
                {

                    Console.WriteLine("Konwersja powiodła się.");
                }
                else
                {
                    Console.WriteLine("Konwersja nie powiodła się.");
                }

                var newGroceries = new Groceries(nameGroceries, locationGroceries, countcountGroceriesInt);
            }
            else if (number == "3")
            {
                Console.WriteLine("Insert name");
                var nameKitchenAccessories = Console.ReadLine();
                Console.WriteLine("Insert Location");
                var locationKitchenAccessories = Console.ReadLine();
                Console.WriteLine("Insert Count");
                var countKitchenAccessories = Console.ReadLine();
                int countKitchenAccessoriesInt;
                if (int.TryParse(countKitchenAccessories, out countKitchenAccessoriesInt))
                {

                    Console.WriteLine("Konwersja powiodła się.");
                }
                else
                {
                    Console.WriteLine("Konwersja nie powiodła się.");
                }
                var kitchenAccessories = new KitchenAccessories(nameKitchenAccessories, locationKitchenAccessories, countKitchenAccessoriesInt);
            }
            else
            {
                throw new Exception("Incoret value");
            }
            break;
        case "2":
            Console.WriteLine("Insert number");
            var numberToSearch = Console.ReadLine();

            //phoneBook.DisplayMatchingContactNumber(numberToSearch);
            break;

        case "3":
            //  phoneBook.DisplayAllContacts();
            break;

        case "4":
            Console.WriteLine("Insert search phrase");
            var searchPhrase = Console.ReadLine();
            // phoneBook.DisplayMatchingContact(searchPhrase);
            break;

        case "5":
            Console.WriteLine("Which name contact you want delete ?");
            var userDeleteContact = Console.ReadLine();
            //  phoneBook.RemoveContact(userDeleteContact);
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
    Console.WriteLine($"Exeption catched: {e.Message}");
}


//AddAGD(inwetoryAGD);
//AddGroceries(inwetoryGroceries);
//AddKitchenAccessories(inwetoryKitchenAccessories);
//WriteAllConsole(inwetoryAGD);
//WriteAllConsole(inwetoryGroceries);
//WriteAllConsole(inwetoryKitchenAccessories);

//static void AddAGD(IRepository<AGD> agdRepository)
//{
//    agdRepository.Add(new AGD { Name = "Microwave", Location = "Right furniture post", Count = 1 });
//    agdRepository.Add(new AGD { Name = "Electric Oven", Location = "Right furniture post", Count = 1 });
//    agdRepository.Add(new AGD { Name = "Blender", Location = "Lower Kitchen Cabinets, second from the left", Count = 1 });
//    agdRepository.Save();
//}

//static void AddGroceries(IRepository<Groceries> groceriesRepository)
//{
//    groceriesRepository.Add(new Groceries { Name = "Pot 5l", Location = "Lower Kitchen Cabinets, second from the right", Count = 2 });
//    groceriesRepository.Add(new Groceries { Name = "Sieve", Location = "Right furniture post", Count = 3 });
//    groceriesRepository.Add(new Groceries { Name = "Vegetable Grater", Location = "Lower Kitchen Cabinets, first from the right", Count = 2 });
//    groceriesRepository.Save();
//}
//static void AddKitchenAccessories(IRepository<KitchenAccessories> kitchenAccessoriesRepository)
//{
//    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Tomato", Location = "The bottom drawer of the refrigerator", Count = 1 });
//    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Butter", Location = "The bottom drawer of the refrigerator", Count = 3 });
//    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Potato", Location = "The bottom drawer of the refrigerator", Count = 5 });
//    kitchenAccessoriesRepository.Save();
//}




static void WriteAllConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

