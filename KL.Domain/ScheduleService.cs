using System.ComponentModel.DataAnnotations;
using System;

namespace KL.Domain
{
    public class ScheduleService {
    
     [Key]    
     public int Id {get; set;}  

     [Required(ErrorMessage = "Required field")]
     [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
     public decimal Price {get; set;}     

     [Required(ErrorMessage = "Required field")]
     public DateTime ContractDate {get; set;}

     [Required(ErrorMessage = "Required field")]
     public DateTime DeliveryDate {get; set;}

     [Required(ErrorMessage = "Required field")]     
     public DateTime UpdateDate { get; set; }

     public int CustomersId {get; set;}   
     public Customers Customers {get; }
    }
}