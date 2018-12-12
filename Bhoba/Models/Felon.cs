using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public int DateOfBirth { get; set; }

        [Required]
        public List<Address> Addresses { get; set; }

        [Required]
        public string Alias { get; set; }
    }
}
