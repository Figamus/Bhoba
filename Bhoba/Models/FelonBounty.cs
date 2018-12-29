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
        [StringLength(55, ErrorMessage = "Please enter the associated police report number")]
        public string PoliceReportNumber { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please specify the type of violation")]
        public string CrimeType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double BountyAmount { get; set; }

        [Required]
        public bool BondClosed { get; set; }

        public BailBondsman BailBondsman { get; set; }
        public Felon Felon { get; set; }
    }
}
