using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDonationManagement.Models
{
    public class Donar
    {
        [Key]
        public int DonarId { get; set; }
        [Required]
        public string DonarName { get; set; }
        [Required]
        public int NumberOfDonations { get; set; }
        [Required]
        public string SchoolName { get; set; }

    }
}
