using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}