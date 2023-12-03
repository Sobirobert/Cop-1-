namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;

public class WhatWhereDbContext : DbContext
{
    public DbSet<AGD> AGD => Set<AGD>();
    public DbSet<FoodProduct> FoodProduct => Set<FoodProduct>();
    public DbSet<KitchenAccessory> KitchenAccessory => Set<KitchenAccessory>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
}