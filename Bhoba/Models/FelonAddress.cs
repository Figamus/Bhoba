using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class FelonAddress
    {
        [Key]
        public int FelonAddressId { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int FelonId { get; set; }
    }
}