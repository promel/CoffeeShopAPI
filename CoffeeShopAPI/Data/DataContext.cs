using System;
using CoffeeShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.Data
{
	public partial class DataContext : DbContext
	{
		public DataContext(DbContextOptions <DataContext> options) : base(options) { }
		public DbSet<Purchase> Purchases => Set<Purchase>();
		public DbSet<User> Users => Set<User>();
		public DbSet<Coffee> Coffees => Set<Coffee>();
		public DbSet<Role> Roles => Set<Role>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DataSource=./Database/CoffeeShop.sqlite3");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
    }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}

