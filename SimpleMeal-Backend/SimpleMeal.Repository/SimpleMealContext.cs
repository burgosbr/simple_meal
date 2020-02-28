using Microsoft.EntityFrameworkCore;
using SimpleMeal.Domain;

namespace SimpleMeal.Repository
{
    public class SimpleMealContext : DbContext
    {
        public SimpleMealContext(DbContextOptions<SimpleMealContext> options) : base(options)
        { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(OP => new { OP.OrderId, OP.ProductId });
        }
    }
}