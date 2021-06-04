using kindLaundryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace kindLaundryAPI.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ScheduleService> ScheduleService { get; set; }
        public DbSet<Provinces> Provinces { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base (options){}
    }
}