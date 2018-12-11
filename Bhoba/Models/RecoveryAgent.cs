using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class RecoveryAgent
    {

        [Key]
        public int RecoveryAgentId { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string SerialNumber { get; set; }
    }
}
