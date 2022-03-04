using System;
using Microsoft.EntityFrameworkCore;
using infrastructure.Data.Entities;

namespace infrastructure.Data.Context
{
    public class SabaShopContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<MoreImage> MoreImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Baner> Baners { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Data source =. ; initial Catalog = SabaShop ; integrated Security = true ;");
        }
        
    }
}