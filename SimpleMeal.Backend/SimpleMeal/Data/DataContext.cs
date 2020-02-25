using Microsoft.EntityFrameworkCore;
using SimpleMeal.Models;

namespace SimpleMeal.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
<<<<<<< HEAD
=======
        public DbSet<Table> Tables { get; set; }
>>>>>>> feature/begin_api
    }
}