using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DesignPatterns.Models
{
    public partial class Beer
    {
        [Key]
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
    }
}
