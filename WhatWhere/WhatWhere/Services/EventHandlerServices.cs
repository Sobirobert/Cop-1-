using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public class EventHandlerServices : IEventHandlerServices
{
    private readonly IRepository<AGD> _agdRepository;
    private readonly IRepository<Groceries> _groceriesRepository;
    private readonly IRepository<KitchenAccessories> _kitchenAccessoriesRepository;

    public EventHandlerServices(IRepository<AGD> agdRepository, IRepository<Groceries> groceriesRepository, IRepository<KitchenAccessories> kitchenAccessoriesRepository)
    {
        _agdRepository = agdRepository;
        _groceriesRepository = groceriesRepository;
        _kitchenAccessoriesRepository = kitchenAccessoriesRepository;
    }

    public void SubscribeToEvents()
    {
        _agdRepository.ItemAdded += ThingAGDRepositoryOnItemAdded;
        _groceriesRepository.ItemAdded += ThingGroceriesRepositoryOnItemAdded;
        _kitchenAccessoriesRepository.ItemAdded += ThingKitchenAccessoriesRepositoryOnItemAdded;
        _agdRepository.ItemRemoved += ThingAGDRepositoryOnItemRemove;
        _groceriesRepository.ItemRemoved += ThingGroceriesRepositoryOnItemRemove;
        _kitchenAccessoriesRepository.ItemRemoved += ThingKitchenAccessoriesRepositoryOnItemRemove;
    }

    public void ThingAddedAGD(AGD item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAddedGroceries(Groceries item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAddedKitchenAccessories(KitchenAccessories item)
    {
        Console.WriteLine($"Thing added: {item.Name}, Location: {item.Location}, Count: {item.Count}");
    }

    public void ThingAGDRepositoryOnItemAdded(object? sender, AGD e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingGroceriesRepositoryOnItemAdded(object? sender, Groceries e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingKitchenAccessoriesRepositoryOnItemAdded(object? sender, KitchenAccessories e)
    {
        Console.WriteLine($"Thing added: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingAGDRepositoryOnItemRemove(object? sender, AGD e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingGroceriesRepositoryOnItemRemove(object? sender, Groceries e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }

    public void ThingKitchenAccessoriesRepositoryOnItemRemove(object? sender, KitchenAccessories e)
    {
        Console.WriteLine($"Thing Remove: {e.Name}, from: {sender?.GetType().Name}");
    }
}