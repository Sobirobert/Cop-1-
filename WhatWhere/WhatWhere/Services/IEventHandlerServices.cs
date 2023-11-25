using WhatWhere.Entities;

namespace WhatWhere.Services
{
    public interface IEventHandlerServices
    {
        void ThingAddedAGD(AGD item);

        void ThingAddedGroceries(Groceries item);

        void ThingAddedKitchenAccessories(KitchenAccessories item);

        void ThingAGDRepositoryOnItemAdded(object? sender, AGD e);

        void ThingGroceriesRepositoryOnItemAdded(object? sender, Groceries e);

        void ThingKitchenAccessoriesRepositoryOnItemAdded(object? sender, KitchenAccessories e);

        void ThingAGDRepositoryOnItemRemove(object? sender, AGD e);

        void ThingGroceriesRepositoryOnItemRemove(object? sender, Groceries e);

        void ThingKitchenAccessoriesRepositoryOnItemRemove(object? sender, KitchenAccessories e);

        void SubscribeToEvents();
    }
}