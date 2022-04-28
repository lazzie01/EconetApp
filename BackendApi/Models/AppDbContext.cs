using Microsoft.EntityFrameworkCore;


namespace BackendApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Department Table
            modelBuilder.Entity<Area>().HasData(new Area { Id = 1, Name = "Harare CBD" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 2, Name = "Bulawayo CBD" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 3, Name = "Mutare CBD" });

            //Seed Employee Table
            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 1,
                Name = "Econet First Street",
                AreaId = 1
            });

            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 2,
                Name = "Econet Joina",
                AreaId = 1
            });

            modelBuilder.Entity<Shop>().HasData(new Shop
            {
                Id = 3,
                Name = "Econet Bulawayo",
                AreaId = 2
            });
        }
    }
}
