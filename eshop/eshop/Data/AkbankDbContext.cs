using eshop.Models;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data
{
    public class AkbankDbContext : DbContext
    {
        //ORM: Object Relational Mapping
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
