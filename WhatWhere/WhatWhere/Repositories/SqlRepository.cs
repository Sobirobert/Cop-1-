namespace WhatWhere.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatWhere.Entities;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;
    private readonly Action<T>? _itemAddedCallback;

    public event IRepository<T>.GradeAddedDelegate GradeAdded;

    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }

    public event EventHandler<T>? ItemAdded;

    public event EventHandler<T>? ItemRemove;

    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item);
        ItemAdded?.Invoke(this, item);
        if (GradeAdded != null)
        {
            GradeAdded(this, new EventArgs());
        }
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id) => _dbSet.Find(id);

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        _dbContext.SaveChanges();
        ItemRemove?.Invoke(this, item);
    }

    public void RemoveAll()
    {
        _dbSet.RemoveRange(_dbSet);
        _dbContext.SaveChanges();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}