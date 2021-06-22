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

         
         //Customers
         Task<Customers[]> GetAllCustomers(bool includeScheduleService);
         Task<Customers[]> GetAllCustomersByName(string name, bool includeScheduleService);
         Task<Customers> GetClientById(int ClientId, bool includeScheduleService);

         //PROVINCES
         Task<Provinces[]> GetAllProvinces();
         Task<Provinces> GetProvinceId(int Provinceid);   
    }
}