using Microsoft.EntityFrameworkCore;
using Project39_SurvivorWebAPI.Models.Entities;

namespace Project39_SurvivorWebAPI.Models.Context
{
    public class SurvivorDbContext : DbContext
    {
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456eda;Database=PatikaCodeFirstDb3");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Competitors)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                 new Category { Id = 1, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, Name = "Ünlüler" },
                 new Category { Id = 2, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, Name = "Gönüllüler" }
             );
            modelBuilder.Entity<Competitor>()
               .HasData(
                   new Competitor { Id = 1, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Acun", LastName = "Ilıcalı", CategoryId = 1 },
                   new Competitor { Id = 2, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Aleyna", LastName = "Avcı", CategoryId = 1 },
                   new Competitor { Id = 3, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Hadise", LastName = "Açıkgöz", CategoryId = 1 },
                   new Competitor { Id = 4, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Sertan", LastName = "Bozkuş", CategoryId = 1 },
                   new Competitor { Id = 5, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Özge", LastName = "Açık", CategoryId = 1 },
                   new Competitor { Id = 6, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Kıvanç", LastName = "Tatlıtuğ", CategoryId = 1 },
                   new Competitor { Id = 7, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Ahmet", LastName = "Yılmaz", CategoryId = 2 },
                   new Competitor { Id = 8, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Elif", LastName = "Demirtaş", CategoryId = 2 },
                   new Competitor { Id = 9, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Cem", LastName = "Öztürk", CategoryId = 2 },
                   new Competitor { Id = 10, CreatedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), ModifiedDate = new DateTime(2024, 01, 01, 10, 00, 00).ToUniversalTime(), IsDeleted = false, FirstName = "Ayşe", LastName = "Karaca", CategoryId = 2 }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}
