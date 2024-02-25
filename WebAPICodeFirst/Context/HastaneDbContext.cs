using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.Model;

namespace WebAPICodeFirst.Context
{
    public class HastaneDbContext:DbContext
    {
        public HastaneDbContext(DbContextOptions<HastaneDbContext>options):base(options)
        {
            
        }
        public DbSet<Hastane>Hastaneler { get; set; }
        public DbSet<Hasta>Hastalar {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hasta>().HasData(
                new Hasta
                {
                    Id = 1,
                    Isim="John",
                    Soyisim="Doe",
                    HastaneId=1,
                    Klinik="Kardiyoloji",
                    MuayeneTarihi=DateTime.Now,

                },
                  new Hasta
                  {
                      Id = 2,
                      Isim = "Jane",
                      Soyisim = "Doe",
                      HastaneId = 2,
                      Klinik = "Üroloji",
                      MuayeneTarihi = new DateTime(2024,12,12)

                  }

                );
            modelBuilder.Entity<Hastane>().HasData(
                new Hastane { Id = 1, Adres = "Beşiktaş", HastaneAd = "Sait Çiftçi Devlet Hastanesi" },
                 new Hastane { Id = 2, Adres = "Kartal", HastaneAd = "Kartal Devlet Hastanesi" }
                
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
