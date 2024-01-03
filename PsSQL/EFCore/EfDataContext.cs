using Microsoft.EntityFrameworkCore;
using PsSQL.Models.Entities;

namespace PsSQL.EFCore
{
    public class EfDataContext : DbContext
    {
        public EfDataContext(DbContextOptions<EfDataContext> options) :
            base(options)
        { }


        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<UserLogin> Users { get; set; }
    }


}
