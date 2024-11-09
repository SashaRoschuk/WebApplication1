using ProductDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace ProductDB
{
    public class ShopDBcontext : IdentityDbContext
    {
        public ShopDBcontext() :base() { }

        public ShopDBcontext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users {  get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"workstation id=shopDB1.mssql.somee.com;packet size=4096;user id=Torpeda_SQLLogin_1;pwd=f3sbizpspf;data source=shopDB1.mssql.somee.com;persist security info=False;initial catalog=shopDB1;TrustServerCertificate=True");
        //}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(c => c.CategoryId);
            //Initialization - Seeder
            modelBuilder.Entity<Product>().Property(p=>p.Name).IsRequired().HasMaxLength(200);
            modelBuilder.SeedCategory();
            modelBuilder.SeedProducts();
            
            
        }
        
    }
}