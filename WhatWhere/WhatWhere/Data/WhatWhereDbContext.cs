namespace WhatWhere.Data;

using Microsoft.EntityFrameworkCore;
using WhatWhere.Entities;
public class WhatWhereDbContext : DbContext
{

    private readonly string _serverURL = "Data Source=DESKTOP-7S5NEGF\\SQLEXPRESS01;Initial Catalog=WhatWhereSQL;Integrated Security=True";
    public DbSet<AGD> AGDs { get; set; }

    public DbSet<Groceries> Groceries { get; set; }
    public DbSet<KitchenAccessories> KitchenAccessories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_serverURL);
    }
}

