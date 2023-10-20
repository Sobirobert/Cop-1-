using WhatWhere.Data;
using WhatWhere.Entities;
using WhatWhere.Repositories;

var inwetoryAGD = new SqlRepository<AGD>(new WhatWhereDbContext());
var inwetoryAGDList = new ListRepository<AGD>();

var inwetoryGroceries = new SqlRepository<Groceries>(new WhatWhereDbContext());
var inwetoryGroceriesList = new ListRepository<Groceries>();

var inwetoryKitchenAccessories = new SqlRepository<KitchenAccessories>(new WhatWhereDbContext());
var inwetoryKitchenAccessoriesList = new ListRepository<KitchenAccessories>();


AddAGD(inwetoryAGD);
AddAGDToList(inwetoryAGDList);
AddGroceries(inwetoryGroceries);
AddGroceriesToList(inwetoryGroceriesList);
AddKitchenAccessories(inwetoryKitchenAccessories);
AddKitchenAccessoriesToList(inwetoryKitchenAccessoriesList);
WriteAllConsole(inwetoryAGD);
WriteAllConsoleAGDToList(inwetoryAGDList);
WriteAllConsole(inwetoryGroceries);
WriteAllConsoleGroceriesToList(inwetoryGroceriesList);
WriteAllConsole(inwetoryKitchenAccessories);
WriteAllConsoleKitchenAccessoriesToList(inwetoryKitchenAccessoriesList);

static void AddAGD(IRepository<AGD> agdRepository)
{
    agdRepository.Add(new AGD { Name = "Microwave", Location = "Right furniture post", Count = 1});
    agdRepository.Add(new AGD { Name = "Electric Oven", Location = "Right furniture post", Count = 1 });
    agdRepository.Add(new AGD { Name = "Blender", Location = "Lower Kitchen Cabinets, second from the left", Count = 1 });
    agdRepository.Save();
}
static void AddAGDToList(ListRepository<AGD> agdRepository)
{
    agdRepository.Add(new AGD { Name = "Microwave", Location = "Right furniture post", Count = 1 });
    agdRepository.Add(new AGD { Name = "Electric Oven", Location = "Right furniture post", Count = 1 });
    agdRepository.Add(new AGD { Name = "Blender", Location = "Lower Kitchen Cabinets, second from the left", Count = 1 });
    agdRepository.Save();
}

static void AddGroceries(IRepository<Groceries> groceriesRepository)
{
    groceriesRepository.Add(new Groceries { Name = "Pot 5l", Location = "Lower Kitchen Cabinets, second from the right", Count = 2 });
    groceriesRepository.Add(new Groceries { Name = "Sieve", Location = "Right furniture post", Count = 3 });
    groceriesRepository.Add(new Groceries { Name = "Vegetable Grater", Location = "Lower Kitchen Cabinets, first from the right", Count = 2 });
    groceriesRepository.Save();
}
static void AddGroceriesToList(ListRepository<Groceries> groceriesRepository)
{
    groceriesRepository.Add(new Groceries { Name = "Pot 5l", Location = "Lower Kitchen Cabinets, second from the right", Count = 2 });
    groceriesRepository.Add(new Groceries { Name = "Sieve", Location = "Right furniture post", Count = 3 });
    groceriesRepository.Add(new Groceries { Name = "Vegetable Grater", Location = "Lower Kitchen Cabinets, first from the right", Count = 2 });
    groceriesRepository.Save();
}

static void AddKitchenAccessories(IRepository<KitchenAccessories> kitchenAccessoriesRepository)
{
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Tomato", Location = "The bottom drawer of the refrigerator", Count = 1 });
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Butter", Location = "The bottom drawer of the refrigerator", Count = 3 });
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Potato", Location = "The bottom drawer of the refrigerator", Count = 5 });
    kitchenAccessoriesRepository.Save();
}
static void AddKitchenAccessoriesToList(ListRepository<KitchenAccessories> kitchenAccessoriesRepository)
{
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Tomato", Location = "The bottom drawer of the refrigerator", Count = 1 });
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Butter", Location = "The bottom drawer of the refrigerator", Count = 3 });
    kitchenAccessoriesRepository.Add(new KitchenAccessories { Name = "Potato", Location = "The bottom drawer of the refrigerator", Count = 5 });
    kitchenAccessoriesRepository.Save();
}




static void WriteAllConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void WriteAllConsoleAGDToList(ListRepository<AGD> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
static void WriteAllConsoleGroceriesToList(ListRepository<Groceries> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
static void WriteAllConsoleKitchenAccessoriesToList(ListRepository<KitchenAccessories> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}