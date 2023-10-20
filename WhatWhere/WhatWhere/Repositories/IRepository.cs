using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
       where T : class, IEntity
    {
    }

}
