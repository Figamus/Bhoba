using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bhoba.Models
{
    public class FelonBounty
    {
        [Key]
        public int FelonBountyId { get; set; }

        [Required]
        public int BailBondsmanId { get; set; }

        [Required]
        public int FelonId { get; set; }

        [Required]
        public double BountyAmount { get; set; }

        public BailBondsman BailBondsman { get; set; }
        public Felon Felon { get; set; }
    }
}
