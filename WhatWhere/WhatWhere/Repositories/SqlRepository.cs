namespace WhatWhere.Repositories;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;
using System.Collections.Generic;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        if (id < Id.Count)
        {
            return _dbSet.Find(id);
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }
    public void Add(T item)
    {
        if(item != nill)
        {
            _dbSet.Add(item);
        }
        else
        {
            throw new InvalidOperationException("Incorrect  value");
        }
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    
}
