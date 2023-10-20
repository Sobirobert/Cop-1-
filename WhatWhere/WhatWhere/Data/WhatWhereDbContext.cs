namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;
public class WhatWhereDbContext : DbContext
{
    public DbSet<AGD> AGDs => Set<AGD>();

    public DbSet<Groceries> Groceries => Set<Groceries>();

    public DbSet<KitchenAccessories> KitchenAccessories => Set<KitchenAccessories>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}

