using System.Linq;
using System.Threading.Tasks;
using KL.Domain;
using Microsoft.EntityFrameworkCore;

namespace KL.Repository
{
    public class KLRepository : IKLRepository
    {
        public DataContext _context { get; }
        public KLRepository(DataContext context)
        {
            this._context = context;

        }

        //GENERAL
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // If saved return > 0 or true
            return (await _context.SaveChangesAsync()) > 0;
        }

        //CLIENTS
        // Param includeScheduleService is opcional
        public async Task<Clients[]> GetAllClients(bool includeScheduleService = false)
        {
            IQueryable<Clients> query = _context.Clients;

            if (includeScheduleService)
            {
                //Integrated with relationship table
                query = query
                    .Include(cs => cs.ClientScheduleServices)
                    .ThenInclude(s => s.ScheduleService);
            }
            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }       

        public async Task<Clients[]> GetAllClientsByName(string name, bool includeScheduleService)
        {
            IQueryable<Clients> query = _context.Clients;

            if (includeScheduleService)
            {
                //Integrated with relationship table
                query = query
                    .Include(cs => cs.ClientScheduleServices)
                    .ThenInclude(s => s.ScheduleService);
            }
            query = query.OrderBy(c => c.Name)
                        .Where(c => c.Name.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Clients> GetClientById(int ClientId, bool includeScheduleService = false)
        {
            IQueryable<Clients> query = _context.Clients;

            if (includeScheduleService)
            {
                //Integrated with relationship table
                query = query
                    .Include(cs => cs.ClientScheduleServices)
                    .ThenInclude(s => s.ScheduleService);
            }
            query = query.OrderBy(c => c.Name)
                        .Where(c => c.Id == ClientId);

            return await query.FirstOrDefaultAsync();
        }

        //PROVINCES
        public async Task<Provinces> GetProvinceId(int Provinceid)
        {
            IQueryable<Provinces> query = _context.Provinces;
            
            query = query.OrderBy(c => c.Region)
                        .Where(c => c.Id == Provinceid);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Provinces[]> GetAllProvinces()
        {
            IQueryable<Provinces> query = _context.Provinces;
           
            query = query.OrderBy(c => c.Region);                        

            return await query.ToArrayAsync();
        }
    }
}