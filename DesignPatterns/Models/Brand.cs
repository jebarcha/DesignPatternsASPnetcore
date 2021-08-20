using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DesignPatterns.Models
{
    public partial class Brand
    {
        [Key]
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
