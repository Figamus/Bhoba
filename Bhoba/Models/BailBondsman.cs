using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class BailBondsman
    {

        [Key]
        public int BailBondsmanId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please set a city")]
        public string City { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please select a state")]
        public string State { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public virtual ICollection<RecoveryAgent> RecoveryAgents { get; set; }
    }
}
