using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public interface IMethodsExtensions
{
    int AddStringConversionToInt(string value);

    void AddAGDObjectToMemory(IRepository<AGD> repository) { }

    void AddGroceriesObjectToMemory(IRepository<Groceries> repository) { }

    void AddKitchenAccessoriesObjectToMemory(IRepository<KitchenAccessories> repository) { }
}