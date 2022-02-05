using HotelsHubApp.Entities.EFCoreEntities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Context
{
    public class HotelbedsDBContext : DbContext
    {
        public HotelbedsDBContext()
        {

        }
        public HotelbedsDBContext(DbContextOptions<HotelbedsDBContext> options) : base(options) { }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Policies> Policies { get; set; }
        public DbSet<TaxesAndFees> TaxesAndFees { get; set; }
        public DbSet<Remarks> Remarks { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<ChargeType> ChargeTypes { get; set; }
        public DbSet<PolicyType> PolicyTypes { get; set; }
        public DbSet<Search> Search { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().Property(x => x.CheckIn).HasColumnType("date");
            modelBuilder.Entity<Reservation>().Property(x => x.CheckOut).HasColumnType("date");
            modelBuilder.Entity<Reservation>().Property(x => x.Price).HasColumnType("decimal(5,0)");

            modelBuilder.Entity<Policies>().Property(x => x.StartDate).HasColumnType("date");
            modelBuilder.Entity<Policies>().Property(x => x.EndtDate).HasColumnType("date");
            modelBuilder.Entity<Policies>().Property(x => x.Price).HasColumnType("decimal(5,0)");            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
