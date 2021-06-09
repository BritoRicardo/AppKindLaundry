using System.ComponentModel.DataAnnotations;

namespace KL.WebAPI.Models
{
    public class Provinces
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Territory { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string AlphaCode { get; set; }

        [Required(ErrorMessage = "Required field")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string Region { get; set; }
    }
}