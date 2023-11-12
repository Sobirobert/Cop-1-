namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;
public class WhatWhereDbContext : DbContext
{
    public DbSet<AGD> _AGD => Set<AGD>();
    public DbSet<Groceries> _Groceries => Set<Groceries>();
    public DbSet<KitchenAccessories> _KitchenAccessories => Set<KitchenAccessories>();

   // private readonly string uRLString = $@"Data Source=DESKTOP-7S5NEGF\SQLEXPRESS01;Initial Catalog=WhatWhereSQL;Integrated Security=True";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageAppDb");
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //    optionsBuilder.UseSqlServer(uRLString);
    //}
}

