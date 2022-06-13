using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using schiverleih4.Data.Models;

namespace schiverleih4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Rents> Rents { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Streets> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Categories>().HasKey(x => x.CategoryID);
            builder.Entity<Cities>().HasKey(x => x.ZIPCode);
            builder.Entity<Countries>().HasKey(x => x.AreaCode);
            builder.Entity<Customers>().HasKey(x => x.CustomerId);
            builder.Entity<Products>().HasKey(x => x.ProductNumber);
            builder.Entity<Rents>().HasKey(x => x.RentId);
            builder.Entity<Streets>().HasKey(x => x.StreetId);
            builder.Entity<Addresses>().HasKey(x => x.AddressId);

        }

    }
}