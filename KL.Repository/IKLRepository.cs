using System.Threading.Tasks;
using KL.Domain;

namespace KL.Repository
{
    public interface IKLRepository
    {
        //GENERAL
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         
         //CLIENTS
         Task<Clients[]> GetAllClients(bool includeScheduleService);
         Task<Clients[]> GetAllClientsByName(string name, bool includeScheduleService);
         Task<Clients> GetClientById(int ClientId, bool includeScheduleService);

         //PROVINCES
         Task<Provinces[]> GetAllProvinces();
         Task<Provinces> GetProvinceId(int Provinceid);   
    }
}