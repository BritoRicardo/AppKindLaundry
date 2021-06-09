using KL.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KL.WebAPI.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<ScheduleService> ScheduleService { get; set; }
        public DbSet<Provinces> Provinces { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base (options){}
    }
}