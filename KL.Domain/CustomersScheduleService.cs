using System.Collections.Generic;
namespace KL.Domain
{
    public class CustomerscheduleService
    {
        public int CustomersId { get; set; }
        public Customers Client { get; set; }
        public int ScheduleServiceId { get; set; }
        public ScheduleService ScheduleService { get; set; }
        public List<CustomerscheduleService> CustomerscheduleServices { get; set; }
    }
}