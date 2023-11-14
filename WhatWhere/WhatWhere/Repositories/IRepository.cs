using WhatWhere.Entities;

namespace WhatWhere.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
       where T : class, IEntity
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;
    }
}