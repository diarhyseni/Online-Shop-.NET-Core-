﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Models
{
    public class Headset : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Marka { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Modeli { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Ngjyra { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        [Range(0, 9999.99)]
        public double Price { get; set; }
    }
}
