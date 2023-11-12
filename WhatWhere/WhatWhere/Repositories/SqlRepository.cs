namespace WhatWhere.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WhatWhere.Entities;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    private readonly Action<T>? _itemAddedCallback;
    private readonly Action<T>? _itemRemoveCallback;

    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null, Action<T>? itemRemoveCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
        _itemRemoveCallback = itemRemoveCallback;
    }

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemove;

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id) => _dbSet.Find(id);

    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemRemove?.Invoke(this, item);
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