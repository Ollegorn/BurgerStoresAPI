using Microsoft.EntityFrameworkCore;



namespace Entities
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().ToTable("Stores");

            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    StoreId = 1,
                    StoreName = "BestBurger",
                    StoreLocation = "Athens",
                    StorePhoneNumber = "1234567890",
                    IsStoreOpen = true,
                    BurgerIds = "burgerIds=1&burgerIds=2&burgerIds=3"
                },
                new Store
                {
                    StoreId = 2,
                    StoreName = "Amigos",
                    StoreLocation = "Mexico",
                    StorePhoneNumber = "1234567890",
                    IsStoreOpen = true,
                    BurgerIds = "burgerIds=2&burgerIds=3&burgerIds=4"

                });
        }
    }
}
