using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AutomobileApp.Models
{
    public partial class Cars
    {
        public int CarId { get; set; }


        [Required]
        public int? CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Foundation { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual AutoMobileCompany Company { get; set; }
    }
}
