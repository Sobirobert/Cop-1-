using WhatWhere.Entities;
using WhatWhere.Repositories;

namespace WhatWhere.Services;

public interface IMethodsExtensions
{
    int AddStringConversionToInt(string value);

    void AddObjectToMemory<T>(IRepository<T> repository) where T : class, IEntity, new() { }
}