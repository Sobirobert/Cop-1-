namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;

public class WhatWhereDbContext : DbContext
{
    public DbSet<AGD> _AGD => Set<AGD>();
    public DbSet<Groceries> _Groceries => Set<Groceries>();
    public DbSet<KitchenAccessories> _KitchenAccessories => Set<KitchenAccessories>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}