using System.Collections.Generic;
namespace KL.Domain
{
    public class ClientScheduleService
    {
        public int ClientsId { get; set; }
        public Clients Client { get; set; }
        public int ScheduleServiceId { get; set; }
        public ScheduleService ScheduleService { get; set; }
        public List<ClientScheduleService> ClientScheduleServices { get; set; }
    }
}