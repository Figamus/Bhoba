using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Display(Name = "Police Report #")]
        public string PoliceReportNumber { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please specify the type of violation")]
        [Display(Name = "Type of Crime")]
        public string CrimeType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Bounty Amount")]
        public double BountyAmount { get; set; }

        [Required]
        [Display(Name = "Bond Closed")]
        public bool BondClosed { get; set; }

        [Display(Name = "Bailbond Agency")]
        public BailBondsman BailBondsman { get; set; }

        public Felon Felon { get; set; }
    }
}
