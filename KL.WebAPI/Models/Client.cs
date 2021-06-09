using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace KL.WebAPI.Models
{
    public class Clients {
       [Key]      
       public int Id {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(150, ErrorMessage = "MaxLength 150 characters")] 
       [MinLength(3, ErrorMessage = "MinLength 3 characters")] 
       public string Name {get; set;}

       [Required(ErrorMessage = "Required field")]
       public int CodArea1 {get; set;}

       [Required(ErrorMessage = "Required field")]
       public int PhoneNumber1 {get; set;}      
       
       public int CodArea2 {get; set;}       
       public int PhoneNumber2 {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(150, ErrorMessage = "MaxLength 150 characters")] 
       public string Email {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(100, ErrorMessage = "MaxLength 150 characters")] 
       public string Adress {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(10, ErrorMessage = "MaxLength 10 characters")] 
       public string Number {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(100, ErrorMessage = "MaxLength 100 characters")] 
       public string Neighborhood {get; set;}

       [Required(ErrorMessage = "Required field")]
       [MaxLength(100, ErrorMessage = "MaxLength 100 characters")] 
       public string City {get; set;}

       [Required(ErrorMessage = "Required field")]
       public string FedUnit {get; set;}

       [Required(ErrorMessage = "Required field")]     
       public DateTime UpdateDate { get; set; }
       public List<ScheduleService> SchedulesServices { get; set; }
   }
}
