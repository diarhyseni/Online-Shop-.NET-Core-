using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public String Mesazhi { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public String Emri { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public String Subjekti { get; set; }
    }
}
