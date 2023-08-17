using eshop.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastructure.Data
{
    public class AkbankDbContext : DbContext
    {

        public AkbankDbContext(DbContextOptions<AkbankDbContext> options) : base(options)
        {

        }
        //ORM: Object Relational Mapping
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> categories = new List<Category>
            {
                 new(){ Id=1, Name = "Kırtasiye"},
                 new(){ Id=2, Name = "Bilgisayar"},
                 new(){ Id=3, Name = "Astronomi Araçları"},

            };
            modelBuilder.Entity<Category>().HasData(categories);

            List<Category> hede = new List<Category>();

            List<Product> products = new List<Product>
            {
                new(){ Id=1, Name="Beyaz Tahta", CategoryId=1, Description="Beyaz Tahta :)", Discount=.20M, Price=570 },
                new(){ Id=2, Name="Asus Rock", CategoryId=2, Description="....", Discount=.20M, Price=25000 },
                new(){ Id=3, Name="Amatör Teleskop", CategoryId=3, Description="Ucuz teleskop", Discount=.20M, Price=7000 },
                new(){ Id=4, Name="Beyaz Tahta 1", CategoryId=2, Description="Beyaz Tahta :)", Discount=.20M, Price=570 },
                new(){ Id=5, Name="Beyaz Tahta 2", CategoryId=3, Description="Beyaz Tahta :)", Discount=.20M, Price=570 },
                new(){ Id=6, Name="Beyaz Tahta 3", CategoryId=1, Description="Beyaz Tahta :)", Discount=.20M, Price=570 },
                new(){ Id=7, Name="Beyaz Tahta 4", CategoryId=1, Description="Beyaz Tahta :)", Discount=.20M, Price=570 },
            };

            modelBuilder.Entity<Product>().HasData(products);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=AkbankEshopDb;Integrated Security=True");
        }

    }
}
