using System.ComponentModel.DataAnnotations;
using System;

namespace KL.Domain
{
    public class ScheduleService {
    
     [Key]    
     public int Id {get; set;}  

     [Required(ErrorMessage = "Required field")]
     [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
     public string Price {get; set;}
     

     [Required(ErrorMessage = "Required field")]
     public string ContractDate {get; set;}


     [Required(ErrorMessage = "Required field")]
     public string DeliveryDate {get; set;}

     [Required(ErrorMessage = "Required field")]     
     public string UpdateDate { get; set; }

     public int ClientsId {get; set;}   
     public Clients Clients {get; }
    }
}