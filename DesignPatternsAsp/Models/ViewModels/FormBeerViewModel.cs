using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatternsAsp.Models.ViewModels
{
    public class FormBeerViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Style { get; set; }
        
        [Display(Name = "Brand")]
        public Guid? BrandId { get; set; }
        
        [Display(Name = "Other brand")]
        public string OtherBrand { get; set; }
    }
}
