using WhatWhere.Data;
using WhatWhere.Entities;
using WhatWhere.Repositories;

var inwetoryAGD = new SqlRepository<AGD>(new WhatWhereDbContext());
var inwetoryGroceries = new SqlRepository<Groceries>(new WhatWhereDbContext());
var inwetoryKitchenAccessories = new SqlRepository<KitchenAccessories>(new WhatWhereDbContext());

AddAGD(inwetoryAGD);
AddGroceries(inwetoryGroceries);
AddKitchenAccessories(inwetoryKitchenAccessories);
WriteAllConsole(inwetoryAGD);
WriteAllConsole(inwetoryGroceries);
WriteAllConsole(inwetoryKitchenAccessories);

static void AddAGD(IRepository<AGD> agdRepository)
{
    agdRepository.Add(new AGD { Name = "Microwave", Location = "Right furniture post", Count = 1});
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

static void AddKitchenAccessories(IRepository<KitchenAccessories> kitchenAccessoriesRepository)
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