using Microsoft.EntityFrameworkCore;
using KL.Domain;

namespace KL.Repository
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<Customers> Customers { get; set; }
        public DbSet<ScheduleService> ScheduleService { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<CustomerscheduleService> CustomerscheduleServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                        .Property(p => p.UpdateDate)
                        .HasColumnType("datetime");

            modelBuilder.Entity<Customers>()
                        .Property(p => p.BirthDate)
                        .HasColumnType("datetime");
            
            modelBuilder.Entity<ScheduleService>()
                        .Property(p => p.Price)
                        .HasColumnType("money");

            modelBuilder.Entity<ScheduleService>()
                        .Property(p => p.UpdateDate)
                        .HasColumnType("datetime");
            
            modelBuilder.Entity<ScheduleService>()
                        .Property(p => p.DeliveryDate)
                        .HasColumnType("datetime");

            modelBuilder.Entity<ScheduleService>()
                        .Property(p => p.ContractDate)
                        .HasColumnType("datetime");

            // Refering Foreing Key in Relationship table
            modelBuilder.Entity<CustomerscheduleService>()
            .HasKey(CS => new { CS.CustomersId, CS.ScheduleServiceId });
            
        }       
    }
}