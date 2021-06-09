using Microsoft.EntityFrameworkCore;
using KL.Domain;

namespace KL.Repository
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ScheduleService> ScheduleService { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<ClientScheduleService> ClientScheduleServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Refering Foreing Key in Relationship table
            modelBuilder.Entity<ClientScheduleService>()
            .HasKey(CS => new { CS.ClientsId, CS.ScheduleServiceId });
        }
       
    }
}