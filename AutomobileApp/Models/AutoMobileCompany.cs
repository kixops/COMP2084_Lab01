using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AutomobileApp.Models
{
    public partial class AutoMobileCompany
    {
        public AutoMobileCompany()
        {
            Cars = new HashSet<Cars>();
        }

        public int CompanyId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Foundation { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public virtual ICollection<Cars> Cars { get; set; }
    }
}
