using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class Felon
    {
        [Key]
        public int FelonId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Alias { get; set; }

        [Display(Name = "# of Addresses")]
        public List<FelonAddress> FelonAddresses { get; set; }

        [Display(Name = "Bailbonds")]
        public List<FelonBounty> FelonBounties { get; set; }
    }
}
